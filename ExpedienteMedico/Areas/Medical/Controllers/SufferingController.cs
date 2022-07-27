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
    public class SufferingController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;
        private UserManager<IdentityUser> _userManager;

        public SufferingController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<Suffering> objSufferingList = _unitOfWork.Suffering.GetAll();
            return View(objSufferingList);
        }

        public IActionResult CreateForHistory(string id) //User id
        {

            MedicalHistory medicalHistory = _unitOfWork.MedicalHistory.GetFirstOrDefault(x => x.UserId == id, null,
                includeProperties: "MedicalHistorySufferings");

            SufferingVM vm = new SufferingVM();

            vm.HistoryId = medicalHistory.UserId;
            vm.Suffering = null;

            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateForHistory(SufferingVM vm) //User id
        {
            Suffering savedSuffering = null;
            if (ModelState.IsValid)
            {
                var Suffering = new Suffering() { Name = vm.Suffering.Name, Description = vm.Suffering.Description };
                _unitOfWork.Suffering.Add(Suffering);
                _unitOfWork.Save();
                savedSuffering = _unitOfWork.Suffering.GetLast();
            }

            int PhysicianId =
                _unitOfWork.Physician.GetByEmail(_userManager.FindByNameAsync(User.Identity.Name).Result.Email).Id;

            var historySuffering = new MedicalHistory_Suffering()
            {
                MedicalHistoryId = vm.HistoryId,
                SufferingId = savedSuffering.Id,
                PhysicianId = PhysicianId
            };

            _unitOfWork.HistorySuffering.Add(historySuffering);
            _unitOfWork.Save();
            return RedirectToAction("Index");
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

        public IActionResult Get(string id)//User id or expedient id, is the same
        {
            MedicalHistory medicalHistory = _unitOfWork.MedicalHistory.GetFirstOrDefault(x => x.UserId == id, null,
                includeProperties: "MedicalHistorySufferings");

            List<Suffering> sufferings = new List<Suffering>();

            for (int j = 0; j < medicalHistory.MedicalHistorySufferings.Count(); j++)
            {
                var aux = medicalHistory.MedicalHistorySufferings.ElementAt(j);
                Suffering suffering = _unitOfWork.HistorySuffering.GetFirstOrDefault(u => u.MedicalHistoryId == aux.MedicalHistoryId, x => x.SufferingId == aux.SufferingId, includeProperties: "Sufferings").Sufferings;
                sufferings.Add(suffering);
            }
            return Json(new { data = sufferings, success = true });
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
