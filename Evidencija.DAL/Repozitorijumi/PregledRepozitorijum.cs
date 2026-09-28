using evidencijaRVS.Evidencija.DAL;
using evidencijaRVS.Evidencija.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidencija.DAL.Repozitorijumi
{
    public class PregledRepozitorijum : BazniRepozitorijum<Pregled>
    {
        public PregledRepozitorijum(EvidencijaDBcontext baza) : base(baza) { }

        public override List<Pregled> DobaviSve()
        {
            return _tabela.Include(p => p.Terapije).ToList();
        }
        public override Pregled DobaviPoID(int id)
        {
            return _tabela.Include("Terapije.Lek").FirstOrDefault(p => p.pregled_id == id);
        }

        public List<Pregled> Filtriraj(DateTime? datumod,DateTime? datumDo, bool? hitaSlucaj,string prioritet)
        {
            var upit = _tabela.Include("Terapije").AsQueryable();

            if (datumod.HasValue)
                upit = upit.Where(p => p.datumpregleda >= datumod.Value);

            if (datumDo.HasValue)
                upit = upit.Where(p => p.datumpregleda <= datumDo.Value);

            if (!hitaSlucaj.HasValue)
                upit = upit.Where(p => p.hitanslucaj == hitaSlucaj.Value);
            if (!string.IsNullOrWhiteSpace(prioritet))
                upit = upit.Where(p => p.prioritetpregleda == prioritet);

            return upit.OrderByDescending(p => p.datumpregleda).ToList();
        }

        public override void Obrisi(int id)
        {
            var pregled = _tabela.Include("Terapije").FirstOrDefault(p => p.pregled_id == id);

            if (pregled == null) return;

            _baza.RemoveRange(pregled.Terapije);
            _tabela.Remove(pregled);
            _baza.SaveChanges();
        }
    }
}
