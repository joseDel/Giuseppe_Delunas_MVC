using Ristorante.Core.Entities;
using Ristorante.Core.InterfaceRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {

        private readonly IRepositoryPiatti piattiRepo;
        private readonly IRepositoryMenu menuRepo;
        private readonly IRepositoryUtenti utentiRepo;

        public MainBusinessLayer(IRepositoryPiatti piatti, IRepositoryMenu menu, IRepositoryUtenti utenti)
        {
            piattiRepo = piatti;    
            menuRepo = menu;
            utentiRepo = utenti;
        }


        #region Piatto

        public List<Piatto> GetAllPiatti()
        {
            return piattiRepo.GetAll();
        }

        public Esito AggiungiPiatto(Piatto p)
        {
            Piatto piattoPresente = piattiRepo.GetById(p.IdPiatto);
            if (piattoPresente == null)
            {
                piattiRepo.Add(p);
                return new Esito { Messaggio = $"Piatto aggiunto correttamente", IsOk = true };
            }
            return new Esito { Messaggio = $"Impossibile aggiungere il piatto perché esiste già un piatto con quel codice", IsOk = false };
        }

        public Esito EliminaPiatto(int id)
        {
            var piattoPresente = piattiRepo.GetById(id);
            if (piattoPresente == null)
            {
                return new Esito { Messaggio = "Nessun piatto corrispondente al codice inserito", IsOk = false };
            }
            
            piattiRepo.Delete(piattoPresente);
            return new Esito { Messaggio = "Piatto eliminato correttamente", IsOk = true };
        }

        public Esito ModificaPiatto(int id, decimal prezzo)
        {
            var piattoPresente = piattiRepo.GetById(id);
            if (piattoPresente == null)
            {
                return new Esito { Messaggio = "Nessun piatto corrispondente al codice inserito", IsOk = false };
            }

            piattoPresente.Prezzo = prezzo;

            piattiRepo.Update(piattoPresente);
            return new Esito { Messaggio = "Piatto aggiornato correttamente", IsOk = true };
        }

        #endregion Piatto


        #region Menu
        public Esito AggiungiMenu(Menu m)
        {
            Menu menuPresente = menuRepo.GetById(m.IdMenu);
            if (menuPresente == null)
            {
                menuRepo.Add(m);
                return new Esito { Messaggio = $"Menu aggiunto correttamente", IsOk = true };
            }
            return new Esito { Messaggio = $"Impossibile aggiungere il menu perché esiste già un menu con quel codice", IsOk = false };
        }

        

        public Esito EliminaMenu(int id)
        {
            var menuPresente = menuRepo.GetById(id);
            if (menuPresente == null)
            {
                return new Esito { Messaggio = "Nessun menu corrispondente al codice inserito", IsOk = false };
            }

            menuRepo.Delete(menuPresente);
            return new Esito { Messaggio = "Menu eliminato correttamente", IsOk = true };
        }

        

        public List<Menu> GetAllMenu()
        {
            return menuRepo.GetAll();   
        }


        public Esito ModificaMenu(int id, string nome)
        {
            var menuPresente = menuRepo.GetById(id);
            if (menuPresente == null)
            {
                return new Esito { Messaggio = "Nessun menu corrispondente al codice inserito", IsOk = false };
            }

            menuPresente.Nome = nome;

            menuRepo.Update(menuPresente);
            return new Esito { Messaggio = "Menu aggiornato correttamente", IsOk = true };
        }

        #endregion Menu

        #region Utente

        public Utente GetAccount(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            return utentiRepo.GetByUsername(username);
        }

        #endregion Utente
    }
}
