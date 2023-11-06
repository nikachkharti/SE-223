using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Entities
{
    public class UserLoginModel
    {
        [Required]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DisplayName("Remember Me?")]
        public bool RememberMe { get; set; }

    }
}
