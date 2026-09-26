using Microsoft.EntityFrameworkCore;
using evidencijaRVS.Evidencija.BLL.Interfaces;
using evidencijaRVS.Evidencija.DAL;
using evidencijaRVS.Evidencija.DAL.Models;


namespace evidencijaRVS.Evidencija.BLL.Servicess
{
    public class KorisnikService : korisnikiservice
    {
        private readonly EvidencijaDBcontext _context;
        public KorisnikService(EvidencijaDBcontext context)
        {
            _context = context;
        }

        public async Task<Korisnik> ValidateKorisnikAsync(string email, string lozinka)
        {
            var kroisnik = await _context.Korisnici.FirstOrDefaultAsync(k => k.email == email && k.lozinka == lozinka);
            if (kroisnik == null) {
                return null;
            }
            return kroisnik;

        }

        public async Task<Korisnik> CreateKorisnikAsync(Korisnik korisnik)
        {
            var postojecikorisnik = await _context.Korisnici.FirstOrDefaultAsync(k => k.email == korisnik.email);
            if (postojecikorisnik != null)
            {
                throw new Exception("Korisnik sa ovim emailom već postoji.");
            }

            await _context.Korisnici.AddAsync(korisnik);
            await _context.SaveChangesAsync();
            return korisnik;
        }
}
}
