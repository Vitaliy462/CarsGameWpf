using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.model;

namespace WpfApp1.DB
{
    class EngineRepository
    {
        private EngineContext db;

        public EngineRepository(EngineContext _db)
        {
            db = _db;
        }

        public void Create(Engine item)
        {
            db.Engines.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Engine item = get(id);
            if (item != null)
            {
                db.Engines.Remove(item);
            }
        }

        public Engine get(int id)
        {
            return db.Engines.Find(id);
        }

        public IEnumerable<Engine> getAll()
        {
            return db.Engines;
        }

        public void Update(Engine item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
