using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.IdentityDTOS
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
