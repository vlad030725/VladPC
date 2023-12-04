﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Repository;

namespace VladPC.DAL.RepositoryPgs
{
    public class StatusRepositoryPgs : IRepository<Status>
    {
        private CompContext db;
        public StatusRepositoryPgs(CompContext db)
        {
            this.db = db;
        }
        public void Create(Status item)
        {
            db.Status.Add(item);
        }

        public void Delete(int id)
        {
            Status s = db.Status.Find(id);
            if (s != null)
            {
                db.Status.Remove(s);
            }
        }

        public Status GetItem(int id)
        {
            return db.Status.Find(id);
        }

        public List<Status> GetList()
        {
            return db.Status.ToList();
        }

        public void Update(Status item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
