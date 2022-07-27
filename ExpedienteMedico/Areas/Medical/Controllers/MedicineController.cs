using ExpedienteMedico.Models;
using ExpedienteMedico.Models.IntermediateTables;
using ExpedienteMedico.Models.ViewModels;
using ExpedienteMedico.Repository.IRepository;
using ExpedienteMedico.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpedienteMedico.Areas.Medical.Controllers
{
    [Area("Medical")]
    [Authorize(Roles = Roles.Role_Admin + "," + Roles.Role_Physician)]
    public class MedicineController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;
        private UserManager<IdentityUser> _userManager;

        public MedicineController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<Medicine> objMedicineList = _unitOfWork.Medicine.GetAll();
            return View(objMedicineList);
        }

        public IActionResult CreateForHistory(string id) //User id
        {

            MedicalHistory medicalHistory = _unitOfWork.MedicalHistory.GetFirstOrDefault(x => x.UserId == id, null,
                includeProperties: "MedicalHistoryMedicines");

            MedicineVM vm = new MedicineVM();

            vm.HistoryId = medicalHistory.UserId;
            vm.Medicine = null;

            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateForHistory(MedicineVM vm) //User id
        {
            Medicine savedMedicine = null;
            if (ModelState.IsValid)
            {
                var Medicine = new Medicine() { Name = vm.Medicine.Name };
                _unitOfWork.Medicine.Add(Medicine);
                _unitOfWork.Save();
                savedMedicine = _unitOfWork.Medicine.GetLast();
            }

            int PhysicianId =
                _unitOfWork.Physician.GetByEmail(_userManager.FindByNameAsync(User.Identity.Name).Result.Email).Id;

            var historyMedicine = new MedicalHistory_Medicine()
            {
                MedicalHistoryId = vm.HistoryId,
                MedicineId = savedMedicine.Id,
                PhysicianId = PhysicianId
            };

            _unitOfWork.HistoryMedicine.Add(historyMedicine);
            _unitOfWork.Save();
            TempData["success"] = "Medicine added successfully";
            return RedirectToAction("Index");
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


        #region API

        public IActionResult GetAll()
        {
            var medicine = _unitOfWork.Medicine.GetAll();
            return Json(new { data = medicine, success = true });
        }

        public IActionResult Get(string id)
        {
            MedicalHistory medicalHistory = _unitOfWork.MedicalHistory.GetFirstOrDefault(x => x.UserId == id, null,
                includeProperties: "MedicalHistoryMedicines");

            List<Medicine> medicines = new List<Medicine>();

            for (int j = 0; j < medicalHistory.MedicalHistoryMedicines.Count(); j++)
            {
                var aux = medicalHistory.MedicalHistoryMedicines.ElementAt(j);
                Medicine medicine = _unitOfWork.HistoryMedicine.GetFirstOrDefault(u => u.MedicalHistoryId == aux.MedicalHistoryId, x => x.MedicineId == aux.MedicineId, includeProperties: "Medicines").Medicines;
                medicines.Add(medicine);
            }
            return Json(new { data = medicines, success = true });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var medicine = _unitOfWork.Medicine.GetFirstOrDefault(x => x.Id == id, null);

            if (medicine == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Medicine.Remove(medicine);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }


        #endregion
    }
}
