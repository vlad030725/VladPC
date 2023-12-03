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
    public class CompanyService : ICompanyService
    {
        private IDbRepos db;

        public CompanyService(IDbRepos db)
        {
            this.db = db;
        }

        public List<CompanyDto> GetAllCompanies()
        {
            return db.Company.GetList().Select(i => new CompanyDto(i)).ToList();
        }
    }
}
