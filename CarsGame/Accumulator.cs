using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsGame
{
    class Accumulator : Detail
    {
        public Accumulator()
        {
            _stability = 120;
            _currentStability = 120;
            _stabilityDecrease = 40;
            _priceBuy = 70;
            _priceRepair = 40;
        }
        public override double Repair()
        {
            
            if (this.Stability >= this.StabilityDecrease)
            {
                
                this.Stability -= this.StabilityDecrease;
                
                this.CurrentStability = this.Stability;
                Console.WriteLine("Аккумулятор починился за " + this.PriceRepair + " його стійкість = " + this.Stability);
                return this.PriceRepair;
            }
            
            else
            {
                this.Stability = 120;
                this.CurrentStability = this.Stability;
                Console.WriteLine("Аккумулятор потребовал полной замены, куплен аккумулятор за " + this.PriceBuy);
                return this.PriceBuy;
            }
        }
    }
}
