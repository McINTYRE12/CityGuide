using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using CG.DataAccess;
using CG.Domain;
using CityGuide.Application;

namespace CityGuide.App_Start
{
    public class ContainerConfig
    {

        public static void RegisterContainerDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            builder.RegisterType<CityGuideContext>().InstancePerRequest();
            builder.RegisterType<CityGuideDatabase>().As<ICityGuideDatabase>().InstancePerRequest();
            builder.RegisterType<ObjectivesWorkerService>().InstancePerRequest();
            builder.RegisterType<CategoriesWorkerService>().InstancePerRequest();
            builder.RegisterType<ToursWorkerService>().InstancePerRequest();
            builder.RegisterType<UsersWorkerService>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}