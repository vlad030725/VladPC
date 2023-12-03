using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Repository;
using VladPC.DAL.RepositoryPgs;

namespace VladPC.Util.Ninject
{
    public class ReposModule : NinjectModule
    {
        private string connectionString;

        public ReposModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IDbRepos>().To<DbReposPgs>().InSingletonScope().WithConstructorArgument(connectionString);
        }
    }
}
