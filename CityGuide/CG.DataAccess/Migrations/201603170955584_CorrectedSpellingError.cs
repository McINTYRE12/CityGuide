namespace CG.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedSpellingError : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "ScoreGiven", c => c.Int(nullable: false));
            DropColumn("dbo.Reviews", "ScoreGive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "ScoreGive", c => c.Int(nullable: false));
            DropColumn("dbo.Reviews", "ScoreGiven");
        }
    }
}
