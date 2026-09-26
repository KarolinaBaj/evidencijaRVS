using evidencijaRVS.Evidencija.DAL.Models;

namespace evidencijaRVS.Evidencija.BLL.Interfaces
{
    public interface korisnikiservice
    {
        Task<Korisnik> ValidateKorisnikAsync(string email, string lozinka);
        Task<Korisnik> CreateKorisnikAsync(Korisnik korisnik);
    }
}
