using System.Web;
using System.Web.Optimization;

namespace Binus.SampleWebAPI.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Sources/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                       "~/Sources/Scripts/site.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Sources/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Sources/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Sources/Scripts/bootstrap.js",
                      "~/Sources/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Sources/CSS/bootstrap.css",
                       "~/Sources/CSS/bootstrap-custom.css",
                      "~/Sources/CSS/site.css"));
        }
    }
}
