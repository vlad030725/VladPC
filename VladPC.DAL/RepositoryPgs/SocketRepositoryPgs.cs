using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Repository;

namespace VladPC.DAL.RepositoryPgs
{
    public class SocketRepositoryPgs : IRepository<Socket>
    {
        private CompContext db;
        public SocketRepositoryPgs(CompContext db)
        {
            this.db = db;
        }
        public void Create(Socket item)
        {
            db.Socket.Add(item);
        }

        public void Delete(int id)
        {
            Socket s = db.Socket.Find(id);
            if (s != null)
            {
                db.Socket.Remove(s);
            }
        }

        public Socket GetItem(int id)
        {
            return db.Socket.Find(id);
        }

        public List<Socket> GetList()
        {
            return db.Socket.ToList();
        }

        public void Update(Socket item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
