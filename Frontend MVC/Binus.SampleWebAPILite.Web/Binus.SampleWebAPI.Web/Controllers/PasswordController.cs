using Binus.SampleWebAPI.Model.AppModel;
using Binus.SampleWebAPI.Web.Class;
using Binus.WebAPI.REST;
using System;
using System.Configuration;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Threading;
using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.Helper;
using Binus.WebAPI.Model.Common;

namespace Binus.SampleWebAPI.Web.Controllers
{
    public class PasswordController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult ResetPassword(string e,string q)
        {
            ViewBag.email = e;
            ViewBag.token = q;
            return View("Index");
        }
        [HttpPost]
        public ActionResult ChangeForgottenPassword(string Token, string Email, string Password)
        {
            JsonResult Retdata = new JsonResult();
            UserModel UserData = new UserModel {
                Email = Email,
                Name = "",
                Password = Password,
                Role = "",
                Username = Email
            };

            try {
                RESTResult GetUserToken = new REST(
                Global.WebAPIBaseURL,
                "/api/Training/RecDB/V1/App/User/GetUserToken",
                REST.Method.POST,
                ConfigurationManager.AppSettings["OAuthBookDB"],
                UserData
                ).Result;
                String UserToken = GetUserToken.Deserialize<String>();
                if (UserToken.Equals(Token)) {
                    try {
                        RESTResult Result = new REST(
                            Global.WebAPIBaseURL,
                            "/api/Training/RecDB/V1/App/User/ChangePassword",
                            REST.Method.POST,
                            ConfigurationManager.AppSettings["OAuthBookDB"],
                            UserData
                        ).Result;
                        if (Result.Success) {
                            Retdata = Json(new {
                                Status = "Success",
                                Message = "Change password success",
                                URL = Global.BaseURL + "/Login/Index"
                            });

                        } else {
                            Retdata = Json(new {
                                Status = "Failed",
                                Message = "Change password failed",
                                URL = Global.BaseURL + "/Login/Index"
                            });
                        }
                        try {
                            RESTResult DeleteUserToken = new REST(
                                Global.WebAPIBaseURL,
                                "/api/Training/RecDB/V1/App/User/DeleteUserToken",
                                REST.Method.POST,
                                ConfigurationManager.AppSettings["OAuthBookDB"],
                                UserData
                            ).Result;
                        } catch(Exception ex) {

                        }
                    } catch(Exception ex) {

                    }
                   
                } else {
                    Retdata = Json(new {
                        Status = "Failed",
                        Message = "Invalid token",
                        URL = Global.BaseURL + "/Login/Index"
                    });
                }
            } catch (Exception ex) {
                throw ex;
            }
                 
            return Retdata;
        }

        [HttpGet]
        public async Task<ActionResult> SendAsync(string Email)
        {
            UserModel User = new UserModel();
            User.Username = Email;
            User.Email = Email;
            try {
                try {
                   
                    RESTResult Result = new REST(
                    BaseURL: Global.WebAPIBaseURL,
                    URL : "/api/Training/RecDB/V1/App/User/GenerateUserToken",
                    Method: REST.Method.POST,
                    OAuth :ConfigurationManager.AppSettings["OAuthBookDB"],
                    Data: User
                ).Result;
                } catch (Exception ex) {
                    throw ex;
                }
                RESTResult GetToken = new REST(
                    Global.WebAPIBaseURL,
                    "/api/Training/RecDB/V1/App/User/GetUserToken",
                    REST.Method.POST,
                    ConfigurationManager.AppSettings["OAuthBookDB"],
                    User
                ).Result;
                String Token = GetToken.Deserialize<String>();
                MailMessage message = new MailMessage();
                message.To.Add(Email);
                message.Subject = "Reset your password";
                message.Body = "Please click the link below to reset your password <br> http://localhost:14033/Password/ResetPassword?e=" + Email+"&q="+Token;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.From = new MailAddress("c.soetanto37@gmail.com");
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient()) {
                    var credential = new NetworkCredential {
                        UserName = "c.soetanto37@gmail.com",
                        Password = "ASDFGHJKLzxcvbnm!@#"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);

                }
            } catch(Exception ex) {
                throw ex;
            }

            return RedirectToAction("Index", "Login");
        }

      
    }
}