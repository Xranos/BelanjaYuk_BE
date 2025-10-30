using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelanjaYuk_BE.Models
{
    [Table("TrHomeAddress")]
    public class HomeAddress
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string IdHomeAddress { get; set; } = string.Empty;

        [StringLength(36)]
        public string? IdUser { get; set; }

        [StringLength(100)]
        public string? Provinsi { get; set; }

        [StringLength(100)]
        public string? KotaKabupaten { get; set; }

        [StringLength(100)]
        public string? Kecamatan { get; set; }

        [StringLength(20)]
        public string? KodePos { get; set; }

        [StringLength(2000)]
        public string? HomeAddressDesc { get; set; }

        public bool? IsPrimaryAddress { get; set; }

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