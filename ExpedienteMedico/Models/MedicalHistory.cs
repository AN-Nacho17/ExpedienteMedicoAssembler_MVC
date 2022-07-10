using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ExpedienteMedico.Models
{
    public class MedicalHistory
    {

        [Key]
        public int Id { get; set; } 

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [ValidateNever]
        public ICollection<Treatment> Treatments { get; set; }

        [ValidateNever]
        public ICollection<Suffering> Sufferings { get; set; }

        [ValidateNever]
        public ICollection<Medicine> Medicines { get; set; }


    }
}
