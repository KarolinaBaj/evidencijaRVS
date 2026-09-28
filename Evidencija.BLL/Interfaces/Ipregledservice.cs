using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evidencijaRVS.Evidencija.DAL.Models;
using evidencijaRVS.Evidencija.DAL;

namespace Evidencija.BLL.Interfaces
{
    public interface Ipregledservice
    {
        List<Pregled> DobaviSve();
        List<Pregled> Filtriraj(DateTime? datumod, DateTime? datumdo, bool? hitanslucaj, string prioritet);
        Pregled DobaviPoID(int id);
        Task kreirajpregled(Pregled pregled);
        void izmeni(Pregled pregled);
        void Obrisi(int id);

    }
}
