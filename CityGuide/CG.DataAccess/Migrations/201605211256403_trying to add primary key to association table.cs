namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingtoaddprimarykeytoassociationtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TourObjectives", "Tour_Id", "dbo.Tours");
            DropForeignKey("dbo.TourObjectives", "Objective_Id", "dbo.Objectives");
            DropIndex("dbo.TourObjectives", new[] { "Tour_Id" });
            DropIndex("dbo.TourObjectives", new[] { "Objective_Id" });
            DropTable("dbo.TourObjectives");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TourObjectives",
                c => new
                    {
                        Tour_Id = c.Int(nullable: false),
                        Objective_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tour_Id, t.Objective_Id });
            
            CreateIndex("dbo.TourObjectives", "Objective_Id");
            CreateIndex("dbo.TourObjectives", "Tour_Id");
            AddForeignKey("dbo.TourObjectives", "Objective_Id", "dbo.Objectives", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TourObjectives", "Tour_Id", "dbo.Tours", "Id", cascadeDelete: true);
        }
    }
}
