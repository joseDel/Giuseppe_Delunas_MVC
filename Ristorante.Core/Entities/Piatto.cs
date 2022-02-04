using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.Entities
{
    public class Piatto
    {
        public int IdPiatto { get; set; } 
        public string Nome { get; set; } 
        public string Descrizione { get; set; } 
        public Tipologia Tipologia { get; set; } 
        public decimal Prezzo { get; set; } 

        //FK verso Menu
        public Menu Menu { get; set; }  
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
