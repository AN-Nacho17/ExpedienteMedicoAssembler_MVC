
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Windows;
using ExpedienteMedico.Models;
using ExpedienteMedico.Models.ViewModels;
using ExpedienteMedico.Repository.IRepository;

namespace ExpedienteMedico.Areas.Administration.Controllers
{

    [Area("Administration")]

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
            IEnumerable<Physician> objPhysicianList = _unitOfWork.Physician.GetAll(includeProperties: "PhysicianSpecialties");
            return View(objPhysicianList);
        }

        //GET ********************************
        public IActionResult Upsert(int? id)   //Update + Insert
        {
            var physician = new Physician();
            physician.Id = 0;

            var vm = new PhysicianCreateVM()
            {
                Physician = new(),
                Specialties = _unitOfWork.Specialty.GetAll().Select(i => new SpecialtySelectVM()
                {
                    SpecialtyId = i.Id,
                    Name = i.Name,
                    IsSelected = false
                }).ToList()
            };


            if (id == 0 || id == null)
            {
                return View(vm);
            }
            else
            {
                vm.Physician = _unitOfWork.Physician.GetFirstOrDefault(u => u.Id == id, null);
                return View(vm);
            }
        }

        //POST **********************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PhysicianCreateVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {

                #region imageManage
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

                    using (var fileStreams =
                           new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }

                    obj.Physician.PicturePath = @"images\Physicians\" + fileName + extension;
                }

                #endregion

                #region specialtiesManage

                var Physician = obj.Physician;



                foreach (var selectedCompany in obj.Specialties.Where(c => c.IsSelected))
                {
                    var specialty = new Specialty { Id = selectedCompany.SpecialtyId };
                    _unitOfWork.Specialty.Add(specialty);

                    var physicianSpecialty = new PhysicianSpecialty
                    {
                        Specialty = specialty
                    };

                    Physician.PhysicianSpecialties.Add(physicianSpecialty);
                    _unitOfWork.Physician.Add(Physician);
                }
                #endregion

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
            var PhysicianList = _unitOfWork.Physician.GetAll(includeProperties: "PhysicianSpecialties");
            for (int i = 0; i < PhysicianList.Count(); i++)
            {
                var obj = PhysicianList.ElementAt(i);
                for (int j = 0; j < obj.PhysicianSpecialties.Count(); j++)
                {
                    var aux = obj.PhysicianSpecialties.ElementAt(j);
                    var physicianSpecialty = _unitOfWork.PhysicianSpecialty.GetFirstOrDefault(u => u.SpecialtyId == aux.SpecialtyId, x => x.SpecialtyId == aux.SpecialtyId, includeProperties: "Specialty");
                }
            }

            return Json(new { data = PhysicianList, success = true });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Physician.GetFirstOrDefault(x => x.Id == id, null);

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
