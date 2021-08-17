using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.model;

namespace WpfApp1
{
    class Player
    {
        public Player()
        {
            car = new Car();
        }

        public bool CanRepair()
        {
            return car.IsInited() && car.IsBreak() && car.IsRepairable();
        }

        public float CalculateRepairCost()
        {
            float cost = 0;
            if(CanRepair())
            {
                cost = car.RepairCost();
            }
            return cost;
        }
        public bool RepairTotal()
        {
            float cost = CalculateRepairCost();
            if (Money >= cost)
            {
                Money -= cost;
                car.RepairTotal();
                return true;
            }
            return false;
        }

        public bool BuyDetail(Detail detail)
        {
            if( Money >= detail.Cost )
            {
                car.SetupDetail(detail);
                Money -= detail.Cost;
                return true;
            }
            return false;
        }

        public void Update()
        {
            if(car.IsInited() && car.CanDrive())
            {
                Km += car.Drive();
                Money += 5;
                car.Update();
            }
        }

        public string ShowCarInfo()
        {
            return car.ToString();
        }


        private Car      car     = null;
        public Car GetCar()
        {
            return car;
        }

        public void SetCar(Car _car)
        {
            car = _car;
        }
        public int Id_Car { get; set; }
        public int Id { get; set; }
        public float    Money { get; protected set; }   = 100000;
        public float Km { get; protected set; } = 0;
    }
}
