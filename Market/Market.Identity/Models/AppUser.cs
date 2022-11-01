using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Market.Identity.Models;

namespace Market.Identity.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string SecondName { get; set; }

        [Required]
        public DateTime DateOfBith { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string Locality { get; set; }

        [Required]
        public gender Gender { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime EditDate { get; set; }  
    }
}
