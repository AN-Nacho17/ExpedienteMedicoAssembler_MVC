using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ExpedienteMedico.Models
{
    public class MedicalImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [ValidateNever]
        [Display(Name = "PDF URL")]
        public string PdfUrl { get; set; }

        [Required]
        public string MedicalHistoryId { get; set; }

        [Required]
        public int PhysicianId { get; set; }

        [ValidateNever]
        public Physician Physician { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

    }
}
