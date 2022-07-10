using ExpedienteMedico.Models;
using ExpedienteMedico.Repository.IRepository;
using ExpedienteMedico.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpedienteMedico.Areas.Medical.Controllers
{
    [Area("Medical")]
    [Authorize(Roles = Roles.Role_Admin + "," + Roles.Role_Physician)]
    public class MedicineController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;

        public MedicineController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Medicine> objMedicineList = _unitOfWork.Medicine.GetAll();
            return View(objMedicineList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medicine obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Medicine.Add(obj);
                _unitOfWork.Save();
            }
            TempData["success"] = "Medicine created succesfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Medicine obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Medicine.Update(obj);
                _unitOfWork.Save();
            }

            TempData["success"] = "Medicine edited succesfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _unitOfWork.Medicine.GetFirstOrDefault(x => x.Id == id, null);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Delete(int? id)
        {
            var medicine = _unitOfWork.Medicine.GetFirstOrDefault(x => x.Id == id, null);
            _unitOfWork.Medicine.Remove(medicine);
            _unitOfWork.Save();

            TempData["success"] = "Medicine deleted succesfully";
            return RedirectToAction("Index");
        }


        #region API

        public IActionResult GetAll()
        {
            var medicine = _unitOfWork.Medicine.GetAll();
            return Json(new { data = medicine, success = true });
        }
        #endregion
    }
}
