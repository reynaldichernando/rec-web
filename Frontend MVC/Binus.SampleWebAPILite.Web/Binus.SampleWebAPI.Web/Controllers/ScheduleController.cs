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
    public class ScheduleController:Controller
    {
        public ActionResult Index()
        {
            ScheduleViewModel VM = new ScheduleViewModel();
            try {

            RESTResult Result = new REST(
                Global.WebAPIBaseURL,
                "api/Training/RecDB/V1/App/Schedule/GetAllSchedule",
                REST.Method.GET).Result;
                if (Result.Success) {
                    VM.ListSchedule = Result.Deserialize<List<ScheduleModel>>();
                    return View(VM);
                }
            } catch(Exception ex) {
                throw ex;
            }

            return View();
        }

    public ActionResult DeleteSchedule(ScheduleModel Schedule)
        {

            try {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Schedule/DeleteSchedule",
                    REST.Method.POST,
                    Schedule).Result;
                System.Diagnostics.Debug.WriteLine(Result.Message);
            } catch(Exception ex) {
                throw ex;
            }

            return RedirectToAction("Index");
        }
        public ActionResult UpdateSchedule(ScheduleModel Schedule)
        {
            
            try {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Schedule/UpdateSchedule",
                    REST.Method.POST,
                    Schedule).Result;
                System.Diagnostics.Debug.WriteLine(Result.Message);
            } catch (Exception ex) {
                throw ex;
            }

            return RedirectToAction("Index");
        }

        public ActionResult CreateSchedule(ScheduleModel Schedule)
        {
            try {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Schedule/InsertSchedule",
                    REST.Method.POST,
                    Schedule).Result;
                System.Diagnostics.Debug.WriteLine(Result.Message);
            } catch (Exception ex) {
                throw ex;
            }

            return RedirectToAction("Index");
        }
    }
}