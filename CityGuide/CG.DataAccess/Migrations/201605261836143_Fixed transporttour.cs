namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixedtransporttour : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransportTours", "TransportId", c => c.Int(nullable: false));
            DropColumn("dbo.TransportTours", "ObjectiveId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransportTours", "ObjectiveId", c => c.Int(nullable: false));
            DropColumn("dbo.TransportTours", "TransportId");
        }
    }
}
