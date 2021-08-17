using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.model;

namespace WpfApp1.DB
{
    class DetailsContext : DbContext
    {
        public DbSet<Disk> Disks { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Accum> Accumulators { get; set; }

        public DbSet<Detail> Details { get; set; }

        public DetailsContext() : base("MyProj") { }
    }
}
