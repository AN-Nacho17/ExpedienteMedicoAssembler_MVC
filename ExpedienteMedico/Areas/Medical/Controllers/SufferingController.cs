using ExpedienteMedico.Models;
using ExpedienteMedico.Repository.IRepository;
using ExpedienteMedico.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpedienteMedico.Areas.Medical.Controllers
{
    [Area("Medical")]
    [Authorize(Roles = Roles.Role_Admin + "," + Roles.Role_Physician)]
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



        #region API

        public IActionResult GetAll()
        {
            var suffering = _unitOfWork.Suffering.GetAll();
            return Json(new { data = suffering, success = true });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var suffering = _unitOfWork.Suffering.GetFirstOrDefault(x => x.Id == id, null);

            if (suffering == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Suffering.Remove(suffering);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
            //return RedirectToAction("Index");
        }

        #endregion
    }
}
