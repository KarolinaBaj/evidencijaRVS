using evidencijaRVS.Evidencija.BLL.Interfaces;  
using evidencijaRVS.Evidencija.DAL.Models;
using evidencijaRVS.Evidencija.DAL;

namespace evidencijaRVS.Evidencija.BLL.Servicess
{
    public class Pregledservices : Preglediservice
    {
        private readonly EvidencijaDBcontext _context;

        public Pregledservices(EvidencijaDBcontext context)
        {
            _context = context;
        }

        public async Task kreirajpregled(Pregled pregled)
        {
            OceniHitnost(pregled);
            _context.Pregledi.Add(pregled);
            await _context.SaveChangesAsync();
        }

        private void OceniHitnost(Pregled pregled)
        {
            if (pregled.telesna_temperatura> Medicinskipregledi.Maxnormalnatemperatura)
            {
                pregled.hitanslucaj = true;
                pregled.prioritetpregleda = "Hitno";
            }
            else
            {
                pregled.hitanslucaj = false;
                pregled.prioritetpregleda = "Nije hitno";
            }
        }


    }
}
