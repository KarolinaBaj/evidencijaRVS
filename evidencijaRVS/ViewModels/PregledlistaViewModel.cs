using evidencijaRVS.Evidencija.DAL.Models;

namespace evidencijaRVS.ViewModels
{
    public class PregledlistaViewModel
    {
        public List<Pregled> Pregledi {  get; set; } = new List<Pregled>();

        public DateTime? Datumod { get; set; }
        public DateTime? datumdo { get; set; }
        public bool? hitanslucaj {  get; set; }
        public string Prioritet { get; set; }
    }
}
