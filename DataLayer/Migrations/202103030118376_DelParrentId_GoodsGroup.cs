namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelParrentId_GoodsGroup : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.GoodsGroups", "ParentID", c => c.Int(nullable: false));
        }
    }
}
