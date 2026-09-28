using evidencijaRVS.Evidencija.DAL;
using evidencijaRVS.Evidencija.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidencija.DAL.Repozitorijumi
{
    public class AnamnezaRepozitorijum : BazniRepozitorijum<anamneza>
    {
        public AnamnezaRepozitorijum(EvidencijaDBcontext baza) : base(baza) { }
    }
}
