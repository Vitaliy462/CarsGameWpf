using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.model;

namespace WpfApp1.DB
{
    class UnitOfWork : IDisposable
    {
        private DetailsContext detailDb = new DetailsContext();
        private DetailsRepository detailRepository = null;

        public DetailsRepository Details {
            get {if (detailRepository == null)
                {
                    detailRepository = new DetailsRepository(detailDb);
                }
                return detailRepository;
            }
        }

       


        

        private PlayerContext playerDb = new PlayerContext();
        private PlayerRepository playerRepository = null;

        public PlayerRepository Players
        {
            get
            {
                if (playerRepository == null)
                {
                    playerRepository = new PlayerRepository(playerDb);
                }
                return playerRepository;
            }
        }
        public void SavePlayer(Player player)
        {
            Console.WriteLine(player.GetCar().Id);

            Cars.Create(player.GetCar());
            Console.WriteLine(player.GetCar().Id);
            player.Id_Car = player.GetCar().Id;
            Disk disk = player.GetCar().GetDisk();
            if (disk != null)
            {
               disk.Id_Car = player.GetCar().Id;
                Details.Create(disk);
            }
            Engine engine = player.GetCar().GetEngine();
            if (engine != null)
            {
                engine.Id_Car = player.GetCar().Id;
                Details.Create(engine);
            }
            Accum accum = player.GetCar().GetAccum();
            if (accum != null)
            {
                accum.Id_Car = player.GetCar().Id;
                Details.Create(accum);
            }
            Players.Create(player);

        }

        public Player LoadLastPlayer()
        {

            Car lastCar = null;
            foreach (Car car in Cars.getAll())
            {
                if (lastCar == null || lastCar.Id < car.Id)
                {
                    lastCar = car;
                }
                
            }
            if (lastCar == null)
            {
                return new Player();
            }
            foreach (Engine engine in Details.getAllEngines())
            {
                if (engine.Id_Car == lastCar.Id)
                {
                    lastCar.SetEngine(engine);
                    break;
                }
            }
            foreach (Disk disk in Details.getAllDisks())
            {
                if (disk.Id_Car == lastCar.Id)
                {
                    lastCar.SetDisk(disk);
                    break;
                }
            }foreach (Accum accum in Details.getAllAccums())
            {
                if (accum.Id_Car == lastCar.Id)
                {
                    lastCar.SetAccum(accum);
                    break;
                }
            }
            foreach (Player player in Players.getAll())
            {
                if (player.Id_Car == lastCar.Id)
                {
                    player.SetCar(lastCar);
                    return player;
                }
            }
            return new Player();
        }



        private CarContext carDb = new CarContext();
        private CarRepository carRepository = null;

        public CarRepository Cars
        {
            get
            {
                if (carRepository == null)
                {
                    carRepository = new CarRepository(carDb);
                }
                return carRepository;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    detailDb.Dispose();
                    carDb.Dispose();
                    playerDb.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            detailDb.SaveChanges();
            carDb.SaveChanges();
            playerDb.SaveChanges();
        }
    }
}
