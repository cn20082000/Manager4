using Manager4.util.enu;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manager4.data.entity
{
    [Table("prescription")]
    public class PrescriptionEntity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("eyewear")]
        [Required]
        public EyewearEnum Eyewear { get; set; }

        [Column("note")]
        public string Note { get; set; }

        [Column("reexam")]
        public int ReExam { get; set; }

        [Column("time", TypeName = "datetime2")]
        [Required]
        public DateTime Time { get; set; }

        [Column("payment")]
        [Required]
        public float Payment { get; set; }

        [Column("keyword")]
        [Required]
        public string Key { get; set; }


        [Column("oldreport")]
        public virtual ReportEntity OldReport { get; set; }

        [Column("newreport")]
        public virtual ReportEntity NewReport { get; set; }

        [Column("user")]
        public virtual UserEntity User { get; set; }

        [Column("customer")]
        public virtual CustomerEntity Customer { get; set; }
    }
}
