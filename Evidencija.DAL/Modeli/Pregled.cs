using System.ComponentModel.DataAnnotations.Schema; 
using System.ComponentModel.DataAnnotations;

namespace evidencijaRVS.Evidencija.DAL.Models
{
    [Table("pregled")]
    public class Pregled
    {
        [Key]
        [Required]
        [Column("pregled_id")]
        public int pregled_id { get; set; }
        [Required]
        [Column("anamneza_id")]
        public int anamneza_id { get; set; }
        [Required]
        [Column("telesna_temperatura")]
        public decimal telesna_temperatura { get; set; }
        [Required]
        [Column("dijagnoza")]
        public string dijagnoza { get; set; }
        [Required]
        [Column("terapija")]
        public string terapija { get; set; }
        [Required]
        [Column("hitanslucaj")]
        public bool hitanslucaj { get; set; }
        [Required]
        [Column("prioritetpregleda")]
        public string prioritetpregleda { get; set; }
        [Required]
        [Column("datumpregleda")]
        public DateTime datumpregleda { get; set; }

        public List<terapija> Terapije { get; set; } = new List<terapija>();
        [ForeignKey("anamneza_id")]
        public anamneza Anamneza { get; set; }

    }
}
