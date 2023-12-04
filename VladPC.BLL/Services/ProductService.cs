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

        public List<ProductDto> GetAllProducts()
        {
            return db.Product.GetList().Select(i => new ProductDto(i, GetAllCompanies(), GetAllTypesProducts(), GetAllSockets())).ToList();
        }

        public List<ProductDto> GetAllProductsOneCustom(int Id)
        {
            List<int> idCustomRows = db.CustomRow.GetList().Where(i => i.IdCustom == Id).Select(i => i.Id).ToList();

            List<ProductDto> AllProducts = GetAllProducts();

            List<ProductDto> products = new List<ProductDto>();

            for (int i = 0; i < AllProducts.Count; i++)
            {
                if (idCustomRows.Contains(AllProducts[i].Id))
                {
                    products.Add(AllProducts[i]);
                }
            }

            return products;
        }


        public List<CompanyDto> GetAllCompanies()
        {
            return db.Company.GetList().Select(i => new CompanyDto(i)).ToList();
        }

        public List<SocketDto> GetAllSockets()
        {
            return db.Socket.GetList().Select(i => new SocketDto(i)).ToList();
        }

        public List<TypeProductDto> GetAllTypesProducts()
        {
            return db.TypeProduct.GetList().Select(i => new TypeProductDto(i)).ToList();
        }
    }
}
