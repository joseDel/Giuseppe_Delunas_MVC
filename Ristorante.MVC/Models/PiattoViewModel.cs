using Ristorante.Core.Entities;

namespace Ristorante.MVC.Models
{
    public class PiattoViewModel
    {
        public int IdPiatto { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Tipologia Tipologia { get; set; }
        public decimal Prezzo { get; set; }

        //FK 
        public MenuViewModel Menu { get; set; }
        public int? IdMenu { get; set; }
    }

    public enum Tipologia
    {
        Primo = 0,
        Secondo = 1,
        Contorno = 2,
        Dolce = 3
    }
}
