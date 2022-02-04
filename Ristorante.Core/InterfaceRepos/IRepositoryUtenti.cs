using Ristorante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.InterfaceRepos
{
    public interface IRepositoryUtenti : IRepository<Utente>
    {
        Utente GetByUsername(string username);
    }
}
