using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6.Academy.CORE.Entities;

namespace Week6.Academy.CORE.Interfaces
{
    public interface IRepositoryUtenti : IRepository<Utente>
    {
        Utente GetAccountByUsername(string username);
    }
}
