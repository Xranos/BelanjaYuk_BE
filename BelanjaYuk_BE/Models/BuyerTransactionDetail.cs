using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelanjakYuk_BE.Models
{
    [Table("TrBuyerTransactionDetail")]
    public class BuyerTransactionDetail
    {
        [Key]
        [Column("IdBuyerTransactionDetail")]
        [StringLength(36)]
        public string IdBuyerTransactionDetail { get; set; } = default!;

        [StringLength(36)]
        public string? IdBuyerTransaction { get; set; }

        [StringLength(36)]
        public string? IdProduct { get; set; }

        public int? Qty { get; set; }

        public decimal? PriceOfProduct { get; set; }
        public decimal? DiscountProduct { get; set; }

        public int? Rating { get; set; }

        [StringLength(1000)]
        public string? RatingComment { get; set; }

        [StringLength(36)]
        public string? UserIn { get; set; }

        [StringLength(36)]
        public string? UserUp { get; set; }

        public DateTime? DateIn { get; set; }
        public DateTime? DateUp { get; set; }

        public bool? IsActive { get; set; }

        [ForeignKey(nameof(IdBuyerTransaction))]
        public BuyerTransaction? BuyerTransaction { get; set; }

        [ForeignKey(nameof(IdProduct))]
        public Product? Product { get; set; }
    }
}