using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;

namespace Binus.SampleWebAPI.Web.App_Start
{
    public class BasicAuthenticationAttribute : ActionFilterAttribute
    {
      
        public override void OnActionExecuting(ActionExecutingContext ActionContext)
        {
           
            if (ActionContext.HttpContext.Session["ActiveUser"] == null)
            {
                if (ActionContext.HttpContext.Request.IsAjaxRequest())
                {
                    /*ActionContext.Result = new JsonResult
                    {
                        Data = new
                        {
                            message = "signout"
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };*/
                    string Address = ActionContext.HttpContext.Request.Url.Scheme + "://" + ActionContext.HttpContext.Request.Url.Authority + ActionContext.HttpContext.Request.ApplicationPath.TrimEnd('/');
                    ActionContext.HttpContext.Response.StatusCode = 401;
                    ActionContext.HttpContext.Response.Write(Address + "/Login/Index");

                    ActionContext.HttpContext.Response.End();
                }
                else
                {                   
                    ActionContext.HttpContext.Session["URLCallback"] = ActionContext.HttpContext.Request.Url.ToString();

                    ActionContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = "Login",
                        action = "Index"
                    }));

                }
               
            }
            
            
            return;
        }
    }
}