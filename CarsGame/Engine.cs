using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsGame
{
    class Engine : Detail
    {

        public Engine()
        {
            _stability = 100;
            _currentStability = 100;
            _stabilityDecrease = 15;
            _priceBuy = 50;
            _priceRepair = 20;
        }
        public override double Repair()
        {
            
            if (this.Stability >= this.StabilityDecrease)
            {
                
                this.Stability -= this.StabilityDecrease;
                
                this.CurrentStability = this.Stability;
                Console.WriteLine("Мотор починился за " + this.PriceRepair + " його стійкість = " + this.Stability);
                return this.PriceRepair;
            }
            
            else
            {
                this.Stability = 100;
                this.CurrentStability = this.Stability;
                Console.WriteLine("Мотор потребовал полной замены, куплен мотор за " + this.PriceBuy);
                return this.PriceBuy;
            }
        }
    }
}
