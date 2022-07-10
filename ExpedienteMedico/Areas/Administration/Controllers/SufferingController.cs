using ExpedienteMedico.Models;
using ExpedienteMedico.Repository.IRepository;
using ExpedienteMedico.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpedienteMedico.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = Roles.Role_Admin)]
    public class SufferingController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;

        public SufferingController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Suffering> objSufferingList = _unitOfWork.Suffering.GetAll();
            return View(objSufferingList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Suffering obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Suffering.Add(obj);
                _unitOfWork.Save();
            }
            TempData["success"] = "Suffering created succesfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Suffering obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Suffering.Update(obj);
                _unitOfWork.Save();
            }

            TempData["success"] = "Suffering edited succesfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _unitOfWork.Suffering.GetFirstOrDefault(x => x.Id == id, null);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Delete(int? id)
        {
            var suffering = _unitOfWork.Suffering.GetFirstOrDefault(x => x.Id == id, null);
            _unitOfWork.Suffering.Remove(suffering);
            _unitOfWork.Save();

            TempData["success"] = "Suffering deleted succesfully";
            return RedirectToAction("Index");
        }


        #region API

        public IActionResult GetAll()
        {
            var suffering = _unitOfWork.Suffering.GetAll();
            return Json(new { data = suffering, success = true });
        }
        #endregion
    }
}
