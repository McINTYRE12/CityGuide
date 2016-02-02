namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedObjectivesTableToIncludeCategoryAndScore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Objectives", "Name", c => c.String());
            AddColumn("dbo.Objectives", "Score", c => c.Int(nullable: false));
            AddColumn("dbo.Objectives", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Objectives", "Category");
            DropColumn("dbo.Objectives", "Score");
            DropColumn("dbo.Objectives", "Name");
        }
    }
}
