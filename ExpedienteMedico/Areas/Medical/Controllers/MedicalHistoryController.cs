
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Windows;
using ExpedienteMedico.Models;
using ExpedienteMedico.Models.IntermediateTables;
using ExpedienteMedico.Models.ViewModels;
using ExpedienteMedico.Repository.IRepository;
using ExpedienteMedico.Utility;
using Microsoft.AspNetCore.Authorization;

namespace ExpedienteMedico.Areas.Medical.Controllers
{

    [Area("Medical")]
    [Authorize(Roles = Roles.Role_Admin + "," + Roles.Role_Physician)]

    public class MedicalHistoryController : Controller
    {

        #region HTTP GET POST

        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;

        public MedicalHistoryController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        //GET ********************************
        public IActionResult Upsert(string? id)  //ID of user
        {

            MedicalHistory medicalHistory = _unitOfWork.MedicalHistory.GetFirstOrDefault(x => x.UserId == id, null,
                includeProperties: "User,MedicalHistoryTreatments,MedicalHistorySufferings,MedicalHistoryMedicines,MedicalImages,MedicalNotes");

            if (medicalHistory == null)
            {
                medicalHistory = new MedicalHistory(id);
                _unitOfWork.MedicalHistory.Add(medicalHistory);
                _unitOfWork.Save();
            }

            //Añadiendo los objetos de datos del expediente medico del paciente

            if (medicalHistory.MedicalHistoryTreatments != null)
            {
                for (int j = 0; j < medicalHistory.MedicalHistoryTreatments.Count(); j++)
                {
                    var aux = medicalHistory.MedicalHistoryTreatments.ElementAt(j);
                    var physicianSpecialty = _unitOfWork.HistoryTreatment.GetFirstOrDefault(u => u.MedicalHistoryId == aux.MedicalHistoryId, x => x.TreatmentId == aux.TreatmentId, includeProperties: "Treatments");
                }
            }

            if (medicalHistory.MedicalHistorySufferings != null)
            {
                for (int j = 0; j < medicalHistory.MedicalHistorySufferings.Count(); j++)
                {
                    var aux = medicalHistory.MedicalHistorySufferings.ElementAt(j);
                    var physicianSpecialty = _unitOfWork.HistorySuffering.GetFirstOrDefault(u => u.MedicalHistoryId == aux.MedicalHistoryId, x => x.SufferingId == aux.SufferingId, includeProperties: "Sufferings");
                }
            }

            if (medicalHistory.MedicalHistoryMedicines != null)
            {
                for (int j = 0; j < medicalHistory.MedicalHistoryMedicines.Count(); j++)
                {
                    var aux = medicalHistory.MedicalHistoryMedicines.ElementAt(j);
                    var physicianSpecialty = _unitOfWork.HistoryMedicine.GetFirstOrDefault(u => u.MedicalHistoryId == aux.MedicalHistoryId, x => x.MedicineId == aux.MedicineId, includeProperties: "Medicines");
                }
            }


            return View(medicalHistory);

        }

