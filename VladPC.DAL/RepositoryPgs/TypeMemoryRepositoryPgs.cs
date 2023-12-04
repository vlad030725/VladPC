using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Repository;

namespace VladPC.DAL.RepositoryPgs
{
    public class TypeMemoryRepositoryPgs : IRepository<TypeMemory>
    {
        private CompContext db;
        public TypeMemoryRepositoryPgs(CompContext db)
        {
            this.db = db;
        }
        public void Create(TypeMemory item)
        {
            db.TypeMemory.Add(item);
        }

        public void Delete(int id)
        {
            TypeMemory tm = db.TypeMemory.Find(id);
            if (tm != null)
            {
                db.TypeMemory.Remove(tm);
            }
        }

        public TypeMemory GetItem(int id)
        {
            return db.TypeMemory.Find(id);
        }

        public List<TypeMemory> GetList()
        {
            return db.TypeMemory.ToList();
        }

        public void Update(TypeMemory item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
