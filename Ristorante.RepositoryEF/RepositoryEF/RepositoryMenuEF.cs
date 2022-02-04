using Microsoft.EntityFrameworkCore;
using Ristorante.Core.Entities;
using Ristorante.Core.InterfaceRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.RepositoryEF.RepositoryEF
{
    public class RepositoryMenuEF : IRepositoryMenu
    {
        private readonly MasterContext ctx;
        public RepositoryMenuEF(MasterContext context)
        {
            ctx = context;
        }

        public Menu Add(Menu item)
        {
            ctx.Menu.Add(item);
            ctx.SaveChanges();
            return item;
        }

        public bool Delete(Menu item)
        {
            ctx.Menu.Remove(item);
            ctx.SaveChanges();
            return true;
        }

        public List<Menu> GetAll()
        {
            return ctx.Menu.Include(m => m.Piatti).ToList();
        }

        public Menu? GetById(int id)
        {
            return ctx.Menu.Include(m => m.Piatti).FirstOrDefault(m => m.IdMenu == id);
        }

        public Menu Update(Menu item)
        {
            ctx.Menu.Update(item);
            ctx.SaveChanges();
            return item;
        }
    }
}
