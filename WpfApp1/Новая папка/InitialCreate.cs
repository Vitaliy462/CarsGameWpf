﻿namespace WpfApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Accums",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Type = c.Int(nullable: false),
                    Id_Car = c.Int(nullable: false),
                    Cost = c.Single(nullable: false),
                    Durability = c.Single(nullable: false),
                    RepairPrice = c.Single(nullable: false),
                    IsBreak = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Disks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Type = c.Int(nullable: false),
                    Id_Car = c.Int(nullable: false),
                    Cost = c.Single(nullable: false),
                    Durability = c.Single(nullable: false),
                    RepairPrice = c.Single(nullable: false),
                    IsBreak = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Engines",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Type = c.Int(nullable: false),
                    Id_Car = c.Int(nullable: false),
                    Cost = c.Single(nullable: false),
                    Durability = c.Single(nullable: false),
                    RepairPrice = c.Single(nullable: false),
                    IsBreak = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);
            CreateTable(
                "dbo.Cars",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Players",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Id_Car = c.Int(nullable: false),
                    Money = c.Single(nullable: false),
                    Km = c.Single(nullable: false)
                })
                .PrimaryKey(t => t.Id);
        }


        public override void Down()
        {
            DropTable("dbo.Accums");
            DropTable("dbo.Disks");
            DropTable("dbo.Engines");
            DropTable("dbo.Cars");
            DropTable("dbo.Players");

        }
    }
}
