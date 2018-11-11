using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using StudentNewsSite.BLL;
using StudentNewsSite.BLL.Modules;
using StudentNewsSite.Utilites;

namespace StudentNewsSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule studentModule = new StudentModule();
            NinjectModule postModule = new PostModule();
            NinjectModule serviceModule = new ServiceModule();
            NinjectModule tagModule = new TagModule();
            NinjectModule commentModule = new CommentModule();
            NinjectModule autoMapper = new AutoMapperModule();
            var kernel = new StandardKernel(studentModule,postModule,serviceModule,tagModule,commentModule,autoMapper);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
