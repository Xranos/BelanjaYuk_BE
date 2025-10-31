using System.ComponentModel.DataAnnotations;

namespace BelanjaYuk_BE.Models.Requests
{
    public class CreateUserSellerRequest
    {
        public CreateUserSellerRequest()
        {
        }

        [Required]
        public string StoreName { get; set; }

        [Required]
        public string StoreUrl { get; set; }

        public string? PhoneNumber { get; set; }

        [Required]
        public string SellerDesc { get; set; }

        [Required]
        public string Address { get; set;}

        public bool agreement { get; set;}

    }


}
