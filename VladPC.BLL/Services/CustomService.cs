using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
            Custom customTmp;
            try
            {
                customTmp = db.Custom.GetList().Single(i => i.IdUser == IdUser && i.IdStatus == 1);
            }
            catch
            {
                CreateCustomInCart(IdUser);
                customTmp = db.Custom.GetList().Single(i => i.IdUser == IdUser && i.IdStatus == 1);
            }
            //if (db.Custom.GetList().Single(i => i.IdUser == IdUser && i.IdStatus == 1) == null)
            //{
            //    CreateCustomInCart(IdUser);
            //}
            //Custom customTmp = db.Custom.GetList().Single(i => i.IdUser == IdUser && i.IdStatus == 1);
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

        public void UpdateCustomRow(CustomRowDto row)
        {
            CustomRow cr = db.CustomRow.GetItem(row.Id);
            cr.Price = row.Price;
            cr.Count = row.Count;
            Save();
        }

        public void DeleteCustomRow(int Id)
        {
            CustomRow cr = db.CustomRow.GetItem(Id);
            if (cr != null)
            {
                db.CustomRow.Delete(cr.Id);
                Save();
            }
        }

        public void AddCustomRow(ProductDto pr, int IdUser)
        {
            db.CustomRow.Create(new CustomRow() {
                IdCustom = GetCustomInCart(IdUser).Id,
                IdProduct = pr.Id,
                Price = pr.Price,
                Count = 1
            });
            Save();
        }

        public void MakeCustom(int IdUser)
        {
            CustomDto custom = GetCustomInCart(IdUser);
            custom.IdStatus = 3;

            UpdateCustom(custom);

            CreateCustomInCart(IdUser);
        }

        public void CreateCustomInCart(int IdUser)
        {
            db.Custom.Create(new Custom()
            {
                IdUser = IdUser,
                IdStatus = 1
            });
            Save();
        }

        public void UpdateCustom(CustomDto custom)
        {
            Custom c = db.Custom.GetItem(custom.Id);
            c.IdUser = custom.IdUser;
            c.IdStatus = custom.IdStatus;
            Save();
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }

    }
}
