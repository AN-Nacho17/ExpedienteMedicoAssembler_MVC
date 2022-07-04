using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ExpedienteMedico.Models
{
    public class User : IdentityUser
    {

        [Required]
        public string UserId { get; set; } //Cedula

        [Required]
        public string CompleteName { get; set; }

    }
}
