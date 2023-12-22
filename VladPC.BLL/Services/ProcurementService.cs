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
    public class ProcurementService : IProcurementService
    {
        private IDbRepos db;

        public ProcurementService(IDbRepos db)
        {
            this.db = db;
        }

        public bool IsContainInFillingProcurement(int IdProduct)
        {
            return GetProcurementInFilling().ProcurementRows.Select(i => i.IdProduct).Contains(IdProduct);
        }

        public ProcurementDto GetProcurementInFilling()
        {
            try
            {
                return GetAllProcurements().Single(i => i.CreatedDate == null);
            }
            catch
            {
                db.Procurement.Create(new Procurement());
                Save();
                return GetAllProcurements().Single(i => i.CreatedDate == null);
            }
            
        }

        public List<ProcurementDto> GetAllProcurements()
        {
            return db.Procurement.GetList().Select(i => new ProcurementDto(i, GetProcurementRows(i.Id))).ToList();
        }

        public List<ProcurementRowDto> GetProcurementRows(int IdProcurement)
        {
            return db.ProcurementRow.GetList().Select(i => new ProcurementRowDto(i, GetAllProducts())).ToList();
        }

        public List<ProductDto> GetAllProducts()
        {
            return db.Product.GetList().Select(i => new ProductDto(i, GetAllCompanies(),
                GetAllTypesProducts(), GetAllSockets(),
                GetAllTypesMemory(), GetAllFormFactors())).ToList();
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

        public void AddProcurementRow(ProductDto pr, int count, int price)
        {
            db.ProcurementRow.Create(new ProcurementRow()
            {
                IdProcurement = GetProcurementInFilling().Id,
                IdProduct = pr.Id,
                Price = price,
                Count = count
            });
            Save();
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
