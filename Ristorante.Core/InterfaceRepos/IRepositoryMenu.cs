using Ristorante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.InterfaceRepos
{
    public interface IRepositoryMenu : IRepository<Menu>
    {
        public Menu GetById(int id);
    }
}
