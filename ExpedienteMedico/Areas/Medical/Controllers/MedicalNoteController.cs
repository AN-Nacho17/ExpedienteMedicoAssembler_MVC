using ExpedienteMedico.Models;
using ExpedienteMedico.Repository.IRepository;
using ExpedienteMedico.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



namespace ExpedienteMedico.Areas.Medical.Controllers
{
    [Area("Medical")]
    [Authorize(Roles = Roles.Role_Admin + "," + Roles.Role_Physician)]
    public class MedicalNoteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;

        public MedicalNoteController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<MedicalNote> objMedicalNoteList = _unitOfWork.MedicalNote.GetAll();
            return View(objMedicalNoteList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MedicalNote obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MedicalNote.Add(obj);
                _unitOfWork.Save();
            }
            TempData["success"] = "Medical Note created succesfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MedicalNote obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.MedicalNote.Update(obj);
                _unitOfWork.Save();
            }

            TempData["success"] = "Medical Note edited succesfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _unitOfWork.MedicalNote.GetFirstOrDefault(x => x.Id == id, null);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Delete(int? id)
        {
            var medicalNote = _unitOfWork.MedicalNote.GetFirstOrDefault(x => x.Id == id, null);

            if (medicalNote == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.MedicalNote.Remove(medicalNote);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
            //return RedirectToAction("Index");
        }


        #region API

        public IActionResult GetAll()
        {
            var medicalNote = _unitOfWork.MedicalNote.GetAll();
            return Json(new { data = medicalNote, success = true });
        }

        public IActionResult Get(string id)
        {
            MedicalHistory medicalHistory = _unitOfWork.MedicalHistory.GetFirstOrDefault(x => x.UserId == id, null,
                includeProperties: "Notes");

            List<MedicalNote> notes = new List<MedicalNote>();

            for (int j = 0; j < medicalHistory.MedicalNotes.Count(); j++)
            {
                var aux = medicalHistory.MedicalNotes.ElementAt(j);
                MedicalNote note = _unitOfWork.MedicalNote.GetFirstOrDefault(u => u.MedicalHistoryId == aux.MedicalHistoryId, x => x.Id == aux.Id, includeProperties: "Notes");
                notes.Add(note);
            }

            return Json(new { data = notes, success = true });
        }
        #endregion
    }
}

