namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "User", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "User");
        }
    }
}
