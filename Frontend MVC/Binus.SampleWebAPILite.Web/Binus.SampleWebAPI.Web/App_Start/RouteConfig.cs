using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace Binus.SampleWebAPI.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            if (ConfigurationManager.AppSettings["DevelomentMode"].ToString() != "1")
            {
                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{type}/{id}",
                    defaults: new { controller = "Login", action = "Index", type = UrlParameter.Optional, id = UrlParameter.Optional }
                );
            }
            else
            {
                routes.MapRoute(
                  name: "Default",
                  url: "{controller}/{action}/{type}/{id}",
                  defaults: new { controller = "LoginDummy", action = "Index", type = UrlParameter.Optional, id = UrlParameter.Optional }
              );
            }
        }
    }
}
