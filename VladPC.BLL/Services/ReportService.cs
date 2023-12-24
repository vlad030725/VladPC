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
    public class ReportService : IReportService
    {
        private IDbRepos db;

        public ReportService(IDbRepos db)
        {
            this.db = db;
        }

        public List<ReportAllTransactionsDto> ReportProfit(DateTime stDate, DateTime endDate)
        {
            List<CustomDto> customs = GetAllCustomsExcludeCart();

            List<ProcurementDto> procurements = GetAllProcurementsExcludeInFilling();

            List<ReportAllTransactionsDto> result = new List<ReportAllTransactionsDto>();

            for (int i = 0; i < customs.Count; i++)
            {
                result.Add(new ReportAllTransactionsDto(){
                    Id = customs[i].Id,
                    CreatedDate = (DateTime)customs[i].CreatedDate,
                    TypeTransaction = "Заказ",
                    Sum = (int)customs[i].Sum,
                    UserLogin = GetUserCustom(customs[i].Id).Login
                });
            }

            for (int i = 0; i < procurements.Count; i++)
            {
                result.Add(new ReportAllTransactionsDto()
                {
                    Id = procurements[i].Id,
                    CreatedDate = (DateTime)procurements[i].CreatedDate,
                    TypeTransaction = "Поставка",
                    Sum = -1 * (int)procurements[i].Sum,
                    UserLogin = ""
                });
            }

            result.Where(i => i.CreatedDate >= stDate && i.CreatedDate <= endDate).OrderBy(x => x.CreatedDate).ToList();

            return result;
        }

        private UserDto GetUserCustom(int IdCustom)
        {
            return db.User.GetList().Select(i => new UserDto(i)).Single(i => i.Id == db.Custom.GetItem(IdCustom).IdUser);
        }

        private List<ProcurementDto> GetAllProcurementsExcludeInFilling()
        {
            return db.Procurement.GetList().Select(i => new ProcurementDto(i, GetProcurementRows(i.Id)))
                .Where(i => i.CreatedDate != null).ToList();
        }

        private List<ProcurementRowDto> GetProcurementRows(int IdProcurement)
        {
            return db.ProcurementRow.GetList().Select(i => new ProcurementRowDto(i, GetAllProducts())).Where(i => i.IdProcurement == IdProcurement).ToList();
        }

        private List<CustomDto> GetAllCustomsExcludeCart()
        {
            return db.Custom.GetList()
                .Select(i => new CustomDto(i, GetCustomRowsOneCustom(i.Id)))
                .Where(i => i.CreatedDate != null).ToList();
        }

        private List<CustomRowDto> GetCustomRowsOneCustom(int Id)
        {
            return db.CustomRow.GetList().Select(i => new CustomRowDto(i, GetAllProducts())).Where(i => i.IdCustom == Id).ToList();
        }

        private List<ProductDto> GetAllProducts()
        {
            return db.Product.GetList().Select(i => new ProductDto(i, GetAllCompanies(),
                GetAllTypesProducts(), GetAllSockets(),
                GetAllTypesMemory(), GetAllFormFactors())).ToList();
        }

        private List<CompanyDto> GetAllCompanies()
        {
            return db.Company.GetList().Select(i => new CompanyDto(i)).ToList();
        }

        private List<SocketDto> GetAllSockets()
        {
            return db.Socket.GetList().Select(i => new SocketDto(i)).ToList();
        }

        private List<TypeProductDto> GetAllTypesProducts()
        {
            return db.TypeProduct.GetList().Select(i => new TypeProductDto(i)).ToList();
        }

        private List<TypeMemoryDto> GetAllTypesMemory()
        {
            return db.TypeMemory.GetList().Select(i => new TypeMemoryDto(i)).ToList();
        }

        private List<FormFactorDto> GetAllFormFactors()
        {
            return db.FormFactor.GetList().Select(i => new FormFactorDto(i)).ToList();
        }
    }
}
