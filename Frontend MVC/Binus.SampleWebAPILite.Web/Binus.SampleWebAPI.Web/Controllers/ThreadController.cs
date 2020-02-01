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
            //try
            //{
            //    HomeViewModel VM = new HomeViewModel();

            //    RESTResult Result = new REST(
            //        Global.WebAPIBaseURL,
            //        "api/Training/RecDB/V1/App/Thread/GetAllThread",
            //        REST.Method.GET).Result;

            //    if (Result.Success)
            //    {
            //        VM.ListThread = Result.Deserialize<List<ThreadModel>>();
            //    }
            //    else
            //    {
            //        VM.ThreadBook = new List<ThreadModel>();
            //    }
            return View();

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}