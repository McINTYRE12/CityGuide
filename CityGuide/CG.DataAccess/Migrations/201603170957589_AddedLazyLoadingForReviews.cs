namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLazyLoadingForReviews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Objective_Id", c => c.Int());
            CreateIndex("dbo.Reviews", "Objective_Id");
            AddForeignKey("dbo.Reviews", "Objective_Id", "dbo.Objectives", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Objective_Id", "dbo.Objectives");
            DropIndex("dbo.Reviews", new[] { "Objective_Id" });
            DropColumn("dbo.Reviews", "Objective_Id");
        }
    }
}
