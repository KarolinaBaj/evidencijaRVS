
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace evidencijaRVS.Evidencija.DAL.Models
{
    [Table ("Korisnik")]
    public class Korisnik
    {
        [Key]
        [Required]
        [Column ("korisnik_id")]
        public int korisnik_id { get; set; }
        [Required]
        [StringLength(100)]
        [Column ("ime")]
        public string ime { get; set; }
        [Required]
        [StringLength(100)]
        [Column("prezime")]
        public string prezime { get; set; }
        [Required]
        [StringLength(255)]
        [Column ("lozinka")]
        public string lozinka { get; set; }
        [Required]
        [EmailAddress]
        [Column("email")]
        public string email { get; set; }
        [Required]
        [StringLength(100)]
        [Column("adresa")]
        public string adresa { get; set; }
    }
}
