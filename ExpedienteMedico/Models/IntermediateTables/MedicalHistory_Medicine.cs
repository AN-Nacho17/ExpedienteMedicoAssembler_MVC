using System.ComponentModel.DataAnnotations;

namespace ExpedienteMedico.Models.IntermediateTables
{
    public class MedicalHistory_Medicine
    {

        [Required]
        public int MedicalHistoricalId { get; set; }

        [Required]
        public int MedicineId { get; set; }

        public Medicine medicine { get; set; }

    }
}
