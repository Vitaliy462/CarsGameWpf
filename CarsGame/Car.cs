﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsGame
{
    class Car
    {
        private int _number;
        protected int passedDist;
        
        
        private bool isBroken;
        private bool noRepair;

        public Car()
        { 
            _number = new Random().Next(1000, 9999);
        }

        public void Drive(Player player, Engine engine, Disc disc, Accumulator accumulator)
        {
            passedDist += 50;
            player.Balance += 10;
            
            
            engine.CurrentStability -= 20;
            accumulator.CurrentStability -= 20;
            disc.CurrentStability -= 20;

            
            if (engine.CurrentStability <= 20)
            {
                Console.WriteLine("Мотор сломался. Необходимо починить");
                isBroken = true;
            }
            else if (accumulator.CurrentStability <= 20)
            {
                Console.WriteLine("Аккумулятор сломался. Необходимо починить");
                isBroken = true;
            }
            else if (disc.CurrentStability <= 20)
            {
                Console.WriteLine("Диск сломался. Необходимо починить");
                isBroken = true;
            }
            else 
            {
                Console.WriteLine("Машина проехала " + passedDist + " km");
            }
        }

        public void RepairEngine(Engine engine, Player player)
        {
            if (player.Balance > engine.PriceRepair && player.Balance > engine.PriceBuy)
            {
                player.Balance -= engine.Repair();
                isBroken = false;
            }
            else 
            {
                Console.WriteLine("У игрока недостаточно средств");
                noRepair = true;
            }
        }

        public void RepairAccumulator(Accumulator accumulator, Player player)
        {
            if (player.Balance > accumulator.PriceRepair && player.Balance > accumulator.PriceBuy)
            {
                player.Balance -= accumulator.Repair();
                isBroken = false;
            }
            else
            {
                Console.WriteLine("У игрока недостаточно средств");
                noRepair = true;
            }
        }

        public void RepairDisc(Disc disc, Player player)
        {
            if (player.Balance > disc.PriceRepair && player.Balance > disc.PriceBuy)
            {
                player.Balance -= disc.Repair();   
                isBroken = false;
            }
            else
            {
                Console.WriteLine("У игрока недостаточно средств");
                noRepair = true;
            }
        }

        public int Number { get { return _number; }  }
        public bool IsBroken { get { return isBroken; } }
        public bool NoRepair { get { return noRepair; } }
    }
}
