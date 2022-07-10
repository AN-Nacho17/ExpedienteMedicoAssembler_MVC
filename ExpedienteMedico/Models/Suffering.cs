using System.ComponentModel.DataAnnotations;

namespace ExpedienteMedico.Models
{
    public class Suffering
    {
       [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]      
        public string Description { get; set; }

    }
}
