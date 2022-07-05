using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpedienteMedico.Models
{
    public class Specialty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<PhysicianSpecialty> PhysicianSpecialties { get; set; }

    }
}
