using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Repository;

namespace VladPC.DAL.RepositoryPgs
{
    public class TypeProductRepositoryPgs : IRepository<TypeProduct>
    {
        private CompContext db;
        public TypeProductRepositoryPgs(CompContext db)
        {
            this.db = db;
        }
        public void Create(TypeProduct item)
        {
            db.TypeProduct.Add(item);
        }

        public void Delete(int id)
        {
            TypeProduct tp = db.TypeProduct.Find(id);
            if (tp != null)
            {
                db.TypeProduct.Remove(tp);
            }
        }

        public TypeProduct GetItem(int id)
        {
            return db.TypeProduct.Find(id);
        }

        public List<TypeProduct> GetList()
        {
            return db.TypeProduct.ToList();
        }

        public void Update(TypeProduct item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
