using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VladPC.DAL.Repository;

namespace VladPC.DAL.RepositoryPgs
{
    public class ProcurementRowRepositoryRow : IRepository<ProcurementRow>
    {
        private CompContext db;
        public ProcurementRowRepositoryRow(CompContext db)
        {
            this.db = db;
        }
        public void Create(ProcurementRow item)
        {
            db.ProcurementRow.Add(item);
        }

        public void Delete(int id)
        {
            ProcurementRow p = db.ProcurementRow.Find(id);
            if (p != null)
            {
                db.ProcurementRow.Remove(p);
            }
        }

        public ProcurementRow GetItem(int id)
        {
            return db.ProcurementRow.Find(id);
        }

        public List<ProcurementRow> GetList()
        {
            return db.ProcurementRow.ToList();
        }

        public void Update(ProcurementRow item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
