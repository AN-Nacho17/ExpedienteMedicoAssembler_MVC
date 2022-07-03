using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ExpedienteMedico.Models
{
    public class User : IdentityUser
    {

        [Key]
        public int Id { get; set; } //Cedula

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
