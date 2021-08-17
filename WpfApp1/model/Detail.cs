using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.model
{
    [Table("Detail")]
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
        [Required]
        public DetailType Type { get; set; }
        
        public int Id { get; set; }
        [Required]
        public int Id_Car { get; set; }
        [Required]
        public string Name { get;}
        [Required]
        public float Cost { get; set; } = 0;
        [Required]
        public float Durability { get; set; } = 0;
        [Required]
        public float RepairPrice { get; set; } = 0;
        public abstract bool Repair();
        public abstract bool IsRepairble();
        [Required]
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
