using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Binus.SampleWebAPI.Model.AppModel;
using Binus.SampleWebAPI.Web.Class;
using Binus.SampleWebAPI.Web.ViewModels;
using Binus.WebAPI.REST;
using System.Web.Mvc;

namespace Binus.SampleWebAPI.Web.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            UserViewModel VM = new UserViewModel();
            try {

                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/User/GetUnapprovedUser",
                    REST.Method.GET).Result;
                if (Result.Success) {
                    VM.ListUser = Result.Deserialize<List<UserModel>>();
                    return View(VM);
                }
            } catch (Exception ex) {
                throw ex;
            }

            return View();
        }

        public ActionResult VerifyUser(UserModel User)
        {
            try {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/User/VerifyUser",
                    REST.Method.POST,
                    User).Result;
                System.Diagnostics.Debug.WriteLine(Result.Message);
            } catch (Exception ex) {
                throw ex;
            }

            return RedirectToAction("Index");
        }
      
    }
}