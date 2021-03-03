namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_Data : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        GoodID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 300),
                        UnitID = c.Int(nullable: false),
                        ShowInSlider = c.Boolean(nullable: false),
                        ImageName = c.String(),
                        Description = c.String(maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GoodID)
                .ForeignKey("dbo.GoodsGroups", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.StoreID, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.UnitID, cascadeDelete: true)
                .Index(t => t.GroupID)
                .Index(t => t.StoreID)
                .Index(t => t.UnitID);
            
            CreateTable(
                "dbo.GoodsGroups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 300),
                        Description = c.String(maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                        ParentGroup_GroupID = c.Int(),
                    })
                .PrimaryKey(t => t.GroupID)
                .ForeignKey("dbo.GoodsGroups", t => t.ParentGroup_GroupID)
                .Index(t => t.ParentGroup_GroupID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Address = c.String(maxLength: 1000),
                        Description = c.String(maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StoreID);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        UnitID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Countable = c.Boolean(nullable: false),
                        Coefficient = c.Single(nullable: false),
                        Description = c.String(maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                        ParentUnit_UnitID = c.Int(),
                    })
                .PrimaryKey(t => t.UnitID)
                .ForeignKey("dbo.Units", t => t.ParentUnit_UnitID)
                .Index(t => t.ParentUnit_UnitID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Units", "ParentUnit_UnitID", "dbo.Units");
            DropForeignKey("dbo.Goods", "UnitID", "dbo.Units");
            DropForeignKey("dbo.Goods", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.GoodsGroups", "ParentGroup_GroupID", "dbo.GoodsGroups");
            DropForeignKey("dbo.Goods", "GroupID", "dbo.GoodsGroups");
            DropIndex("dbo.Units", new[] { "ParentUnit_UnitID" });
            DropIndex("dbo.GoodsGroups", new[] { "ParentGroup_GroupID" });
            DropIndex("dbo.Goods", new[] { "UnitID" });
            DropIndex("dbo.Goods", new[] { "StoreID" });
            DropIndex("dbo.Goods", new[] { "GroupID" });
            DropTable("dbo.Units");
            DropTable("dbo.Stores");
            DropTable("dbo.GoodsGroups");
            DropTable("dbo.Goods");
        }
    }
}
