using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evidencijaRVS.Evidencija.DAL.Models
{
    [Table("terapija")]
    public class terapija
    {
        [Key]
        [Required]
        [Column("terapija_id")]
        public int terapija_id { get; set; }
        [Required]
        [Column("pregled_id")]
        public int pregled_id { get; set; }
        [Required]
        [Column("lek_id")]
        public int lek_id { get; set; }
        [Required]
        [Column("kolicina")]
        public int kolicina { get; set; }
        [Required]
        [Column("napomena")]
        public string napomena { get; set; }

        [ForeignKey("pregled_id")]
        public Pregled pregled { get; set; }
        [ForeignKey("lek_id")]
        public lek Lek{ get; set; }
    }
}
