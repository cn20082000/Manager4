using Manager4.util.enu;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager4.data.entity
{
    [Table("user")]
    public class UserEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("birthday", TypeName = "dateTime2")]
        [Required]
        public DateTime Birthday { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("phonenumber")]
        public string PhoneNumber { get; set; }

        [Column("signature")]
        public string Signature { get; set; }

        [Column("username")]
        [Index(IsUnique = true)]
        [Required]
        [StringLength(32)]
        public string Username { get; set; }

        [Column("password")]
        [Required]
        public string Password { get; set; }

        [Column("role")]
        [Required]
        public RoleEnum Role { get; set; }

        [Column("active")]
        [Required]
        public bool Active { get; set; }
    }
}
