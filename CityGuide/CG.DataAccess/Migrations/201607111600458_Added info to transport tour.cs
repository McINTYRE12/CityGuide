namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedinfototransporttour : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransportTours", "Info", c => c.String());
            DropColumn("dbo.Objectives", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Objectives", "Location", c => c.Geography());
            DropColumn("dbo.TransportTours", "Info");
        }
    }
}
