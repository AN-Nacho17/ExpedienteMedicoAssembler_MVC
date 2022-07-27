using ExpedienteMedico.Models;
using ExpedienteMedico.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace ExpedienteMedico.Areas.Medical.Controllers
{
    public class MedicalImageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;

        public MedicalImageController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<MedicalImage> objMedicalImageList = _unitOfWork.MedicalImage.GetAll();
            return View(objMedicalImageList);
        }

        public IActionResult CreateForHistory(string id)
        {

            MedicalHistory medicalHistory = _unitOfWork.MedicalHistory.GetFirstOrDefault(x => x.UserId == id, null,
                includeProperties: "Images");

            

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MedicalImage obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MedicalImage.Add(obj);
                _unitOfWork.Save();
            }
            TempData["success"] = "Medical Image created succesfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MedicalImage obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.MedicalImage.Update(obj);
                _unitOfWork.Save();
            }

            TempData["success"] = "Medical Image edited succesfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _unitOfWork.MedicalImage.GetFirstOrDefault(x => x.Id == id, null);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Delete(int? id)
        {
            var medicalImage = _unitOfWork.MedicalImage.GetFirstOrDefault(x => x.Id == id, null);

            if (medicalImage == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.MedicalImage.Remove(medicalImage);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
            //return RedirectToAction("Index");
        }


        #region API

        public IActionResult GetAll()
        {
            var medicalImage = _unitOfWork.MedicalImage.GetAll();
            return Json(new { data = medicalImage, success = true });
        }

        public IActionResult Get(string id)
        {
            MedicalHistory medicalHistory = _unitOfWork.MedicalHistory.GetFirstOrDefault(x => x.UserId == id, null,
                includeProperties: "Images");

            List<MedicalImage> images = new List<MedicalImage>();

            for (int j = 0; j < medicalHistory.MedicalImages.Count(); j++)
            {
                var aux = medicalHistory.MedicalImages.ElementAt(j);
                MedicalImage image = _unitOfWork.MedicalImage.GetFirstOrDefault(u => u.MedicalHistoryId == aux.MedicalHistoryId, x => x.Id == aux.Id, includeProperties: "Images");
                images.Add(image);
            }

            return Json(new { data = images, success = true });
        }
        #endregion
    }
}
