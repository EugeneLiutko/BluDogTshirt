namespace EuluBlueMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MarketItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Photo = c.String(),
                        UserDetails = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MarketItems");
        }
    }
}
