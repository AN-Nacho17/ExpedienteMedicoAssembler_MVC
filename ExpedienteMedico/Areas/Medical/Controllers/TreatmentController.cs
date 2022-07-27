﻿using System.Security.Claims;
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
    public class TreatmentController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;
        private UserManager<IdentityUser> _userManager;

        public TreatmentController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            IEnumerable<Treatment> objTreatmentList = _unitOfWork.Treatment.GetAll();
            return View(objTreatmentList);
        }

        public IActionResult CreateForHistory(string id) //User id
        {

            MedicalHistory medicalHistory = _unitOfWork.MedicalHistory.GetFirstOrDefault(x => x.UserId == id, null,
                includeProperties: "MedicalHistoryTreatments");

            TreatmentVM vm = new TreatmentVM();

            vm.HistoryId = medicalHistory.UserId;
            vm.Treatment = null;

            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateForHistory(TreatmentVM vm) //User id
        {
            Treatment savedTreatment = null;
            if (ModelState.IsValid)
            {
                var treatment = new Treatment() {Name = vm.Treatment.Name, Description = vm.Treatment.Description };
                _unitOfWork.Treatment.Add(treatment);
                _unitOfWork.Save();
                savedTreatment = _unitOfWork.Treatment.GetLast();
            }

            int PhysicianId =
                _unitOfWork.Physician.GetByEmail(_userManager.FindByNameAsync(User.Identity.Name).Result.Email).Id;

            var historyTreatment = new MedicalHistory_Treatment()
            {
                MedicalHistoryId = vm.HistoryId,
                TreatmentId = savedTreatment.Id,
                PhysicianId = PhysicianId
            };

            _unitOfWork.HistoryTreatment.Add(historyTreatment);
            _unitOfWork.Save();
            return RedirectToAction("Index");
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

        public IActionResult Get(string id) //User id
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

            return Json(new { data = treatments, success = true });
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
