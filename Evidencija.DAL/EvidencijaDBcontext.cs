using Microsoft.EntityFrameworkCore;
using evidencijaRVS.Evidencija.DAL.Models;


namespace evidencijaRVS.Evidencija.DAL
{
    public class EvidencijaDBcontext : DbContext
    {
        public EvidencijaDBcontext(DbContextOptions<EvidencijaDBcontext> options) : base(options)
        {
        }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<lek> Lekovi { get; set; }
        public DbSet<terapija> Terapije { get; set; }
        public DbSet<anamneza> Anamneze { get; set; }
        public DbSet<Pregled> Pregledi { get; set; }
        public DbSet<zivotinje> Zivotinja { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pregled>()
                .Property(p => p.telesna_temperatura)
                .HasPrecision(4,1);
        }
    }
}
