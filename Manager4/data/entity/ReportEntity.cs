using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager4.data.entity
{
    [Table("report")]
    public class ReportEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("time", TypeName = "datetime2")]
        [Required]
        public DateTime Time { get; set; }

        [Column("distance")]
        [Required]
        public bool Distance { get; set; }

        [Column("neutral")]
        [Required]
        public bool Neutral { get; set; }

        [Column("reading")]
        [Required]
        public bool Reading { get; set; }


        [Column("leftEye")]
        //[Required]
        public virtual EyeEntity LeftEye { get; set; }

        [Column("rightEye")]
        //[Required]
        public virtual EyeEntity RightEye { get; set; }
    }
}
