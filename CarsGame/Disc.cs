using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsGame
{
    class Disc : Detail
    {
        public Disc()
        {
            _stability = 80;
            _currentStability = 80;
            _stabilityDecrease = 30;
            _priceBuy = 30;
            _priceRepair = 10;
            _state = 3;
        }
        public override double Repair()
        {
            
            if (this.Stability >= this.StabilityDecrease)
            {
                
                this.Stability -= this.StabilityDecrease;
                
                this.CurrentStability = this.Stability;
                Console.WriteLine("Диск починился за " + this.PriceRepair + " його стійкість = " + this.Stability);
                return this.PriceRepair;
            }
            
            else
            {
                this.Stability = 80;
                this.CurrentStability = this.Stability;
                Console.WriteLine("Диск потребовал полной замены, куплен диск за " + this.PriceBuy);
                return this.PriceBuy;
            }    
        }
    }
}
