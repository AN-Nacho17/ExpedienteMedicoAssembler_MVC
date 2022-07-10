using ExpedienteMedico.Models;
using ExpedienteMedico.Repository.IRepository;
using ExpedienteMedico.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ExpedienteMedico.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = Roles.Role_Admin)]
    public class TreatmentController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;

        public TreatmentController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Treatment> objTreatmentList = _unitOfWork.Treatment.GetAll();
            return View(objTreatmentList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Treatment obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Treatment.Add(obj);
                _unitOfWork.Save();
            }
            TempData["success"] = "Treatment created succesfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Treatment obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Treatment.Update(obj);
                _unitOfWork.Save();
            }

            TempData["success"] = "Treatment edited succesfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _unitOfWork.Treatment.GetFirstOrDefault(x => x.Id == id, null);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Delete(int? id)
        {
            var treatment = _unitOfWork.Treatment.GetFirstOrDefault(x => x.Id == id, null);
            _unitOfWork.Treatment.Remove(treatment);
            _unitOfWork.Save();

            TempData["success"] = "Treatment deleted succesfully";
            return RedirectToAction("Index");
        }


        #region API

        public IActionResult GetAll()
        {
            var treatment = _unitOfWork.Treatment.GetAll();
            return Json(new { data = treatment, success = true });
        }
        #endregion
    }
}
