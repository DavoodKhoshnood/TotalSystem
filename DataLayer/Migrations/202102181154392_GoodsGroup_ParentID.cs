namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoodsGroup_ParentID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GoodsGroups", "Parent_GroupID", "dbo.GoodsGroups");
            DropIndex("dbo.GoodsGroups", new[] { "Parent_GroupID" });
            DropColumn("dbo.GoodsGroups", "Parent_GroupID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GoodsGroups", "Parent_GroupID", c => c.Int());
            CreateIndex("dbo.GoodsGroups", "Parent_GroupID");
            AddForeignKey("dbo.GoodsGroups", "Parent_GroupID", "dbo.GoodsGroups", "GroupID");
        }
    }
}
