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
        public int MedicalHistoryId { get; set; }

        public MedicalHistory MedicalHistory { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

    }
}
