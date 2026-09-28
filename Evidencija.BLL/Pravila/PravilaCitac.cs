using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Evidencija.BLL.Pravila
{
    public class PravilaCitac
    {
        private readonly string _putanja;
        public PravilaCitac(string putanja)
        {
            _putanja = putanja;
        }
        public Medicinskipregledi Ucitaj()
        {
            var tekst = File.ReadAllText(_putanja);
            var parametri = JsonSerializer.Deserialize<Medicinskipregledi>(tekst);

            if (parametri == null || parametri.Temperatura <= 0 || string.IsNullOrWhiteSpace(parametri.PrioritetHitnosti))
            {
                throw new InvalidOperationException("Poslovno_praviloparametri.json nije ispravno popunjen");
            }
            return parametri;
        }
    }
}
