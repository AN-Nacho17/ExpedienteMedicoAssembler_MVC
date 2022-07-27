using ExpedienteMedico.Models;
using ExpedienteMedico.Repository.IRepository;
using ExpedienteMedico.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ExpedienteMedico.Areas.Medical.Controllers
{
    [Area("Medical")]
    [Authorize(Roles = Roles.Role_Admin + "," + Roles.Role_Physician)]
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

        public IActionResult View(string id) //User id
        {

            MedicalHistory medicalHistory = _unitOfWork.MedicalHistory.GetFirstOrDefault(x => x.UserId == id, null,
                includeProperties: "MedicalHistoryTreatments");

            List<Treatment> treatments = new List<Treatment>();

            for (int j = 0; j < medicalHistory.MedicalHistoryTreatments.Count(); j++)
            {
                var aux = medicalHistory.MedicalHistoryTreatments.ElementAt(j);
                Treatment treatment = _unitOfWork.HistoryTreatment.GetFirstOrDefault(u => u.MedicalHistoryId == aux.MedicalHistoryId, x => x.TreatmentId == aux.TreatmentId, includeProperties: "Treatments").Treatments;
                treatments.Add(treatment);
            }

            return View(treatments);
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


        #region API

        public IActionResult GetAll()
        {
            var treatment = _unitOfWork.Treatment.GetAll();
            return Json(new { data = treatment, success = true });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var treatment = _unitOfWork.Treatment.GetFirstOrDefault(x => x.Id == id, null);

            if (treatment == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Treatment.Remove(treatment);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
            //return RedirectToAction("Index");
        }
        #endregion
    }
}
