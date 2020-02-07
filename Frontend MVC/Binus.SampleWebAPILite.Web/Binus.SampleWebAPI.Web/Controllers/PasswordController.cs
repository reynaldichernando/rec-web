using Binus.SampleWebAPI.Model.AppModel;
using Binus.SampleWebAPI.Web.Class;
using Binus.WebAPI.Model.Common;
using Binus.WebAPI.REST;
using System;
using System.Configuration;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Threading;
using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.Helper;

namespace Binus.SampleWebAPI.Web.Controllers
{
    public class PasswordController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult ResetPassword(string hash)
        {
            ViewBag.hash = hash;
            return View("Index");
        }
        public ActionResult ChangePassword(string Hash, string Email, string Password)
        {
            JsonResult Retdata = new JsonResult();
            SHA sha = new SHA();
            if (Hash.Equals("") || sha.GenerateSHA512String(Email).Equals(Hash)) {
                try {
                    UserModel UserData = new UserModel {
                        Email = Email,
                        Name = "",
                        Password = Password,
                        Role = "",
                        Username = Email
                    };
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

                } catch (Exception ex) {
                    throw ex;
                }
            }
        
            return Retdata;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendAsync(string Email)
        {
            MailMessage message = new MailMessage();
            SHA sha = new SHA();
            string hash = sha.GenerateSHA512String(Email);
            message.To.Add(Email);
            message.Subject = "Reset your password";
            message.Body = "Please click the link below to reset your password <br> http://localhost:14033/Login/ResetPassword?q=" + hash;
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

            return View();
        }




      
    }
}