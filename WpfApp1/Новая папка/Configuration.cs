namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class AccumConfiguration : DbMigrationsConfiguration<WpfApp1.DB.AccumContext>
    {
        public AccumConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WpfApp1.DB.AccumContext";
        }
    }
    internal sealed class DiskConfiguration : DbMigrationsConfiguration<WpfApp1.DB.DiskContext>
    {
        public DiskConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WpfApp1.DB.DiskContext";
        }
    }
    internal sealed class EngineConfiguration : DbMigrationsConfiguration<WpfApp1.DB.EngineContext>
    {
        public EngineConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WpfApp1.DB.EngineContext";
        }
    }

    internal sealed class CarConfiguration : DbMigrationsConfiguration<WpfApp1.DB.CarContext>
    {
        public CarConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WpfApp1.DB.CarContext";
        }
    }

    internal sealed class PlayerConfiguration : DbMigrationsConfiguration<WpfApp1.DB.PlayerContext>
    {
        public PlayerConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WpfApp1.DB.PlayerContext";
        }
    }
}
