using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evidencijaRVS.Evidencija.DAL.Models
{
    [Table("lek")]
    public class lek
    {
        [Key]
        [Required]
        [Column("lek_id")]
        public int lek_id { get; set; }
        [Required]
        [StringLength(100)]
        [Column("nazivleka")]
        public string nazivleka { get; set; }
        [Required]
        [StringLength(int.MaxValue)]
        [Column("opis")]
        public string opis { get; set; }
        [Required]
        [Column("doza")]
        public string doza { get; set; }

    }
}
