using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.model;

namespace WpfApp1.DB
{
    class DetailsRepository
    {
        private DetailsContext db;

        public DetailsRepository(DetailsContext _db)
        {
            db = _db;
        }

        public void Create(Detail item)
        {
            db.Details.Add(item);
        db.SaveChanges();
        }
        
    

        public void Delete(int id)
        {
            Delete(id, Detail.DetailType.ACCUMULATOR);
            Delete(id, Detail.DetailType.ENGINE);
            Delete(id, Detail.DetailType.DISK);
        }
        public void Delete(int id, Detail.DetailType detailType)
        {
            switch (detailType)
            {
                case Detail.DetailType.ACCUMULATOR:
                    { 
                Accum item = getAccum(id);
                if (item != null)
                {
                    db.Accumulators.Remove(item);
                }
                    }
                    break;
                case Detail.DetailType.ENGINE:
                    { 
                    Engine item = getEngine(id);
                    if (item != null)
                    {
                        db.Engines.Remove(item);
                    }
                    }
                    break;
                case Detail.DetailType.DISK:
                    { 
                    Disk item = getDisk(id);
                    if (item != null)
                    {
                        db.Disks.Remove(item);
                    }
                    }
                    break;
            }
    }
        public Accum getAccum(int id)
        {
            return db.Accumulators.Find(id);
        }
        public Accum getAccumByCarId(int car_id)
        {
            
            return db.Accumulators.Where(item => item.Type == Detail.DetailType.ACCUMULATOR && item.Id_Car == car_id).FirstOrDefault();
            
        } 
        public Engine getEngineByCarId(int car_id)
        {
            return db.Engines.Where(item => item.Type == Detail.DetailType.ENGINE && item.Id_Car == car_id).FirstOrDefault();
            
        } 
        public Disk getDiskByCarId(int car_id)
        {
            
            return db.Disks.Where(item => item.Type == Detail.DetailType.DISK && item.Id_Car == car_id).FirstOrDefault();
            
        }
        public Engine getEngine(int id)
        {
            return db.Engines.Find(id);
        }
        public Disk getDisk(int id)
        {
            return db.Disks.Find(id);
        }

        public IEnumerable<Accum> getAllAccums()
        {
            return db.Accumulators.Where(item => item.Type == Detail.DetailType.ACCUMULATOR);
        }

        public IEnumerable<Engine> getAllEngines()
        {
            return db.Engines.Where(item=>item.Type==Detail.DetailType.ENGINE);
        }

        public IEnumerable<Disk> getAllDisks()
        {
            return db.Disks.Where(item => item.Type == Detail.DetailType.DISK);
        }

        public void Update(Detail item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        internal void DeleteByCarId(int carId)
        {
            Disk disk = getDiskByCarId(carId);
            Engine engine = getEngineByCarId(carId);
            Accum accum = getAccumByCarId(carId);
            if (disk != null)
            {
                db.Disks.Remove(disk);
                db.Details.Remove(disk);
            }
            if (engine != null)
            {
                db.Engines.Remove(engine);
                db.Details.Remove(engine);
            }
            if (accum != null)
            {
                db.Accumulators.Remove(accum);
                db.Details.Remove(accum);
            }
            
        }
    }
}
