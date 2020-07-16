﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using Owin;
using UTEHY.Infrastructure.Implementation;
using UTEHY.Infrastructure.Interfaces;
using UTEHY.Service.Implementation;
using UTEHY.Service.Interfaces;

[assembly: OwinStartup(typeof(UTEHY.WebApp.Startup))]

namespace UTEHY.WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutofac(app);
        }
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            // register controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // register services
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<PostService>().As<IPostService>().InstancePerRequest();
            builder.RegisterType<CommandService>().As<ICommandService>().InstancePerRequest();
            builder.RegisterType<FunctionService>().As<IFunctionService>().InstancePerRequest();
            builder.RegisterType<PermissionService>().As<IPermissionService>().InstancePerRequest();

            // register data infrastructure
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // register repositories
            builder.RegisterGeneric(typeof(RepositoryBase<,>)).As(typeof(IRepositoryBase<,>));

            // build and setup resolver
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
