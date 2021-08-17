using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.model;

namespace WpfApp1.DB
{
    class AccumContext : DbContext
    {
        public DbSet<Accum> Accumulators { get; set; }
    }
}
