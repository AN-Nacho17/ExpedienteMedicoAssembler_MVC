using System.ComponentModel.DataAnnotations;

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

        [Required]
        public string PicturePath { get; set; }

        [Required]
        public List<Specialty> Specialties { get; set; }




    }
}
