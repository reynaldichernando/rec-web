using System.Web.Http;
using System.Web.Optimization;
using System.Data.Entity;
using Binus.SampleWebAPI.WebAPI.App_Start.JWT;

namespace Binus.SampleWebAPI.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.EnsureInitialized();
            GlobalConfiguration.Configure(FilterConfig.Configure);
            // ModelBinders.Binders.Add(typeof(ObjectId), new ObjectIdModelBinder());
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
