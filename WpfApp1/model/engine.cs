using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.model
{
    class Engine : Detail
    {
        public Engine(string name,
                      float  cost,
                      float  durability,
                      float  repairPrice)
        : base(DetailType.ENGINE, name, cost, durability, repairPrice)
        {}
        public Engine()
        : base(DetailType.ENGINE, "", 0, 0, 0)
        { }
        public override void Update()
        {
            if(!IsBreak)
            {
                Random random = new Random();
                IsBreak =  random.Next(0, 100) < 10; 
            }
        }

        public override bool IsRepairble()
        {
            return IsBreak && Durability > 10;
        }

        public override bool Repair()
        {
            if(IsRepairble())
            {
                Durability  -= 10;
                RepairPrice += 1000;
                IsBreak = false;
                return true;
            }
            return false;
        }

    }
}
