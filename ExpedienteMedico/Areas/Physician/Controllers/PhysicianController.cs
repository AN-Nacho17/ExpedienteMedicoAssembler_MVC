using ExpedienteMedico.Models;
using ExpedienteMedico.Models.ViewModels;
using ExpedienteMedico.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpedienteMedico.Controllers
{

    [Area("Physician")]

    public class PhysicianController : Controller
    {

        #region HTTP GET POST

        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;

        public PhysicianController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }


        public IActionResult Index()
        {
            IEnumerable<Physician> objPhysicianList = _unitOfWork.Physician.GetAll(includeProperties: "Specialties");
            return View(objPhysicianList);
        }

        //GET ********************************
        public IActionResult Upsert(int? id)   //Update + Insert
        {

            PhysicianVM PhysicianVM = new()
            {
                Physician = new(),
                SpecialtyList = _unitOfWork.Specialty.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };


            if (id == null || id <= 0)
            {

                return View(PhysicianVM);
            }
            else
            {
                PhysicianVM.Physician = _unitOfWork.Physician.GetFirstOrDefault(u => u.Id == id, includeProperties: "Specialties");
                return View(PhysicianVM);
            }
        }

        //POST **********************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PhysicianVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {

                string wwwRootPath = _hostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\Physicians");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.Physician.PicturePath != null)
                    {
                        var oldImageUrl = Path.Combine(wwwRootPath, obj.Physician.PicturePath);
                        if (System.IO.File.Exists(oldImageUrl))
                        {
                            System.IO.File.Delete(oldImageUrl);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Physician.PicturePath = @"images\Physicians\" + fileName + extension;
                }
                if (obj.Physician.Id == 0)
                {
                    _unitOfWork.Physician.Add(obj.Physician);
                    TempData["success"] = "Physician saved successfully";
                }
                else
                {
                    _unitOfWork.Physician.Update(obj.Physician);
                    TempData["success"] = "Physician updated successfully";
                }

                _unitOfWork.Save();
            }
            return RedirectToAction("Index");
        }


        #endregion

        #region API

        [HttpGet]
        public IActionResult GetAll()
        {
            var PhysicianList = _unitOfWork.Physician.GetAll(includeProperties: "Specialties");
            return Json(new { data = PhysicianList, success = true });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Physician.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
                return Json(new { success = false, message = "Error thile deleting" });


            var oldImageUrl = Path.Combine(_hostEnvironment.WebRootPath, obj.PicturePath);
            if (System.IO.File.Exists(oldImageUrl))
            {
                System.IO.File.Delete(oldImageUrl);
            }


            _unitOfWork.Physician.Remove(obj);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted Successfully" });

            #endregion

        }
    }
}
