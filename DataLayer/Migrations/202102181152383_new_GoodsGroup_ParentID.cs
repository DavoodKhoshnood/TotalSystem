namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_GoodsGroup_ParentID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GoodsGroups", "ParentID", "dbo.GoodsGroups");
            DropIndex("dbo.GoodsGroups", new[] { "ParentID" });
            AddColumn("dbo.GoodsGroups", "Parent_GroupID", c => c.Int());
            CreateIndex("dbo.GoodsGroups", "Parent_GroupID");
            AddForeignKey("dbo.GoodsGroups", "Parent_GroupID", "dbo.GoodsGroups", "GroupID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoodsGroups", "Parent_GroupID", "dbo.GoodsGroups");
            DropIndex("dbo.GoodsGroups", new[] { "Parent_GroupID" });
            DropColumn("dbo.GoodsGroups", "Parent_GroupID");
            CreateIndex("dbo.GoodsGroups", "ParentID");
            AddForeignKey("dbo.GoodsGroups", "ParentID", "dbo.GoodsGroups", "GroupID");
        }
    }
}
