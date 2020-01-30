using System;
using System.Linq;
using System.Web.Mvc;

namespace Binus.SampleWebAPI.Web.App_Start
{
    public class CustomViewEngine : RazorViewEngine
    {
        public CustomViewEngine()
        {
            var viewLocations = new[] {
            "~/Views/{1}/{0}.cshtml",
            "~/Views/%2/{1}/{0}.cshtml",
            "~/Views/%2/%1/{1}/{0}.cshtml",
            // etc
            };

            this.PartialViewLocationFormats = viewLocations;
            this.ViewLocationFormats = viewLocations;
        }

        protected override IView CreatePartialView(ControllerContext ControllerContext, string PartialPath)
        {
            var SiteCode = GeValue(ControllerContext);
           
            return base.CreatePartialView(ControllerContext, PartialPath.Replace("%1", SiteCode[1]).Replace("%2", SiteCode[0]));
        }


        protected override IView CreateView(ControllerContext ControllerContext, string ViewPath, string MasterPath)
        {
            var SiteCode = GeValue(ControllerContext);
            return base.CreateView(ControllerContext, ViewPath.Replace("%1", SiteCode[0]).Replace("%2", SiteCode[1]), MasterPath.Replace("%1", SiteCode[0]).Replace("%2", SiteCode[1]));
        }


        protected override bool FileExists(ControllerContext ControllerContext, string VirtualPath)
        {
            var SiteCode = GeValue(ControllerContext);
            return base.FileExists(ControllerContext, VirtualPath.Replace("%1", SiteCode[0]).Replace("%2", SiteCode[1]));
        }

        private static string[] GeValue(ControllerContext ControllerContext)
        {
            //var result = ValueProviderFactories.Factories.GetValueProvider(controllerContext).GetValue(key);
            var Controller = ControllerContext.Controller;
            var Result = ControllerContext.RouteData;
            string[] ReturnData = new string[2];
            String[] Namespace = Controller.ToString().Split(".".ToCharArray());

            ReturnData[0] = Namespace[(Namespace.Count()-2)].ToString();
            ReturnData[1] = Namespace[(Namespace.Count()-3)].ToString();
            //if (Result.Values.Count > 2)
            //{
            //    ReturnData[1] = Result.Values["type"].ToString();

            //}
            //else
            //{
            //    ReturnData[1] =null;

            //}

            return ReturnData;
        }
    }
}