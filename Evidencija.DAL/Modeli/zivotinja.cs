using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evidencijaRVS.Evidencija.DAL.Models
{
    [Table("zivotinje")]
    public class zivotinja
    {
        [Key]
        [Required]
        [Column("zivotinja_id")]
        public int zivotinja_id { get; set; }
        [Required]
        [Column ("korisnik_id")]
        [ForeignKey("korisnik_id")]
        public int korisnik_id { get; set; }
        [Required]
        [StringLength(50)]
        [Column("ime")]
        public string ime { get; set; }
        [Required]
        [StringLength(100)]
        [Column("vrsta")]
        public string vrsta { get; set; }
        [Required]
        [Column("starost")]
        public int starost { get; set; }
        [Required]
        [StringLength(15)]
        [Column("pol")]
        public string pol { get; set; }
        [Required]
        [StringLength(50)]
        [Column("status")]
        public string status { get; set; }
        [Required]
        [StringLength(50)]
        [Column("namena")]
        public string namena { get; set; }

    }
}
