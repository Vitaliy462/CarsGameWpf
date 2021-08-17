using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsGame
{
    class Game
    {
        public Game()
        {
            player = new Player("User1");
        }

        public bool Init()
        {
            return player != null;
        }
        public void Finish()
        { endApp = true; }
        public void Done()
        {
            stop = true;
        }
        public bool IsStop() { return stop; }

        public bool EndApp() { return endApp; }
        public string PlayerName() { return player.Name; }

        public double GetBalance() { return player.Balance; }
        public void AddCar(Car car)
        {
            player.AddCar(car);
        }
        public string ShowCars()
        {
            string result = "";
            foreach (var car1 in player.CarsList)
            {
                result += $"Player {player.Name} has car with the number { car1.Number}";
            }
            return result;
        }

        public  Player GetPlayer() { return player;  }



        Player  player = null;
        bool    stop = false;
        bool    endApp = false;
        //int     option = 0;

    }
}
