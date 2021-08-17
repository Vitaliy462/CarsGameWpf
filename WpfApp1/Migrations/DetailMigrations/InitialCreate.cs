namespace WpfApp1.Migrations.DetailMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Id_Car = c.Int(nullable: false),
                        Cost = c.Single(nullable: false),
                        Durability = c.Single(nullable: false),
                        RepairPrice = c.Single(nullable: false),
                        IsBreak = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Detail");
        }
    }
}
