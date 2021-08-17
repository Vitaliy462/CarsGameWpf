using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.model;

namespace WpfApp1.DB
{
    class CarRepository : IRepository<Car>
    {
        private CarContext db;

        public CarRepository(CarContext _db)
        {
            db = _db;
        }

        public void Create(Car item)
        {
            db.Cars.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Car item = get(id);
            if (item != null)
            {
                db.Cars.Remove(item);
            }
        }

        public Car get(int id)
        {
            return db.Cars.Find(id);
        }

        public IEnumerable<Car> getAll()
        {
            return db.Cars;
        }

        public void Update(Car item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
