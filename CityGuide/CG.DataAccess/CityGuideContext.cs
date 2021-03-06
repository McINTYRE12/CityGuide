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
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<ObjectiveTour> ObjectiveTour { get; set; }
        public virtual DbSet<Transport> Transports { get; set; }
        public virtual DbSet<TransportTour> TransportTour { get; set; }
        public virtual DbSet<TourReview> TourReviews{ get; set; }
    }
}