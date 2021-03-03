namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewColUnit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Units", "Symbol", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Units", "UnitGroup", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Units", "UnitGroup");
            DropColumn("dbo.Units", "Symbol");
        }
    }
}
