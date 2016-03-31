namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LazyLoadingForReviewUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Review_Id", c => c.Int());
            CreateIndex("dbo.Users", "Review_Id");
            AddForeignKey("dbo.Users", "Review_Id", "dbo.Reviews", "Id");
            DropColumn("dbo.Reviews", "User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "User", c => c.String());
            DropForeignKey("dbo.Users", "Review_Id", "dbo.Reviews");
            DropIndex("dbo.Users", new[] { "Review_Id" });
            DropColumn("dbo.Users", "Review_Id");
        }
    }
}
