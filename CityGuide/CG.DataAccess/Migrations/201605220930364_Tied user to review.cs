namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tiedusertoreview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "User_Id", c => c.Int());
            CreateIndex("dbo.Reviews", "User_Id");
            AddForeignKey("dbo.Reviews", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Reviews", "IdUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "IdUser", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reviews", "User_Id", "dbo.Users");
            DropIndex("dbo.Reviews", new[] { "User_Id" });
            DropColumn("dbo.Reviews", "User_Id");
        }
    }
}
