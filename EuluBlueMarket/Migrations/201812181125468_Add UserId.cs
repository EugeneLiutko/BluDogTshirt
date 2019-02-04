namespace EuluBlueMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MarketItems", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MarketItems", "UserID");
        }
    }
}
