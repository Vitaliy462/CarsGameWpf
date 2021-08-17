using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.model;

namespace WpfApp1.DB
{
    class EngineContext : DbContext
    {
        public DbSet<Engine> Engines { get; set; }
    }
}
