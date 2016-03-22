using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CityGuide.App_Start;
using System.Data.Entity;
using CG.DataAccess;

namespace CityGuide
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ContainerConfig.RegisterContainerDependencies();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<CityGuideContext>(null);
        }
    }
}
