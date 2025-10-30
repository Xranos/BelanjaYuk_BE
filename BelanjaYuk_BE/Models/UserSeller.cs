using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelanjakYuk_BE.Models
{
    [Table("MsUserSeller")]
    public class UserSeller
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string IdUserSeller { get; set; } = string.Empty;

        [StringLength(36)]
        public string? IdUser { get; set; }

        [StringLength(100)]
        public string? StoreName { get; set; }

        [StringLength(200)]
        public string? SellerDesc { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        [StringLength(50)]
        public string? PhoneNumber { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        public DateTime? DateIn { get; set; }

        public DateTime? DateUp { get; set; }

        [StringLength(36)]
        public string? UserIn { get; set; }

        [StringLength(36)]
        public string? UserUp { get; set; }

        public bool? IsActive { get; set; }

        [ForeignKey("IdUser")]
        public User? User { get; set; }
    }
}