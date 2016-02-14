namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "Objective_Id", c => c.Int());
            CreateIndex("dbo.Photos", "Objective_Id");
            AddForeignKey("dbo.Photos", "Objective_Id", "dbo.Objectives", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "Objective_Id", "dbo.Objectives");
            DropIndex("dbo.Photos", new[] { "Objective_Id" });
            DropColumn("dbo.Photos", "Objective_Id");
        }
    }
}
