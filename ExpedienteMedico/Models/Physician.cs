using System.ComponentModel.DataAnnotations;
using ExpedienteMedico.Models.IntermediateTables;
using Microsoft.AspNetCore.Identity;
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
        [EmailAddress]
        public string Email { get; set; }

        public int PhoneNumber { get; set; }


        [ValidateNever]
        public string PicturePath { get; set; }


        [ValidateNever]
        public ICollection<PhysicianSpecialty> PhysicianSpecialties { get; set; }

    }
}
