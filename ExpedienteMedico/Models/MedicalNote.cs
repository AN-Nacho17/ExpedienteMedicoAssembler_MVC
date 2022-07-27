using System.ComponentModel.DataAnnotations;

namespace ExpedienteMedico.Models
{
    public class MedicalNote
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Note { get; set; }

        [Required]
        public DateTime NoteDate { get; set; }

        [Required]
        public int PhysicianId { get; set; }

        public Physician Physician { get; set; }

        [Required]
        public string MedicalHistoryId { get; set; }

    }
}
