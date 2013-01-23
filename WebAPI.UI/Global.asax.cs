using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using WebAPI.UI.App_Start;
using WebAPI.UI.Controllers;
using WebAPI.UI.Helper;
using WebAPI.UI.Migrations;
using WebAPI.UI.Models;

namespace WebAPI.UI
{
    public class WebApiApplication : HttpApplication
    {
        private void ConfigureApi(HttpConfiguration config)
        {
            var unity = new UnityContainer();
            unity.RegisterType<BooksController>();
            unity.RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new IoCContainer(unity);
        }

        protected void Application_Start()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BookStore>());

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigureApi(GlobalConfiguration.Configuration);
        }
    }
}