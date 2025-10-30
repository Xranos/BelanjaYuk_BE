
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelanjakYuk_BE.Models
{

    [Table("MsUser")]
    public class User
    {
        public User()
        {
        }

        [Key]
        [Required]
        [StringLength(36)]
        public string IdUser { get; set; }

        [StringLength(100)]
        public string? UserName { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? PhoneNumber { get; set; }

        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(200)]
        public string? LastName { get; set; }

        public DateTime? DOB { get; set; }

        public DateTime? DateIn { get; set; }

        [StringLength(36)]
        public string? UserIn { get; set; }

        public DateTime? DateUp { get; set; }

        [StringLength(36)]
        public string? UserUp { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(36)]
        public string? IdGender { get; set; }

        [ForeignKey("IdGender")]
        public Gender? Gender { get; set; }



    }
}
