using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evidencijaRVS.Evidencija.DAL;
using evidencijaRVS.Evidencija.DAL.Models;

namespace Evidencija.DAL.Repozitorijumi
{
    public class KorisnikRepozitorijum : BazniRepozitorijum<Korisnik>
    {
        public KorisnikRepozitorijum(EvidencijaDBcontext baza) : base(baza) { }

        public Korisnik DobaviPoEmailu(string email)
        {
            return _tabela.FirstOrDefault(k => k.email == email);
        }
    }
}
