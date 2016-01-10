namespace CG.DataAccess
{
    using System.Data.Entity;
    using Domain;
    public class CityGuideContext : DbContext
    {
        // Your context has been configured to use a 'CityGuideContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CG.DataAccess.CityGuideContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CityGuideContext' 
        // connection string in the application configuration file.
        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public CityGuideContext()
            : base("name=CityGuideContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Objective> Objectives { get; set; }
    }
}