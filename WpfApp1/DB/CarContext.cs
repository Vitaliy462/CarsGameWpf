using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.model;

namespace WpfApp1.DB
{
    class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarContext() : base("MyProj") { }
    }
}
