namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedtransportstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransportTours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ObjectiveId = c.Int(nullable: false),
                        TourId = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Transports", "Icon_Id", c => c.Int());
            CreateIndex("dbo.Transports", "Icon_Id");
            AddForeignKey("dbo.Transports", "Icon_Id", "dbo.Photos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transports", "Icon_Id", "dbo.Photos");
            DropIndex("dbo.Transports", new[] { "Icon_Id" });
            DropColumn("dbo.Transports", "Icon_Id");
            DropTable("dbo.TransportTours");
        }
    }
}
