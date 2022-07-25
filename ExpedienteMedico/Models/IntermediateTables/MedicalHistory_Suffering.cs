using System.ComponentModel.DataAnnotations;

namespace ExpedienteMedico.Models.IntermediateTables
{
    public class MedicalHistory_Suffering
    {

        [Required]
        public string MedicalHistoryId { get; set; }

        public MedicalHistory MedicalHistory { get; set; }

        [Required]
        public int SufferingId { get; set; }

        public Suffering suffering { get; set; }

        [Required]
        public int PhysicianId { get; set; }

        public Physician physician { get; set; }
    }
}
