namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelStoreIdFromGoods : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Goods", "StoreID", "dbo.Stores");
            DropIndex("dbo.Goods", new[] { "StoreID" });
            RenameColumn(table: "dbo.Goods", name: "StoreID", newName: "Store_StoreID");
            AlterColumn("dbo.Goods", "Store_StoreID", c => c.Int());
            CreateIndex("dbo.Goods", "Store_StoreID");
            AddForeignKey("dbo.Goods", "Store_StoreID", "dbo.Stores", "StoreID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Goods", "Store_StoreID", "dbo.Stores");
            DropIndex("dbo.Goods", new[] { "Store_StoreID" });
            AlterColumn("dbo.Goods", "Store_StoreID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Goods", name: "Store_StoreID", newName: "StoreID");
            CreateIndex("dbo.Goods", "StoreID");
            AddForeignKey("dbo.Goods", "StoreID", "dbo.Stores", "StoreID", cascadeDelete: true);
        }
    }
}
