using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelanjaYuk_BE.Models
{
    [Table("LtCategory")]
    public class Category
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string IdCategory { get; set; } = string.Empty;

        [StringLength(100)]
        public string? CategoryName { get; set; }

        public DateTime? DateIn { get; set; }

        public DateTime? DateUp { get; set; }

        [StringLength(36)]
        public string? UserIn { get; set; }

        [StringLength(36)]
        public string? UserUp { get; set; }

        public bool? IsActive { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}