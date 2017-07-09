using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using System.Data.Entity;

namespace ReactASPNetMVCDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //register context, models, repos and services
            builder.RegisterType<DemoConnectionProvider>().As<IConnectionProvider>();
            builder.RegisterType<DemoContext>().As<DbContext>();
            builder.RegisterType<ContactRepository>().As<IRepository<ContactUs>>();
            builder.RegisterType<ContactService>().As<IContactService<ContactUs>>();

            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
