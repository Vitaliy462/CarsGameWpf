using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.model
{
    [Table("Detail")]
    class Accum : Detail
    {
        public Accum(string name,
                    float cost,
                    float durability,
                    float repairPrice)
        : base(DetailType.ACCUMULATOR, name, cost, durability, repairPrice)
        { }
        public Accum()
        : base(DetailType.ACCUMULATOR, "", 0, 0, 0)
        { }
        public override void Update()
        {
            if (!IsBreak)
            {
                Random random = new Random();
                IsBreak = random.Next(0, 1000) < 50;
            }
        }

        public override bool IsRepairble()
        {
            return IsBreak && Durability > 100;
        }

        public override bool Repair()
        {
            if (IsRepairble())
            {
                Durability -= 20;
                RepairPrice += 2000;
                IsBreak = false;
                return true;
            }
            return false;
        }

    }
}
