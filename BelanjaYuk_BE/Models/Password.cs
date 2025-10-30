using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelanjakYuk_BE.Models
{
    [Table("MsUserPassword")]
    public class UserPassword
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string IdUserPassword { get; set; } = string.Empty;

        [StringLength(36)]
        public string? IdUser { get; set; }

        [StringLength(200)]
        public string? PasswordHashed { get; set; }

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