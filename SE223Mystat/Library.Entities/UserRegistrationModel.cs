using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Entities
{
    public class UserRegistrationModel
    {
        [Required]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [DisplayName("Confirm Password")]
        public string? ConfirmPassword { get; set; }
    }
}
