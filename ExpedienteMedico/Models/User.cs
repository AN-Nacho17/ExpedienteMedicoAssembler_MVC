using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders.Physical;

namespace ExpedienteMedico.Models
{
    public class User : IdentityUser
    {

        [Required]
        [StringLength(9)]
        public string UserId { get; set; } //Cedula

        [Required]
        public string CompleteName { get; set; }

        [Required]
        public DateTime LastDateAttended { get; set; }


    }
}
