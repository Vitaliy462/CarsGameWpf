using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.model
{
    static class DetailFactory
    {
        public static Random rand = new Random();
        public static Disk GetSimpleDisk()
        {
            Disk disk = new Disk("Simple Disk",
                                 rand.Next(100, 300),
                                 rand.Next(100, 300),
                                 rand.Next(100, 200));
            return disk;
        }
        public static Disk GetAdvDisk()
        {
            Disk disk = new Disk("Adv Disk",
                                 rand.Next(400, 700),
                                 rand.Next(400, 700),
                                 rand.Next(400, 700));
            return disk;
        }
        public static Disk GetProDisk()
        {
            Disk disk = new Disk("Pro Disk",
                     rand.Next(700, 999),
                     rand.Next(700, 999),
                     rand.Next(700, 999));
            return disk;
        }

        public static Engine GetSimpleEngine()
        {
            Engine engine = new Engine("Simple Engine",
                                 rand.Next(1000, 3000),
                                 rand.Next(1000, 3000),
                                 rand.Next(1000, 2000));
            return engine;
        }
        public static Engine GetAdvEngine()
        {
            Engine engine = new Engine("Adv Engine",
                                 rand.Next(4000, 7000),
                                 rand.Next(4000, 7000),
                                 rand.Next(4000, 7000));
            return engine;
        }
        public static Engine GetProEngine()
        {
            Engine engine = new Engine("Pro Engine",
                     rand.Next(7000, 9999),
                     rand.Next(7000, 9999),
                     rand.Next(7000, 9999));
            return engine;
        }

        public static Accum GetSimpleAccum()
        {
            Accum accum = new Accum("Simple Accum",
                                 rand.Next(1000, 3000),
                                 rand.Next(1000, 3000),
                                 rand.Next(1000, 2000));
            return accum;
        }
        public static Accum GetAdvAccum()
        {
            Accum accum = new Accum("Adv Accum",
                                 rand.Next(4000, 7000),
                                 rand.Next(4000, 7000),
                                 rand.Next(4000, 7000));
            return accum;
        }
        public static Accum GetProAccum()
        {
            Accum accum = new Accum("Pro Accum",
                     rand.Next(7000, 99999),
                     rand.Next(7000, 99999),
                     rand.Next(7000, 99999));
            return accum;
        }
    }
}
