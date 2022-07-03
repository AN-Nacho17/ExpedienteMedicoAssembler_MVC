using ExpedienteMedico.Models;
using ExpedienteMedico.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpedienteMedico.Controllers
{

    [Area("Admin")]
    public class SpecialtyController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;

        public SpecialtyController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }


        public IActionResult Index()
        {
            IEnumerable<Specialty> objSpecialtyList = _unitOfWork.Specialty.GetAll();
            return View(objSpecialtyList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Specialty obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Specialty.Add(obj);
                _unitOfWork.Save();
            }
            TempData["success"] = "Specialty created succesfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Specialty obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Specialty.Update(obj);
                _unitOfWork.Save();
            }
            TempData["success"] = "Specialty edited succesfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var specialty = _unitOfWork.Specialty.GetFirstOrDefault(x => x.Id == id);
            //var SpecialtyFromDb = _unitOfWork.Categories.FirstOrDefault(x => x.Id == id);

            if (specialty == null)
            {
                return NotFound();
            }

            return View(specialty);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var Specialty = _unitOfWork.Specialty.GetFirstOrDefault(x => x.Id == id);
            //var SpecialtyFromDb = _unitOfWork.Categories.FirstOrDefault(x => x.Id == id);

            if (Specialty == null)
            {
                return NotFound();
            }

            return View(Specialty);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Specialty obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Specialty.Remove(obj);
                _unitOfWork.Save();
            }

            TempData["success"] = "Specialty deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