        //POST **********************************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MedicalHistory obj, IFormFile? file)
        {
            bool IsGetted = false;
            if (ModelState.IsValid)
            {

                #region imageManage
                //string wwwRootPath = _hostEnvironment.WebRootPath;

                //if (file != null)
                //{
                //    string fileName = Guid.NewGuid().ToString();
                //    var uploads = Path.Combine(wwwRootPath, @"images\Physicians");
                //    var extension = Path.GetExtension(file.FileName);

                //    if (obj.Physician.PicturePath != null)
                //    {
                //        var oldImageUrl = Path.Combine(wwwRootPath, obj.Physician.PicturePath);
                //        if (System.IO.File.Exists(oldImageUrl))
                //        {
                //            System.IO.File.Delete(oldImageUrl);
                //        }
                //    }

                //    using (var fileStreams =
                //           new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                //    {
                //        file.CopyTo(fileStreams);
                //    }

                //    obj.Physician.PicturePath = @"images\Physicians\" + fileName + extension;
                //}

                #endregion

                //var Physician = obj.Physician;

                //if (obj.Physician.Id == 0)
                //{
                //    _unitOfWork.Physician.Add(obj.Physician);
                //    _unitOfWork.Save();
                //    IsGetted = true;
                //    Physician = _unitOfWork.Physician.GetLast();
                //}

                #region specialtiesManage


                //foreach (var selectedSpecialty in obj.Specialties.Where(c => c.IsSelected))
                //{
                //    var specialty = new Specialty { Id = selectedSpecialty.SpecialtyId, Name = selectedSpecialty.Name };

                //    var physicianSpecialty = new PhysicianSpecialty
                //    {
                //        PhysicianId = Physician.Id,
                //        SpecialtyId = specialty.Id
                //    };

                //    var physicianSpecialtyAux = _unitOfWork.PhysicianSpecialty.GetFirstOrDefault(
                //        u => u.SpecialtyId == selectedSpecialty.SpecialtyId, x => x.PhysicianId == Physician.Id);
                //    if (physicianSpecialtyAux == null)
                //    {
                //        Physician.PhysicianSpecialties.Add(physicianSpecialty);
                //        _unitOfWork.Physician.Add(Physician);
                //    }
                //}

                //foreach (var selectedSpecialty in obj.Specialties.Where(c => !c.IsSelected))
                //{
                //    var physicianSpecialtyAux = _unitOfWork.PhysicianSpecialty.GetFirstOrDefault(
                //        u => u.SpecialtyId == selectedSpecialty.SpecialtyId, x => x.PhysicianId == Physician.Id);
                //    if (physicianSpecialtyAux != null)
                //    {
                //        _unitOfWork.PhysicianSpecialty.Remove(physicianSpecialtyAux);
                //    }

                //}

                #endregion

                //_unitOfWork.Physician.Update(Physician);
                //if (!IsGetted)
                //    TempData["success"] = "Physician updated successfully";
                //else
                //    TempData["success"] = "Physician saved successfully";

                //_unitOfWork.Save();

            }
            return Redirect("/User/User/Index");
        }

        #endregion

        #region API

        public IActionResult GetHistory(string? id)
        {
            MedicalHistory medicalHistory = _unitOfWork.MedicalHistory.GetFirstOrDefault(x => x.UserId == id, null,
                includeProperties: "User,MedicalHistoryTreatments,MedicalHistorySufferings,MedicalHistoryMedicines,MedicalImages,MedicalNotes");

            if (medicalHistory == null)
            {
                medicalHistory = new MedicalHistory(id);
                _unitOfWork.MedicalHistory.Add(medicalHistory);
                _unitOfWork.Save();
            }

            //Añadiendo los objetos de datos del expediente medico del paciente

            if (medicalHistory.MedicalHistoryTreatments != null)
            {
                for (int j = 0; j < medicalHistory.MedicalHistoryTreatments.Count(); j++)
                {
                    var aux = medicalHistory.MedicalHistoryTreatments.ElementAt(j);
                    var physicianSpecialty = _unitOfWork.HistoryTreatment.GetFirstOrDefault(u => u.MedicalHistoryId == aux.MedicalHistoryId, x => x.TreatmentId == aux.TreatmentId, includeProperties: "Treatments");
                }
            }

            if (medicalHistory.MedicalHistorySufferings != null)
            {
                for (int j = 0; j < medicalHistory.MedicalHistorySufferings.Count(); j++)
                {
                    var aux = medicalHistory.MedicalHistorySufferings.ElementAt(j);
                    var physicianSpecialty = _unitOfWork.HistorySuffering.GetFirstOrDefault(u => u.MedicalHistoryId == aux.MedicalHistoryId, x => x.SufferingId == aux.SufferingId, includeProperties: "Sufferings");
                }
            }

            if (medicalHistory.MedicalHistoryMedicines != null)
            {
                for (int j = 0; j < medicalHistory.MedicalHistoryMedicines.Count(); j++)
                {
                    var aux = medicalHistory.MedicalHistoryMedicines.ElementAt(j);
                    var physicianSpecialty = _unitOfWork.HistoryMedicine.GetFirstOrDefault(u => u.MedicalHistoryId == aux.MedicalHistoryId, x => x.MedicineId == aux.MedicineId, includeProperties: "Medicines");
                }
            }

            return Json(new { data = medicalHistory, success = true });
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
