namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removedtransportlistfromtour : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transports", "Tour_Id", "dbo.Tours");
            DropIndex("dbo.Transports", new[] { "Tour_Id" });
            DropColumn("dbo.Transports", "Tour_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transports", "Tour_Id", c => c.Int());
            CreateIndex("dbo.Transports", "Tour_Id");
            AddForeignKey("dbo.Transports", "Tour_Id", "dbo.Tours", "Id");
        }
    }
}
