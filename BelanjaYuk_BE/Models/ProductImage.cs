using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelanjaYuk_BE.Models
{
    [Table("TrProductImages")]
    public class ProductImage
    {
        [Key]
        [Column("IdProductImages")]
        [StringLength(36)]
        public string IdProductImages { get; set; } = default!;

        [StringLength(36)]
        public string? IdProduct { get; set; }

        // nvarchar(MAX) → string
        public string? ProductImagePath { get; set; }

        public DateTime? DateIn { get; set; }
        public DateTime? DateUp { get; set; }

        [StringLength(36)]
        public string? UserIn { get; set; }

        [StringLength(36)]
        public string? UserUp { get; set; }

        public bool? IsActive { get; set; }

        [ForeignKey(nameof(IdProduct))]
        public Product? Product { get; set; }
    }
}