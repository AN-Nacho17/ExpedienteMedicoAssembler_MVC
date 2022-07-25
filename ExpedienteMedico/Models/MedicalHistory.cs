using System.ComponentModel.DataAnnotations;
using System.Drawing;
using ExpedienteMedico.Models.IntermediateTables;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ExpedienteMedico.Models
{
    public class MedicalHistory
    {


        [Key]
        public string UserId { get; set; }

        public User User { get; set; }

        [ValidateNever]
        public List<MedicalImage> Images { get; set; }

        [ValidateNever]
        public List<MedicalNote> Notes { get; set; }

        [ValidateNever]
        public List<MedicalHistory_Treatment> Treatments { get; set; }

        [ValidateNever]
        public List<MedicalHistory_Suffering> Sufferings { get; set; }

        [ValidateNever]
        public List<MedicalHistory_Medicine> Medicines { get; set; }


    }
}
