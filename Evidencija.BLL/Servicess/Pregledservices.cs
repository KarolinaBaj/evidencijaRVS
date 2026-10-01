using evidencijaRVS.Evidencija.BLL.Interfaces;
using evidencijaRVS.Evidencija.DAL.Models;
using evidencijaRVS.Evidencija.DAL;
using Evidencija.DAL.Repozitorijumi;
using Evidencija.BLL.Pravila;
using Evidencija.BLL.Interfaces;


namespace evidencijaRVS.Evidencija.BLL.Servicess
{
    public class Pregledservices : Ipregledservice
    {
        private readonly PregledRepozitorijum _repo;
        private readonly PravilaCitac _pravila;

        public Pregledservices(PregledRepozitorijum repo, PravilaCitac pravila)
        {
            _repo = repo;
            _pravila = pravila;
        }

        public List<Pregled> DobaviSve() => _repo.DobaviSve();
        public List<Pregled> Filtriraj(DateTime? datumod, DateTime? datumdo, bool? hitanslucaj, string prioritet)
            => _repo.Filtriraj(datumod, datumdo, hitanslucaj, prioritet);

        public Pregled DobaviPoID(int id) => _repo.DobaviPoID(id);

        public Task kreirajpregled(Pregled pregled)
        {
            OceniHitnost(pregled);
            _repo.Dodaj(pregled);
            return Task.CompletedTask;
        }

        public void izmeni(Pregled pregled)
        {
            OceniHitnost(pregled);
            _repo.izmeni(pregled);
        }
        public void Obrisi(int id) => _repo.Obrisi(id);

        private void OceniHitnost(Pregled pregled)
        {
            var p = _pravila.Ucitaj();
            if(pregled.telesna_temperatura > p.Temperatura)
            {
                pregled.hitanslucaj = true;
                pregled.prioritetpregleda = p.PrioritetHitnosti;
            }
            else
            {
                pregled.hitanslucaj = false;
                pregled.prioritetpregleda = "Normalan";
            }
        }


    }
}
