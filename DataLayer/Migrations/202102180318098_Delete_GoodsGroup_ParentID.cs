namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_GoodsGroup_ParentID : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.GoodsGroups", new[] { "ParentGroup_GroupID" });
            DropColumn("dbo.GoodsGroups", "ParentID");
            RenameColumn(table: "dbo.GoodsGroups", name: "ParentGroup_GroupID", newName: "ParentID");
            AlterColumn("dbo.GoodsGroups", "ParentID", c => c.Int(nullable: false));
            CreateIndex("dbo.GoodsGroups", "ParentID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.GoodsGroups", new[] { "ParentID" });
            AlterColumn("dbo.GoodsGroups", "ParentID", c => c.Int());
            RenameColumn(table: "dbo.GoodsGroups", name: "ParentID", newName: "ParentGroup_GroupID");
            AddColumn("dbo.GoodsGroups", "ParentID", c => c.Int(nullable: false));
            CreateIndex("dbo.GoodsGroups", "ParentGroup_GroupID");
        }
    }
}
