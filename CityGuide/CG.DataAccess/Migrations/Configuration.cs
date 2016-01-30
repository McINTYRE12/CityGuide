namespace CG.DataAccess.Migrations
{
    using Domain;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CityGuideContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CityGuideContext context)
        {

        }
    }
}
