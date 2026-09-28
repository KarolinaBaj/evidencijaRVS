using evidencijaRVS.Evidencija.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evidencija.DAL.Repozitorijumi
{
    public class BazniRepozitorijum<T> where T : class
    {
        protected readonly EvidencijaDBcontext _baza;
        protected readonly DbSet<T> _tabela;

        public BazniRepozitorijum(EvidencijaDBcontext baza)
        {
            _baza = baza;
            _tabela = baza.Set<T>();
        }

        public virtual List<T> DobaviSve()
        {
            return _tabela.ToList();
        }

        public virtual T DobaviPoID(int id)
        {
            return _tabela.Find(id);
        }

        public virtual void Dodaj(T stavka)
        {
            _tabela.Add(stavka);
            _baza.SaveChanges();
        }

        public virtual void izmeni(T stavka)
        {
            _tabela.Update(stavka);
            _baza.SaveChanges();
        }

        public virtual void Obrisi(int id)
        {
            var pronadjen = _tabela.Find(id);
            if (pronadjen == null) return;

            _tabela.Remove(pronadjen);
            _baza.SaveChanges();
        }
    }
}
