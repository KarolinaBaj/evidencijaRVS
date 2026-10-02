using evidencijaRVS.Evidencija.DAL.Models;
using evidencijaRVS.Evidencija.DAL;
using evidencijaRVS.ViewModels;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using evidencijaRVS.Evidencija.DAL;
using evidencijaRVS.Evidencija.DAL.Models;
using evidencijaRVS.ViewModels;
using System;
using System.Linq;

namespace evidencijaRVS.Controllers
{
    public class AnamnezaController : Controller
    {
        private readonly EvidencijaDBcontext _baza;

        public AnamnezaController(EvidencijaDBcontext baza)
        {
            _baza = baza;
        }


        public IActionResult Index(int id)
        {
            var anamneza = _baza.Anamneze.FirstOrDefault(a => a.anamneza_id == id);
            if (anamneza == null)
            {
                return View("Index", null);
            }

            var zivotinja = _baza.Zivotinje.FirstOrDefault(z => z.zivotinja_id == anamneza.zivotinja_id);
            var korisnik = zivotinja != null ? _baza.Korisnici.FirstOrDefault(k => k.korisnik_id == zivotinja.korisnik_id) : null;

            var model = new AnamnezaStampaVM
            {
                Anamneza = anamneza,
                Zivotinja = zivotinja,
                Korisnik = korisnik
            };

            return View(model);
        }


        [HttpGet]
        public IActionResult Dodaj(int zivotinjaId)
        {
            ViewBag.ZivotinjaId = zivotinjaId;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dodaj(anamneza novaAnamneza)
        {
            if (ModelState.IsValid)
            {
                novaAnamneza.datumunosa = DateTime.Now;
                _baza.Anamneze.Add(novaAnamneza);
                _baza.SaveChanges();

                return RedirectToAction("Index", "Pregled");
            }

            ViewBag.ZivotinjaId = novaAnamneza.zivotinja_id;
            return View(novaAnamneza);
        }


        public IActionResult PreuzmiWord(int id)
        {


            return RedirectToAction("Index", new { id = id });
        }

        public IActionResult Stampa(int id)
        {
            var anamneza = _baza.Anamneze.FirstOrDefault(a => a.anamneza_id == id);
            if (anamneza == null) return NotFound();

            var zivotinja = _baza.Zivotinje.FirstOrDefault(z => z.zivotinja_id == anamneza.zivotinja_id);
            var korisnik = zivotinja != null
                ? _baza.Korisnici.FirstOrDefault(k => k.korisnik_id == zivotinja.korisnik_id)
                : null;

            return View(new AnamnezaStampaVM
            {
                Anamneza = anamneza,
                Zivotinja = zivotinja,
                Korisnik = korisnik
            });
        }
    }
}