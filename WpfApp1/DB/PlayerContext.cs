using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DB
{
    class PlayerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public PlayerContext() : base("MyProj") { }
    }
}
