using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;
using VladPC.BLL.Interfaces;
using VladPC.DAL.Repository;

namespace VladPC.BLL.Services
{
    public class ProductService : IProductService
    {
        private IDbRepos db;

        public ProductService(IDbRepos db)
        {
            this.db = db;
        }

        public List<ProductDto> GetAllProducts(ICompanyService companyService, ITypeProductService typeProductService, ISocketService socketService)
        {
            return db.Product.GetList().Select(i => new ProductDto(i, companyService.GetAllCompanies(), typeProductService.GetAllTypesProducts(), socketService.GetAllSockets())).ToList();
        }
    }
}
