using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelanjaYuk_BE.Models
{
    [Table("TrBuyerCart")]
    public class BuyerCart
    {
        [Key]
        [Column("IdBuyerCart")]
        [StringLength(36)]
        public string IdBuyerCart { get; set; } = default!;

        [StringLength(36)]
        public string? IdUser { get; set; }

        [StringLength(36)]
        public string? IdProduct { get; set; }

        public int? Qty { get; set; }

        public DateTime? DateIn { get; set; }
        public DateTime? DateUp { get; set; }

        [StringLength(36)]
        public string? UserIn { get; set; }

        [StringLength(36)]
        public string? UserUp { get; set; }

        public bool? IsActive { get; set; }

        [ForeignKey(nameof(IdUser))]
        public User? User { get; set; }

        [ForeignKey(nameof(IdProduct))]
        public Product? Product { get; set; }
    }
}