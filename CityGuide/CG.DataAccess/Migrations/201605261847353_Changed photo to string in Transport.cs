namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedphototostringinTransport : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transports", "Icon_Id", "dbo.Photos");
            DropIndex("dbo.Transports", new[] { "Icon_Id" });
            AddColumn("dbo.Transports", "IconUrl", c => c.String());
            DropColumn("dbo.Transports", "Icon_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transports", "Icon_Id", c => c.Int());
            DropColumn("dbo.Transports", "IconUrl");
            CreateIndex("dbo.Transports", "Icon_Id");
            AddForeignKey("dbo.Transports", "Icon_Id", "dbo.Photos", "Id");
        }
    }
}
