using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsGame
{
    class Detail
    {
        protected int _stability;
        protected int _currentStability;
        protected int _stabilityDecrease;
        protected double _priceBuy;
        protected int _state;
        protected double _priceRepair;


        public int Stability
        {
            get { return _stability; }
            set { _stability = value; }
        }
        public int CurrentStability
        {
            get { return _currentStability; }
            set { _currentStability = value; }
        }
        public int StabilityDecrease
        {
            get { return _stabilityDecrease; }
            set { _stabilityDecrease = value; }
        }

        public double PriceBuy
        {
            get { return _priceBuy; }
            set { _priceBuy = value; }
        }

        public double PriceRepair
        {
            get { return _priceRepair; }
            set { _priceRepair = value; }
        }

        public int State
        {
            get { return _state; }
            set { _state = value; }
        }
        public virtual double Repair()
        {
            return 0;
        }


    }
}
