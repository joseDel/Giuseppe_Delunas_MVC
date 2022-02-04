using Ristorante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        //Funzionalità Piatti
        public List<Piatto> GetAllPiatti();
        public Esito AggiungiPiatto(Piatto p);
        public Esito ModificaPiatto(int id, decimal prezzo);
        public Esito EliminaPiatto(int id);

        //Funzionalità Menu
        public List<Menu> GetAllMenu();
        public Esito AggiungiMenu(Menu m);
        public Esito ModificaMenu(int id, string nome);
        public Esito EliminaMenu(int id);

        // Utenti
        public Utente GetAccount(string username);
    }
}
