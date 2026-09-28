using Microsoft.EntityFrameworkCore;
using evidencijaRVS.Evidencija.BLL.Interfaces;
using evidencijaRVS.Evidencija.DAL;
using evidencijaRVS.Evidencija.DAL.Models;
using Evidencija.DAL.Repozitorijumi;


namespace evidencijaRVS.Evidencija.BLL.Servicess
{
    public class KorisnikService : korisnikiservice
    {
        private readonly KorisnikRepozitorijum _repo;

        public KorisnikService(KorisnikRepozitorijum repo)
        {
            _repo = repo;
        }
        
      

        public Task<Korisnik> ValidateKorisnikAsync(string email, string lozinka)
        {
            var korisnik = _repo.DobaviPoEmailu(email);
            if (korisnik == null || korisnik.lozinka != lozinka)
            {
                return Task.FromResult<Korisnik>(null);
            }
            return Task.FromResult(korisnik);

        }

        public Task <Korisnik> CreateKorisnikAsync(Korisnik korisnik)
        {
            if (_repo.DobaviPoEmailu(korisnik.email) != null)
                throw new Exception("Korisnik s ovom email adresom vec postoji");

            _repo.Dodaj(korisnik);
            return Task.FromResult(korisnik);
        }

       


    
}
}
