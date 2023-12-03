using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Repository;

namespace VladPC.DAL.RepositoryPgs
{
    public class DbReposPgs : IDbRepos
    {
        private CompContext db;
        private ProductRepositoryPgs ProductRepository;
        private CompanyRepositoryPgs CompanyRepository;
        private TypeProductRepositoryPgs TypeProductRepository;

        public DbReposPgs()
        {
            db = new CompContext();
        }

        public IRepository<Product> Product
        {
            get
            {
                if (ProductRepository == null)
                    ProductRepository = new ProductRepositoryPgs(db);
                return ProductRepository;
            }
        }

        public IRepository<Company> Company
        {
            get
            {
                if (CompanyRepository == null)
                    CompanyRepository = new CompanyRepositoryPgs(db);
                return CompanyRepository;
            }
        }
        
        public IRepository<TypeProduct> TypeProduct
        {
            get
            {
                if (TypeProductRepository == null)
                    TypeProductRepository = new TypeProductRepositoryPgs(db);
                return TypeProductRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
