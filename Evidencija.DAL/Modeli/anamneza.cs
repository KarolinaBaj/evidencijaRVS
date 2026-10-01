using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace evidencijaRVS.Evidencija.DAL.Models
{
    [Table("anamneza")]
    public class anamneza
    {
        [Key]
        [Required]
        [Column("anamneza_id")]
        public int anamneza_id { get; set; }
        [Required]
        [Column("zivotinja_id")]
        
        public int zivotinja_id { get; set; }
        [Required]
        [StringLength(int.MaxValue)]
        [Column("Razlogdolaska")]
        public string Razlogdolaska { get; set; }
        [Required]
        [StringLength(int.MaxValue)]
        [Column("ishrana")]
        public string ishrana { get; set; }
        [Required]
        [StringLength(int.MaxValue)]
        [Column("Urinistolica")]
        public string Urinistolica { get; set; }
        [Required]
        [StringLength(int.MaxValue)]
        [Column("Smestaj")]
        public string Smestaj { get; set; }
        [Required]
        
        [Column("Primaolekove")]
        public bool Primaolekove { get; set; }
        [Required]
        [StringLength(int.MaxValue)]
        [Column("kojelekove")]
        public string kojelekove { get; set; }
        [Required]
        [StringLength(int.MaxValue)]
        [Column("ranijebolovala")]
        public string ranijebolovala { get; set; }
        [Required]
        [Column("datumunosa")]
        public DateTime datumunosa { get; set; }
        
        [ForeignKey("zivotinja_id")]
        public zivotinje zivotinje{ get; set; }
       
        public ICollection<Pregled> Pregledi { get; set; } = new List<Pregled>();
    }
}
