namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUsersLazyLoading : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Review_Id", "dbo.Reviews");
            DropIndex("dbo.Users", new[] { "Review_Id" });
            DropColumn("dbo.Users", "Review_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Review_Id", c => c.Int());
            CreateIndex("dbo.Users", "Review_Id");
            AddForeignKey("dbo.Users", "Review_Id", "dbo.Reviews", "Id");
        }
    }
}
