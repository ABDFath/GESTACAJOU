using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GESTACAJOU
{
    // Remarque : pour obtenir des instructions sur l'activation du mode classique IIS6 ou IIS7, 
    // visitez http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Nom d'itinéraire
                "{controller}/{action}/{id}", // URL avec des paramètres
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Paramètres par défaut
            );

        }

        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();

            //// Utiliser LocalDB pour Entity Framework par défaut
            //Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            //RegisterGlobalFilters(GlobalFilters.Filters);
            //RegisterRoutes(RouteTable.Routes);

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            string instanceName = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SC.Core.DbLink.AddConnectionString(instanceName);

            SC.Framework.UsrMgt.Message.SetConnection(SC.Core.DbLink.Instance.Connection);

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (HttpContext.Current.Session != null)
            {
                Server.ClearError();
                Session["ErrorHandle"] = exception.Message;
                Response.Redirect("/LoginSk/GeneralFailure", true);
            }
        }
    }
}