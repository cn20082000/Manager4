using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager4.data.entity
{
    [Table("eye")]
    public class EyeEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("sph")]
        [Required]
        public float Sph { get; set; }

        [Column("cyl")]
        [Required]
        public float Cyl { get; set; }

        [Column("ax")]
        [Required]
        public int Ax { get; set; }

        [Column("add")]
        [Required]
        public float Add { get; set; }

        [Column("va")]
        [Required]
        public int Va { get; set; }

        [Column("fh")]
        [Required]
        public int Fh { get; set; }

        [Column("pd2")]
        [Required]
        public float Pd2 { get; set; }

        [Column("pd")]
        [Required]
        public float Pd { get; set; }
    }
}
