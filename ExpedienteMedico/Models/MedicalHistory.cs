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
        public ICollection<MedicalHistory_Treatment> Treatments { get; set; }

        [ValidateNever]
        public ICollection<MedicalHistory_Suffering> Sufferings { get; set; }

        [ValidateNever]
        public ICollection<MedicalHistory_Medicine> Medicines { get; set; }


    }
}
