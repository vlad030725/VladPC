using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Repository;

namespace VladPC.DAL.RepositoryPgs
{
    public class UserRepositoryPgs : IRepository<User>
    {
        private CompContext db;
        public UserRepositoryPgs(CompContext db)
        {
            this.db = db;
        }
        public void Create(User item)
        {
            db.User.Add(item);
        }

        public void Delete(int id)
        {
            User u = db.User.Find(id);
            if (u != null)
            {
                db.User.Remove(u);
            }
        }

        public User GetItem(int id)
        {
            return db.User.Find(id);
        }

        public List<User> GetList()
        {
            return db.User.ToList();
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
