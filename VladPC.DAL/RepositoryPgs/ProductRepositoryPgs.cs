using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Repository;

namespace VladPC.DAL.RepositoryPgs
{
    public class ProductRepositoryPgs : IRepository<Product>
    {
        private CompContext db;
        public ProductRepositoryPgs(CompContext db)
        {
            this.db = db;
        }
        public void Create(Product item)
        {
            db.Product.Add(item);
        }

        public void Delete(int id)
        {
            Product pr = db.Product.Find(id);
            if (pr != null)
            {
                db.Product.Remove(pr);
            }
        }

        public Product GetItem(int id)
        {
            return db.Product.Find(id);
        }

        public List<Product> GetList()
        {
            return db.Product.ToList();
        }

        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
