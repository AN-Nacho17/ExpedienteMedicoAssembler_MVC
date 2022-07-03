using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ExpedienteMedico.Models
{
    public class User : IdentityUser
    {

        [Required]
        public int Id { get; set; } //Cedula

        [Required]
        public string Name { get; set; }

    }
}
