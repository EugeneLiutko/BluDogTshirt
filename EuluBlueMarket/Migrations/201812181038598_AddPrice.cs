namespace EuluBlueMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MarketItems", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MarketItems", "Price");
        }
    }
}
