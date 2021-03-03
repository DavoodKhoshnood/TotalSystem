namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_Unit_ParentID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Units", "ParentUnit_UnitID", "dbo.Units");
            DropIndex("dbo.Units", new[] { "ParentUnit_UnitID" });
            DropColumn("dbo.Units", "ParentID");
            DropColumn("dbo.Units", "ParentUnit_UnitID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Units", "ParentUnit_UnitID", c => c.Int());
            AddColumn("dbo.Units", "ParentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Units", "ParentUnit_UnitID");
            AddForeignKey("dbo.Units", "ParentUnit_UnitID", "dbo.Units", "UnitID");
        }
    }
}
