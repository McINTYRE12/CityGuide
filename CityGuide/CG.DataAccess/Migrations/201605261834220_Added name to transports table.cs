namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addednametotransportstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transports", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transports", "Name");
        }
    }
}
