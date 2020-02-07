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
            try
            {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Thread/DeleteThread",
                    REST.Method.POST,
                    Thread).Result;
                System.Diagnostics.Debug.WriteLine(Result.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index", "Thread");
        }
        public ActionResult UpdateThread(ThreadModel Thread)
        {

            try
            {
                Thread.UserID = Convert.ToInt32(Thread.UserID);
                Thread.ThreadID = Convert.ToInt32(Thread.ThreadID);

                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Thread/UpdateThread",
                    REST.Method.POST,
                    Thread).Result;
                System.Diagnostics.Debug.WriteLine(Result.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index", "Post");
        }

        public ActionResult CreateThread(ThreadModel Thread)
        {
            try
            {
                Thread.UserID = Convert.ToInt32(Session["UserID"]);
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Thread/InsertThread",
                    REST.Method.POST,
                    Thread).Result;
                System.Diagnostics.Debug.WriteLine(Result.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }

        public ActionResult ToPost(ThreadModel Thread)
        {
            Session["ThreadID"] = Thread.ThreadID;

            return RedirectToAction("Index", "Post");
        }

    }
}