using System.ComponentModel.DataAnnotations;

namespace BelanjaYuk_BE.Models.Requests
{
    public class LoginRequest
    {
        public LoginRequest()
        {
        }
        [Required]
        public string EmailOrPhone { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
    }
}