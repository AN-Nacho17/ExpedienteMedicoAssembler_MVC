using System.ComponentModel.DataAnnotations;

namespace ExpedienteMedico.Models.IntermediateTables
{
    public class MedicalHistory_Suffering
    {

        [Required]
        public int MedicalHistoricalId { get; set; }

        [Required]
        public int SufferingId { get; set; }

        public Suffering suffering { get; set; }
    }
}
