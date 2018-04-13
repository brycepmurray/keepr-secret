using System.ComponentModel.DataAnnotations;

namespace keepr_secret.Models
{
    public class RegisterUserPasswordModel
    {
        [MaxLength(20)]
        public int Id { get; set; }
        [MaxLength(255), EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(4)]
        public string OldPassword { get; set; }
    }
}