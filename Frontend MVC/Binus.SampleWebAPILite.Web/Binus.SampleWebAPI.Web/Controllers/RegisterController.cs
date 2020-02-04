using Binus.SampleWebAPI.Model.AppModel;
using Binus.SampleWebAPI.Web.Class;
using Binus.WebAPI.Model.Common;
using Binus.WebAPI.REST;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace Binus.SampleWebAPI.Web.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

  
        [ValidateAntiForgeryToken]
        public ActionResult RegisterAccount(string Name, string Email, string Password)
        {
            JsonResult Retdata = new JsonResult();

            if (Email != "" && Password != "") {
                try {
                    UserModel UserData = new UserModel {
                        Email = Email,
                        Name = Name,
                        Password = Password,
                        Role = "unapproved",
                        Username = Email
                    };
                    RESTResult Result = new REST(
                        Global.WebAPIBaseURL,
                        "/api/Training/RecDB/V1/App/User/RegisterUser",
                        REST.Method.POST,
                        ConfigurationManager.AppSettings["OAuthBookDB"],
                        UserData
                    ).Result;
                    if (Result.Success) {
                        UserModel User = Result.Deserialize<UserModel>();

                        if (User != null) {
                            Retdata = Json(new {
                                Status = "Success",
                                Message = "Regis Success",
                                URL = Global.BaseURL
                            });
                        } else {
                            Retdata = Json(new {
                                Status = "Failed",
                                Message = "User not found"
                            });
                        }

                    } else {
                        Retdata = Json(new {
                            Status = "Failed",
                            Message = Result.Message
                        });
                    }

                } catch (Exception ex) {
                    Retdata = Json(new {
                        Status = "Failed",
                        Message = ex.Message
                    });
                }
            } else {
                Retdata = Json(new {
                    Status = "Failed",
                    Message = "Username or Password cannot be empty"
                });
            }

            Retdata.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return Retdata;
        }

      
    }
}