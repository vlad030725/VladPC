using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.Interfaces;
using VladPC.BLL.Services;

namespace VladPC.Util.Ninject
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductService>();
            Bind<ICompanyService>().To<CompanyService>();
            Bind<ITypeProductService>().To<TypeProductService>();
        }
    }
}
