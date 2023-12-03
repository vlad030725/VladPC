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
    public class TypeProductService : ITypeProductService
    {
        private IDbRepos db;

        public TypeProductService(IDbRepos db)
        {
            this.db = db;
        }

        public List<TypeProductDto> GetAllTypesProducts()
        {
            return db.TypeProduct.GetList().Select(i => new TypeProductDto(i)).ToList();
        }
    }
}
