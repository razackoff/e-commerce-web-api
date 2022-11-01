using System.ComponentModel.DataAnnotations;

namespace Market.Security.Models
{
    public class OtherParamUser : ParamUser
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

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
