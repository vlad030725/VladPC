using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.BLL.DTO;
using VladPC.BLL.Interfaces;
using VladPC.DAL;
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
            return db.Product.GetList().Select(i => new ProductDto(i, GetAllCompanies(), 
                GetAllTypesProducts(), GetAllSockets(), 
                GetAllTypesMemory(), GetAllFormFactors())).ToList();
        }

        public List<ProductDto> GetAllProductsOneCustom(int Id)
        {
            List<CustomRow> CustomRows = db.CustomRow.GetList().Where(i => i.IdCustom == Id).ToList();
            List<int> idCustomRows = CustomRows.Select(i => i.Id).ToList();

            List<ProductDto> AllProducts = GetAllProducts();

            List<ProductDto> products = new List<ProductDto>();

            int j = -1;
            for (int i = 0; i < AllProducts.Count; i++)
            {
                if (idCustomRows.Contains(AllProducts[i].Id))
                {
                    products.Add(AllProducts[i]);
                    j++;
                    for (int k = 0; k < CustomRows.Count; k++)
                    {
                        if (CustomRows[k].IdProduct == products[j].Id)
                        {
                            products[j].Count = CustomRows[k].Count;
                            products[j].Price = CustomRows[k].Price;
                        }
                    }
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

        public List<TypeMemoryDto> GetAllTypesMemory()
        {
            return db.TypeMemory.GetList().Select(i => new TypeMemoryDto(i)).ToList();
        }

        public List<FormFactorDto> GetAllFormFactors()
        {
            return db.FormFactor.GetList().Select(i => new FormFactorDto(i)).ToList();
        }
    }
}
