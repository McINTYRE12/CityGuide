namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedToursToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Stops = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TourObjectives",
                c => new
                    {
                        Tour_Id = c.Int(nullable: false),
                        Objective_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tour_Id, t.Objective_Id })
                .ForeignKey("dbo.Tours", t => t.Tour_Id, cascadeDelete: true)
                .ForeignKey("dbo.Objectives", t => t.Objective_Id, cascadeDelete: true)
                .Index(t => t.Tour_Id)
                .Index(t => t.Objective_Id);
            
            AddColumn("dbo.Photos", "Tour_Id", c => c.Int());
            CreateIndex("dbo.Photos", "Tour_Id");
            AddForeignKey("dbo.Photos", "Tour_Id", "dbo.Tours", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "Tour_Id", "dbo.Tours");
            DropForeignKey("dbo.TourObjectives", "Objective_Id", "dbo.Objectives");
            DropForeignKey("dbo.TourObjectives", "Tour_Id", "dbo.Tours");
            DropIndex("dbo.TourObjectives", new[] { "Objective_Id" });
            DropIndex("dbo.TourObjectives", new[] { "Tour_Id" });
            DropIndex("dbo.Photos", new[] { "Tour_Id" });
            DropColumn("dbo.Photos", "Tour_Id");
            DropTable("dbo.TourObjectives");
            DropTable("dbo.Tours");
        }
    }
}
