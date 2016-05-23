namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tiedusertotour : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tours", "User_Id", c => c.Int());
            CreateIndex("dbo.Tours", "User_Id");
            AddForeignKey("dbo.Tours", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Tours", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tours", "UserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tours", "User_Id", "dbo.Users");
            DropIndex("dbo.Tours", new[] { "User_Id" });
            DropColumn("dbo.Tours", "User_Id");
        }
    }
}
