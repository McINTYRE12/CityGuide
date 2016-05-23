namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedtransporthandlingmethod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tour_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.Tour_Id)
                .Index(t => t.Tour_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transports", "Tour_Id", "dbo.Tours");
            DropIndex("dbo.Transports", new[] { "Tour_Id" });
            DropTable("dbo.Transports");
        }
    }
}
