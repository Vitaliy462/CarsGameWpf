using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.model;

namespace WpfApp1.DB
{
    class AccumRepository
    {
        private AccumContext db;

        public AccumRepository(AccumContext _db)
        {
            db = _db;
        }

        public void Create(Accum item)
        {
            db.Accumulators.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Accum item = get(id);
            if (item != null)
            {
                db.Accumulators.Remove(item);
            }
        }

        public Accum get(int id)
        {
            return db.Accumulators.Find(id);
        }

        public IEnumerable<Accum> getAll()
        {
            return db.Accumulators;
        }

        public void Update(Accum item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
