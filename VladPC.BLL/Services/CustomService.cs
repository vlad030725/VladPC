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
    public class CustomService : ICustomService
    {
        private IDbRepos db;

        public CustomService(IDbRepos db)
        {
            this.db = db;
        }

        public List<ProductDto> GetProductsOfCustom(int Id)
        {
            List<int> idCustomRows = db.CustomRow.GetList().Where(i => i.IdCustom == Id).Select(i => i.Id).ToList();

            List<ProductDto> AllProducts = db.Product.GetList().Select(i => new ProductDto(i, db.Company.GetList().Select(k => new CompanyDto(k)).ToList(), db.TypeProduct.GetList().Select(x => new TypeProductDto(x)).ToList(), db.Socket.GetList().Select(j => new SocketDto(j)).ToList())).ToList();

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
    }
}
