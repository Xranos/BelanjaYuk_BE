using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelanjakYuk_BE.Models
{
    [Table("MsProduct")]
    public class Product
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string IdProduct { get; set; } = string.Empty;

        [StringLength(36)]
        public string? IdUserSeller { get; set; }

        [StringLength(100)]
        public string? ProductName { get; set; }

        [StringLength(2000)]
        public string? ProductDesc { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Discount { get; set; }

        [StringLength(36)]
        public string? IdCategory { get; set; }

        public DateTime? DateIn { get; set; }

        public DateTime? DateUp { get; set; }

        [StringLength(36)]
        public string? UserIn { get; set; }

        [StringLength(36)]
        public string? UserUp { get; set; }

        public bool? IsActive { get; set; }

        [ForeignKey("IdUserSeller")]
        public UserSeller? UserSeller { get; set; }

        [ForeignKey("IdCategory")]
        public Category? Category { get; set; }
    }
}