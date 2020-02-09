using Binus.SampleWebAPI.Model.AppModel;
using Binus.SampleWebAPI.Web.Class;
using Binus.SampleWebAPI.Web.ViewModels;
using Binus.WebAPI.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Binus.SampleWebAPI.Web.Controllers
{
    public class ThreadController:Controller
    {
        public ActionResult Index()
        {
            ThreadViewModel VM = new ThreadViewModel();
            try
            {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Thread/GetAllThread",
                    REST.Method.GET).Result;
                if (Result.Success)
                {
                    VM.ListThread = Result.Deserialize<List<ThreadModel>>();
                    return View(VM);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }

        public ActionResult DeleteThread(ThreadModel Thread)
        {
            JsonResult Retdata;
            try
            {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Thread/DeleteThread",
                    REST.Method.POST,
                    Thread).Result;
                if (Result.Success)
                {
                    Retdata = Json(new
                    {
                        URL = Global.BaseURL + "/Thread",
                        Status = "Success",
                        Message = "Delete Success",
                    });
                }
                else
                {
                    Retdata = Json(new
                    {
                        URL = Global.BaseURL,
                        Status = "Failed",
                        Message = "Delete failed",
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retdata;
        }
        [HttpPost]
        public ActionResult UpdateThread(ThreadModel Thread)
        {
            JsonResult Retdata;
            try
            {
                Thread.ThreadID = Convert.ToInt32(Session["ThreadID"]);
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Thread/UpdateThread",
                    REST.Method.POST,
                    Thread).Result;
                if (Result.Success)
                {
                    Retdata = Json(new
                    {
                        URL = Global.BaseURL + "/Post/Index",
                        Status = "Success",
                        Message = "Update Success",
                    });
                }
                else
                {
                    Retdata = Json(new
                    {
                        URL = Global.BaseURL,
                        Status = "Failed",
                        Message = "Update failed",
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retdata;
        }

        public ActionResult GetOneThread(int ThreadID)
        {
            JsonResult retData = new JsonResult();
            try
            {
                RESTResult Result = (new REST(Global.WebAPIBaseURL,"api/Training/RecDB/V1/App/Thread/GetOneThread?ThreadID=" + ThreadID, REST.Method.GET)).Result;

                if (Result.Success)
                {
                    retData = Json(new
                    {
                        Status = "Success",
                        Message = "Get Thread Success!",
                        Data = Result.Deserialize<ThreadModel>()
                    });
                }
                else
                {
                    retData = Json(new
                    {
                        Status = "Failed",
                        Message = "Failed When Getting Data.."
                    });
                }
            }
            catch (Exception ex)
            {
                retData = Json(new
                {
                    Status = "Failed",
                    Message = ex.Message
                });
            }

            return retData;
        }

        public ActionResult CreateThread(ThreadModel Thread)
        {

            JsonResult Retdata;
            try
            {
                Thread.UserID = Convert.ToInt32(Session["UserID"]);
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Thread/InsertThread",
                    REST.Method.POST,
                    Thread).Result;

                if (Result.Success)
                {
                    Retdata = Json(new
                    {
                        Status = "Success",
                        Message = "Create Thread Success!",
                        URL = Global.BaseURL + "/Thread",
                    });
                }
                else
                {
                    Retdata = Json(new
                    {
                        Status = "Failed",
                        Message = "Create Thread Failed!",
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Retdata;
        }

        public ActionResult ToPost(ThreadModel Thread)
        {
            Session["ThreadID"] = Thread.ThreadID;

            return RedirectToAction("Index", "Post");
        }

    }
}