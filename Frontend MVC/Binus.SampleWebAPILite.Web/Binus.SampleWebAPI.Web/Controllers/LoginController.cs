using Binus.SampleWebAPI.Model.AppModel;
using Binus.SampleWebAPI.Web.Class;
using Binus.WebAPI.Model.Common;
using Binus.WebAPI.REST;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace Binus.SampleWebAPI.Web.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            //3 cara untuk hapus session
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public ActionResult Auth(string Username, string Password)
        {
            JsonResult Retdata;

            if(Username != "" && Password != "")
            {
                try
                {
                    AuthUser UserData = new AuthUser();
                    UserData.Email = Username;
                    UserData.Username = Username;
                    UserData.Password = Password;

                    RESTResult Result = new REST(
                        Global.WebAPIBaseURL,
                        "/api/Training/RecDB/V1/App/User/GetUserLogin",
                        REST.Method.POST,
                        ConfigurationManager.AppSettings["OAuthBookDB"],
                        UserData
                    ).Result;

                    if(Result.Success)
                    {
                        UserModel User = Result.Deserialize<UserModel>();

                        if(User != null)
                        {
                            Retdata = Json(new
                            {
                                Status = "Success",
                                Message = "Login Success",
                                URL = Global.BaseURL + "/Schedule/Index"
                            });
                        }else
                        {
                            Retdata = Json(new
                            {
                                Status = "Failed",
                                Message = "User not found"
                            });
                        }
                        
                    }else
                    {
                        Retdata = Json(new
                        {
                            Status = "Failed",
                            Message = Result.Message
                        });
                    }

                }
                catch (Exception ex)
                {
                    Retdata = Json(new
                    {
                        Status = "Failed",
                        Message = ex.Message
                    });
                }
            }
            else
            {
                Retdata = Json(new
                {
                    Status = "Failed",
                    Message = "Username or Password cannot be empty"
                });
            }

            Retdata.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return Retdata;
        }
    }
}