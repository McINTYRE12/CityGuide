namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedObjIdFromPhotoTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Photos", "objId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "objId", c => c.Int(nullable: false));
        }
    }
}
