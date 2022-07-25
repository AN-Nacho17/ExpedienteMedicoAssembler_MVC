using System.ComponentModel.DataAnnotations;

namespace ExpedienteMedico.Models.IntermediateTables
{
    public class MedicalHistory_Medicine
    {

        [Required]
        public string MedicalHistoryId { get; set; }

        public MedicalHistory MedicalHistory { get; set; }

        [Required]
        public int MedicineId { get; set; }

        public Medicine medicine { get; set; }

        [Required]
        public int PhysicianId { get; set; }

        public Physician physician { get; set; }

    }
}
