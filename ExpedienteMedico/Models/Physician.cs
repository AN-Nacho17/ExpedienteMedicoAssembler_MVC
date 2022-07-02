using System.ComponentModel.DataAnnotations;

namespace ExpedienteMedico.Models
{
    public class Physician
    {

        [Required]
        public string Name { get; set; }

        [Key]
        public int CollegeNumber { get; set; }

        [Required]
        public string PicturePath { get; set; }

        [Required]
        public List<Specialty> Specialties { get; set; }




    }
}
