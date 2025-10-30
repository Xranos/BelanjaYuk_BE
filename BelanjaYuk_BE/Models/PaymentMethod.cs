using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelanjaYuk_BE.Models
{
    [Table("LtPayment")]
    public class PaymentMethod
    {
        [Key]
        [Column("IdPayment")]
        [StringLength(36)]
        public string IdPayment { get; set; } = default!;

        [StringLength(100)]
        public string? PaymentName { get; set; }

        public DateTime? DateIn { get; set; }
        public DateTime? DateUp { get; set; }

        [StringLength(36)]
        public string? UserIn { get; set; }

        [StringLength(36)]
        public string? UserUp { get; set; }

        public bool? IsActive { get; set; }
    }
}