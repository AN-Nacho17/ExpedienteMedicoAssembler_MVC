using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ExpedienteMedico.Models
{
    public class Physician
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CollegeNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [ValidateNever]
        public string PicturePath { get; set; }

        //[Required]
        public ICollection<PhysicianSpecialty> PhysicianSpecialties { get; set; }

    }
}
