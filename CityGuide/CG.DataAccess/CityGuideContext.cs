namespace CG.DataAccess
{
    using System.Data.Entity;
    using Domain;
    public class CityGuideContext : DbContext
    {

        public void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public CityGuideContext()
            : base("name=CityGuideContext")
        {
        }

        public virtual DbSet<Objective> Objectives { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
    }
}