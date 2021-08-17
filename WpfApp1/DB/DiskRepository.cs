using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.model;

namespace WpfApp1.DB
{
    class DiskRepository : IRepository<Disk>
    {
        private DiskContext db;

        public DiskRepository(DiskContext _db)
        {
            db = _db;
        }

        public void Create(Disk item)
        {
            db.Disks.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Disk item = get(id);
            if (item != null)
            {
                db.Disks.Remove(item);
            }
        }

        public Disk get(int id)
        {
            return db.Disks.Find(id);
        }

        public IEnumerable<Disk> getAll()
        {
            return db.Disks;
        }

        public void Update(Disk item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
