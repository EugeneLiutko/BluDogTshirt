namespace EuluBlueMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserId2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MarketItems", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MarketItems", "UserID", c => c.Int(nullable: false));
        }
    }
}
