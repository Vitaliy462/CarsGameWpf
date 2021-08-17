using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.model
{
    [Table("Detail")]
    class Disk : Detail
    {
        public Disk(string name,
                    float cost,
                    float durability,
                    float repairPrice)
        : base(DetailType.DISK, name, cost, durability, repairPrice)
        { }
        public Disk()
        : base(DetailType.DISK, "", 0, 0, 0)
        { }
        public override void Update()
        {
            if (!IsBreak)
            {
                Random random = new Random();
                IsBreak = random.Next(0, 100)<10;
            }
        }

        public override bool IsRepairble()
        {
            return IsBreak &&  Durability > 2;
        }

        public override bool Repair()
        {
            if (IsRepairble())
            {
                Durability -= 5;
                RepairPrice += 200;
                IsBreak = false;
                return true;
            }
            return false;
        }

    }
}
