namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class step2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TourObjectives");
            CreateTable(
                "dbo.TourObjectives",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Tour_Id = c.Int(nullable: false),
                    Objective_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tours", t => t.Tour_Id, cascadeDelete: true)
                .ForeignKey("dbo.Objectives", t => t.Objective_Id, cascadeDelete: true)
                .Index(t => t.Tour_Id)
                .Index(t => t.Objective_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.TourObjectives", "Objective_Id", "dbo.Objectives");
            DropForeignKey("dbo.TourObjectives", "Tour_Id", "dbo.Tours");
            DropIndex("dbo.TourObjectives", new[] { "Objective_Id" });
            DropIndex("dbo.TourObjectives", new[] { "Tour_Id" });
            DropTable("dbo.TourObjectives");
        }
    }
}