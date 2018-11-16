﻿using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using SigmaDzuwenalia.Controllers;
using System.Reflection;
using SigmaDzuwenalia.BuisnessServices.Flanki;

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
            builder.RegisterWebApiFilterProvider(config);
            Container = builder.Build();
            return Container;
        }
    }
}