using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfApp1.model.Detail;

namespace WpfApp1.model
{
    class Car
    {
        public int Drive()
        {
            if(CanDrive())
            {
                return 100;
            }
            return 0;
        }
        public bool CanDrive()
        {
            return IsInited()
                && !IsBreak();
        }

        public void Update()
        {
            disk.Update();
            accum.Update();
            engine.Update();
        }

        public bool IsInited()
        {
            return disk != null
                && accum != null
                && engine != null;
        }
        public void SetDisk(Disk _disk)
        {
            disk = _disk;
        }
        public void SetEngine(Engine _engine)
        {
            engine = _engine;
        }
        public void SetAccum(Accum _accum)
        {
            accum = _accum;
        }

        public bool NeedDetail(DetailType type)
        {
            switch (type)
            {
                case DetailType.ENGINE:         return engine == null || engine.IsBreak;
                case DetailType.DISK:           return disk == null || disk.IsBreak;
                case DetailType.ACCUMULATOR:    return accum == null || accum.IsBreak;
            }
            return false;
        }
        public bool IsBreak()
        {
            return disk.IsBreak
                || accum.IsBreak
                || engine.IsBreak;
        }

        public bool IsRepairable()
        {
            return disk.IsRepairble()
                || accum.IsRepairble()
                || engine.IsRepairble();
        }

        public float RepairCost()
        {
            float cost = 0;
            if (disk.IsRepairble())
            {
                cost += disk.RepairPrice;
            }
            if (accum.IsRepairble())
            {
                cost += accum.RepairPrice;
            }
            if (engine.IsRepairble())
            {
                cost += engine.RepairPrice;
            }
            return cost;
        }

        public void RepairTotal()
        {
            disk?.Repair();
            accum?.Repair();
            engine?.Repair();
        }

        public void SetupDetail(Detail detail)
        {
            if( detail is Disk )
            {
                SetDisk((Disk)detail);
            }
            else if (detail is Accum)
            {
                SetAccum((Accum)detail);
            }
            else if (detail is Engine)
            {
                SetEngine((Engine)detail);
            }
        }

        public override string ToString()
        {
            var diskInfo = disk != null ? disk.ToString() : "disk:empty";
            var engineInfo = engine != null ? engine.ToString() : "engine:empty";
            var accumInfo = accum != null ? accum.ToString() : "accum:empty";
            return diskInfo + "\n"
                + accumInfo + "\n"
                + engineInfo;
        }

        public Disk GetDisk()
        {
            return disk;
        }
        public Accum GetAccum()
        {
            return accum;
        }public Engine GetEngine()
        {
            return engine;
        }
        public int Id { get; set; }
        protected Disk   disk   = null;
        protected Accum  accum  = null;
        protected Engine engine = null;
    }
}
