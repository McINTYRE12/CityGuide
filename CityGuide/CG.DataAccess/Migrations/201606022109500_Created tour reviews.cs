namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createdtourreviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TourReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScoreGiven = c.Int(nullable: false),
                        Tour_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.Tour_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Tour_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourReviews", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TourReviews", "Tour_Id", "dbo.Tours");
            DropIndex("dbo.TourReviews", new[] { "User_Id" });
            DropIndex("dbo.TourReviews", new[] { "Tour_Id" });
            DropTable("dbo.TourReviews");
        }
    }
}
