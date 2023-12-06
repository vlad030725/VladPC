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

        public List<CustomDto> GetAllCustoms()
        {
            return db.Custom.GetList().Select(i => new CustomDto(i, GetCustomRowsOneCustom(i.Id))).ToList();
        }

        public CustomDto GetCustomInCart(int IdUser)
        {
            Custom customTmp = db.Custom.GetList().Single(i => i.IdUser == IdUser && i.IdStatus == 1);
            return new CustomDto(customTmp, GetCustomRowsOneCustom(customTmp.Id));
        }

        public CustomDto GetCustom(int IdCustom, int IdUser)
        {
            return new CustomDto(db.Custom.GetItem(IdCustom), GetCustomRowsOneCustom(IdCustom));
        }

        public List<CustomRowDto> GetCustomRowsOneCustom(int Id)
        {
            return db.CustomRow.GetList().Select(i => new CustomRowDto(i, GetAllProducts())).Where(i => i.IdCustom == Id).ToList();
        }

        public ProductDto GetProduct(int Id)
        {
            return new ProductDto(db.Product.GetItem(Id), GetAllCompanies(), GetAllTypesProducts(), GetAllSockets());
        }

        //public List<ProductDto> GetProductsOfCustom(int Id)
        //{
        //    List<int> idCustomRows = db.CustomRow.GetList().Where(i => i.IdCustom == Id).Select(i => i.Id).ToList();

        //    List<ProductDto> AllProducts = db.Product.GetList().Select(i => new ProductDto(i, db.Company.GetList().Select(k => new CompanyDto(k)).ToList(), db.TypeProduct.GetList().Select(x => new TypeProductDto(x)).ToList(), db.Socket.GetList().Select(j => new SocketDto(j)).ToList())).ToList();

        //    List<ProductDto> products = new List<ProductDto>();

        //    for (int i = 0; i < AllProducts.Count; i++)
        //    {
        //        if (idCustomRows.Contains(AllProducts[i].Id))
        //        {
        //            products.Add(AllProducts[i]);
        //        }
        //    }

        //    return products;
        //}

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

        public List<ProductDto> GetAllProducts()
        {
            return db.Product.GetList().Select(i => new ProductDto(i, GetAllCompanies(), GetAllTypesProducts(), GetAllSockets())).ToList();
        }

        public List<StatusDto> GetAllStatuses()
        {
            return db.Status.GetList().Select(i => new StatusDto(i)).ToList();
        }
    }
}
