using Ristorante.Core.Entities;
using Ristorante.MVC.Models;

namespace Ristorante.MVC.Helper
{
    public static class Mapping
    {
        public static MenuViewModel ToMenuViewModel(this Menu menu)
        {
            List<PiattoViewModel> piattViewModel = new List<PiattoViewModel>();
            foreach (var item in menu.Piatti)
            {
                piattViewModel.Add(item?.ToPiattoViewModel());
            }

            return new MenuViewModel
            {
                IdMenu = menu.IdMenu,   
                Nome = menu.Nome,  
                Piatti = piattViewModel,    
            };
        }

        public static Menu ToMenu(this MenuViewModel menuVM)
        {
            List<Piatto> piatti = new List<Piatto>();
            foreach (var item in menuVM.Piatti)
            {
                piatti.Add(item?.ToPiatto());
            }

            return new Menu
            {
                IdMenu = menuVM.IdMenu,
                Nome = menuVM.Nome,
                Piatti = piatti, 
            };
        }

        public static PiattoViewModel ToPiattoViewModel(this Piatto piatto)
        {
            return new PiattoViewModel
            {
                IdPiatto = piatto.IdPiatto,
                Nome = piatto.Nome,
                Descrizione = piatto.Descrizione,
                Tipologia = (Models.Tipologia)piatto.Tipologia,
                Prezzo = piatto.Prezzo,
                IdMenu = piatto.IdMenu,
            };
        }

        public static Piatto ToPiatto(this PiattoViewModel piattoVM)
        {
            return new Piatto
            {
                IdPiatto = piattoVM.IdPiatto,
                Nome = piattoVM?.Nome,
                Descrizione = piattoVM.Descrizione,
                Tipologia = (Core.Entities.Tipologia)piattoVM.Tipologia,
                Prezzo = piattoVM.Prezzo,
                IdMenu = piattoVM.IdMenu
            };
        }
    }
}
