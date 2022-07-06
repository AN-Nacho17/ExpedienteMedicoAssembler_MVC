using System.ComponentModel.DataAnnotations;

namespace ExpedienteMedico.Models
{

    public class PhysicianSpecialty
    {
        [Required]
        public int PhysicianId { get; set; }

        [Required]
        public int SpecialtyId { get; set; }
        
        public Specialty Specialty { get; set; }



    }
}
