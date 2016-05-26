namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addetransportslisttotour : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transports", "Tour_Id", c => c.Int());
            CreateIndex("dbo.Transports", "Tour_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Transports", new[] { "Tour_Id" });
            DropColumn("dbo.Transports", "Tour_Id");
        }
    }
}
