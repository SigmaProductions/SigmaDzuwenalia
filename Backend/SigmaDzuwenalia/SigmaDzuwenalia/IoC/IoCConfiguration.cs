using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using SigmaDzuwenalia.Controllers;
using System.Reflection;
using SigmaDzuwenalia.BuisnessServices.Flanki;
using SigmaDzuwenalia.DataAccess.Context;
using SigmaDzuwenalia.DataAccess.Factories;
using SigmaDzuwenalia.DataAccess.Providers;
using SigmaDzuwenalia.DataAccess.Repositories;
using SigmaDzuwenalia.BuisnessServices.Repositories;
using SigmaDzuwenalia.BuisnessServices.Police;
using SigmaDzuwenalia.BuisnessServices.DropPlace;

namespace SigmaDzuwenalia.IoC
{
    public class IoCConfiguration
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder(), config));
        }
        private static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
        private static IContainer RegisterServices(ContainerBuilder builder, HttpConfiguration config)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<FlankiController>().InstancePerLifetimeScope();
            builder.RegisterType<FlankiService>().As<IFlankiService>().InstancePerLifetimeScope();
            builder.RegisterType<FlankiRepository>().As<IFlankiRepository>().InstancePerLifetimeScope();

            builder.RegisterType<PoliceController>().InstancePerLifetimeScope();
            builder.RegisterType<PoliceService>().As<IPoliceService>().InstancePerLifetimeScope();

            builder.RegisterType<DropPlaceController>().InstancePerLifetimeScope();
            builder.RegisterType<DropPlaceService>().As<IDropPlaceService>().InstancePerLifetimeScope();

            builder.RegisterType<DzuwenaliaDBContext>().As<IDzuwenaliaDBContext>().InstancePerLifetimeScope();
            builder.RegisterType<DzuwenaliaDBContextFactory>().As<IDzuwenaliaDBContextFactory>().InstancePerLifetimeScope();
            builder.RegisterType<DatabaseSettingsProvider>().As<IDatabaseSettingsProvider>().InstancePerLifetimeScope();
            builder.RegisterWebApiFilterProvider(config);
            Container = builder.Build();
            return Container;
        }
    }
}