using System.Collections.Generic;

namespace CarsGame
{
    class Player
    {
        private double _balance;
        private string name;
        private List<Car> carsList;
        public double Balance
        {
            get { return _balance; }
            set { _balance = value; } 
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void AddCar(Car car)
        {
            carsList.Add(car);
        }

        public List<Car> CarsList
        {
            get { return carsList; }
        }
        public Player(string name1)
        {
            name = name1;
            _balance = 100;
            carsList = new List<Car>();
        }

    }
}
