using System.ComponentModel.DataAnnotations;

namespace keepr_secret.Models
{
    public class RegisterUserModel
    {
        [MaxLength(20)]
        public string Username { get; set; }
        [MaxLength(255), EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(4)]
        public string Password { get; set; }
    }
}