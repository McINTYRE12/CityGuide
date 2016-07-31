namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class addedlocationtoobjectives : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Objectives", "Location", c => c.Geography());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Objectives", "Location");
        }
    }
}
