namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedtoursrating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tours", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tours", "Rating");
        }
    }
}
