using System.ComponentModel.DataAnnotations;

namespace BelanjaYuk_BE.Models.Requests
{
    public class CreateUserRequest
    {
        public CreateUserRequest()
        {
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Password { get; set; }

        public string? IdGender { get; set; }

        public string? Provinsi { get; set; }
        public string? KotaKabupaten { get; set; }
        public string? Kecamatan { get; set; }
        public string? KodePos { get; set; }
        public string? HomeAddressDesc { get; set; }
    }
}
