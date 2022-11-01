using System.ComponentModel.DataAnnotations;

namespace Market.Security.Models
{
    public class ParamUser
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
    }
}
