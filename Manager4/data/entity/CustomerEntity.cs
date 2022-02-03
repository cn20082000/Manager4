using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager4.data.entity
{
    [Table("customer")]
    public class CustomerEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("birthday", TypeName = "datetime2")]
        [Required]
        public DateTime Birthday { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("phonenumber")]
        public string PhoneNumber { get; set; }

        [Column("active")]
        [Required]
        public bool Active { get; set; }
    }
}
