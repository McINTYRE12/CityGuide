namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAddressToObjectives : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Objectives", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Objectives", "Address");
        }
    }
}
