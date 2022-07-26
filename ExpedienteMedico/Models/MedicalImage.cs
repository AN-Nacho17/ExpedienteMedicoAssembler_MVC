using System.ComponentModel.DataAnnotations;

namespace ExpedienteMedico.Models
{
    public class MedicalImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string PdfUrl { get; set; }

        [Required]
        public string MedicalHistoryId { get; set; }

        [Required]
        public int PhysicianId { get; set; }

        public Physician Physician { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

    }
}
