using System.ComponentModel.DataAnnotations;

namespace ExpedienteMedico.Models.IntermediateTables
{
    public class MedicalHistory_Treatment
    {

        [Required]
        public int MedicalHistoricalId { get; set; }

        [Required]
        public int TreatmentId { get; set; }

        public Treatment treatment { get; set; }

    }
}
