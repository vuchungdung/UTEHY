﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using UTEHY.Infrastructure.Implementation;
using UTEHY.Infrastructure.Interfaces;
using UTEHY.Infrastructure.Utilities;
using UTEHY.Model.Entities;
using UTEHY.Service.Implementation;
using UTEHY.Service.Interfaces;

[assembly: OwinStartup(typeof(UTEHY.WebApp.App_Start.Startup))]

namespace UTEHY.WebApp.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutofac(app);
            ConfiguraAuth(app);
        }
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            // register controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            // register data infrastructure
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<FITDbContext>().AsSelf().InstancePerRequest();

            //Asp.net Identity
            builder.RegisterType<UserManager<User>>().As<UserManager<User>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<User>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();

            // register repositories
            builder.RegisterGeneric(typeof(RepositoryBase<,>)).As(typeof(IRepositoryBase<,>));

            //Logger
            builder.RegisterType<Logger>().As<Logger>().InstancePerRequest();
            // register services
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<PermissionService>().As<IPermissionService>().InstancePerRequest();
            builder.RegisterType<PostCategoryService>().As<IPostCategoryService>().InstancePerRequest();
            builder.RegisterType<FunctionService>().As<IFunctionService>().InstancePerRequest();
            builder.RegisterType<PostService>().As<IPostService>().InstancePerRequest();
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerRequest();
            builder.RegisterType<FacultyService>().As<IFacultyService>().InstancePerRequest();
            builder.RegisterType<TemplateService>().As<ITemplateService>().InstancePerRequest();



            // build and setup resolver
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver

        }
    }
}
