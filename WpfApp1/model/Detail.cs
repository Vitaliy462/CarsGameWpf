using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.model
{
    abstract class Detail
    {
        public enum DetailType
        {
            ENGINE,
            DISK,
            ACCUMULATOR
        }
        public Detail(DetailType    type,
                      string        name,
                      float         cost,
                      float         durability,
                      float         repairPrice)
        {
            Type        = type;
            Name        = name;
            Cost        = cost;
            Durability  = durability;
            RepairPrice = repairPrice;

        }
        public DetailType Type { get; set; }

        public int Id { get; set; }

        public int Id_Car { get; set; }
        public string Name { get;}
        public float Cost { get; set; } = 0;
        public float Durability { get; set; } = 0;
        public float RepairPrice { get; set; } = 0;
        public abstract bool Repair();
        public abstract bool IsRepairble();
        public bool IsBreak { get; protected set; } = false;
        public abstract void Update();

        public override string ToString()
        {
            return "Type: " + Type + "\n"
                +"Id: " + Id + "\n"
                 + "Name: " + Name + "\n"
                 + "Durability: " + Durability + "\n"
                 + "RepairPrice: " + RepairPrice + "\n"
                 + "IsBroken: " + IsBreak + "\n"
                 + "IsRepairable: " + IsRepairble();
        }
    }
}
