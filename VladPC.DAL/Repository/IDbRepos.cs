using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VladPC.DAL.Repository
{
    public interface IDbRepos
    {
        IRepository<Product> Product { get; }
        IRepository<TypeProduct> TypeProduct { get; }
        IRepository<Company> Company { get; }
        IRepository<Socket> Socket { get; }
        int Save();
    }
}
