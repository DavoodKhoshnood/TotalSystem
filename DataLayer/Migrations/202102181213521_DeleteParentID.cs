namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteParentID : DbMigration
    {
        public override void Up()
        {
                Sql(@"IF EXISTS( SELECT * FROM sys.foreign_keys " +
                    " WHERE object_id = OBJECT_ID(N'dbo.[FK_dbo.GoodsGroups_dbo.GoodsGroups_ParentGroup_GroupID]') " +
                    " AND parent_object_id = OBJECT_ID(N'dbo.GoodsGroups')) "+
                    "   alter table GoodsGroups drop constraint [FK_dbo.GoodsGroups_dbo.GoodsGroups_ParentGroup_GroupID]  "
                    );
            DropColumn("dbo.GoodsGroups", "ParentID");
        }
        
   

    }
}
