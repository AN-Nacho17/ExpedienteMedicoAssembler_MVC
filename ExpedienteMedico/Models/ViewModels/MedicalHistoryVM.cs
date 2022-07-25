using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ExpedienteMedico.Models.ViewModels
{
    public class MedicalHistoryVM
    {
        [ValidateNever]
        public MedicalHistory MedicalHistory { get; set; }

        [ValidateNever]
        public List<MedicalImage> Images { get; set; }

        [ValidateNever]
        public List<MedicalNote> Notes { get; set; }

        [ValidateNever]
        public List<Suffering> Sufferings { get; set; }

        [ValidateNever]
        public List<Treatment> Treatments { get; set; }

        [ValidateNever]
        public List<Medicine> Medicines { get; set; }

    }
}
