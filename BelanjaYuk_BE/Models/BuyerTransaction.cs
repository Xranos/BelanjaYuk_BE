using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelanjaYuk_BE.Models
{
    [Table("TrBuyerTransaction")]
    public class BuyerTransaction
    {
        [Key]
        [Column("IdBuyerTransaction")]
        [StringLength(36)]
        public string IdBuyerTransaction { get; set; } = default!;

        [StringLength(36)]
        public string? IdUser { get; set; }

        [StringLength(36)]
        public string? IdPayment { get; set; }

        public decimal? FinalPrice { get; set; }

        public int? Rating { get; set; }

        [StringLength(1000)]
        public string? RatingComment { get; set; }

        public DateTime? DateIn { get; set; }
        public DateTime? DateUp { get; set; }

        [StringLength(36)]
        public string? UserIn { get; set; }

        [StringLength(36)]
        public string? UserUp { get; set; }

        public bool? IsActive { get; set; }

        [ForeignKey(nameof(IdUser))]
        public User? User { get; set; }

        [ForeignKey(nameof(IdPayment))]
        public PaymentMethod? PaymentMethod { get; set; }

        public ICollection<BuyerTransactionDetail> Details { get; set; }
    }
}