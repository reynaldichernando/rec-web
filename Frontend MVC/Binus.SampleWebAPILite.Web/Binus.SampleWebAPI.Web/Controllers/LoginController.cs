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

        public ActionResult ResetPassword(string Email)
        {
            ViewBag.email = Email;
            return View("ResetPassword");
        }
        public ActionResult ChangePassword(string Email, string Password)
        {
            JsonResult Retdata = new JsonResult();

            if (Email != "" && Password != "") {
                try {
                    UserModel UserData = new UserModel {
                        Email = Email,
                        Name = "name",
                        Password = Password,
                        Role = "unapproved",
                        Username = Email
                    };
                    RESTResult Result = new REST(
                        Global.WebAPIBaseURL,
                        "/api/Training/RecDB/V1/App/User/ResetPassword",
                        REST.Method.POST,
                        ConfigurationManager.AppSettings["OAuthBookDB"],
                        UserData
                    ).Result;
                    if (Result.Success) {
                       
                            System.Diagnostics.Debug.WriteLine("succ");
                            return View("Index");

                    } else {    
                      
                    }

                } catch (Exception ex) {
                
                }
            } else {
            
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendAsync(string Email)
        {
            MailMessage message = new MailMessage();

            message.To.Add(Email);
            message.Subject = "Reset your password";
            //message.Body = "<form> <label>Topic</label> <input type='text' name='Topic' placeholder='Topic'/> <button type = 'submit' onsubmit='window.location.href = 'http://localhost:14033/Schedule/Index'> submit </button> </form>";
            //message.Body = "<form onsubmit='window.open(http://localhost:14033/Schedule/Index)'> <label>Topic</label> <input type='text' name='Topic' placeholder='Topic'/> <button type = 'submit' > submit </button> </form>";
            //commented by cs. email ga ngebolehin window.open/window.location.href ke halaman lain, there goes my 30 mins of time
            message.Body = "Please click the link below to reset your password <br> http://localhost:14033/Login/ResetPassword?Email="+Email;
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