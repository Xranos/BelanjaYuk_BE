using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelanjakYuk_BE.Models
{
    [Table("LtGender")]
    public class Gender
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string IdGender { get; set; } = string.Empty;

        [StringLength(50)]
        public string? GenderName { get; set; }

        public DateTime? DateIn { get; set; }

        [StringLength(36)]
        public string? UserIn { get; set; }

        public DateTime? DateUp { get; set; }

        [StringLength(36)]
        public string? UserUp { get; set; }

        public bool? IsActive { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}