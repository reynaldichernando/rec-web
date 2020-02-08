using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Binus.SampleWebAPI.Model.AppModel;
using Binus.SampleWebAPI.Web.Class;
using Binus.SampleWebAPI.Web.ViewModels;
using Binus.WebAPI.REST;
using System.Web.Mvc;
using System.Configuration;

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
            return View("Index", "Login");
        }

    public ActionResult GetScheduleByID(string ScheduleID)
        {
            JsonResult retData = new JsonResult();
            try {
                RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/RecDB/V1/App/Schedule/GetScheduleByID?ScheduleID=" + ScheduleID, REST.Method.GET)).Result;
                ScheduleModel Schedule = Result.Deserialize<ScheduleModel>();
                if (Result.Success) {
                    retData = Json(new {
                        Status = "Success",
                        Message = "Get Schedule Success!",
                        Data = new {
                            ScheduleID = Schedule.ScheduleID,
                            Place = Schedule.Place,
                            StartTime = Schedule.StartTime.ToString("s"),
                            EndTime = Schedule.EndTime.ToString("s"),
                            Topic = Schedule.Topic,
                            Description = Schedule.Description
                        }});
                } else {
                    retData = Json(new {
                        Status = "Failed",
                        Message = "Failed When Getting Data.."
                    });
                }
            } catch (Exception ex) {
                retData = Json(new {
                    Status = "Failed",
                    Message = ex.Message
                });
            }
            return retData;
        }
    public ActionResult DeleteSchedule(string ScheduleID)
        {
            JsonResult Retdata;
            try {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Schedule/DeleteScheduleByID?ScheduleID="+ScheduleID,
                    REST.Method.GET,
                    ScheduleID).Result;
                if (Result.Success) {
                    Retdata = Json(new {
                        URL = Global.BaseURL + "/Schedule",
                        Status = "Success",
                        Message = "Delete Success",
                    });
                } else {
                    Retdata = Json(new {
                        URL = Global.BaseURL,
                        Status = "Failed",
                        Message = "Delete failed",
                    });
                }
            } catch(Exception ex) {
                throw ex;
            }

            return Retdata;
        }
        public ActionResult UpdateSchedule(ScheduleModel Schedule)
        {
            JsonResult Retdata;
            try {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Schedule/UpdateSchedule",
                    REST.Method.POST,
                    new {
                        ScheduleID = Schedule.ScheduleID,
                        Place = Schedule.Place,
                        StartTime = Schedule.StartTime.ToString("s"),
                        EndTime = Schedule.EndTime.ToString("s"),
                        Topic = Schedule.Topic,
                        Description = Schedule.Description
                    }).Result;
                if (Result.Success) {
                    Retdata = Json(new {
                        URL = Global.BaseURL + "/Schedule",
                        Status = "Success",
                        Message = "Update Success",
                    });
                } else {
                    Retdata = Json(new {
                        URL = Global.BaseURL,
                        Status = "Failed",
                        Message = "Update failed",
                    });
                }
            } catch (Exception ex) {
                throw ex;
            }
            Retdata.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return Retdata;
        }

        public ActionResult CreateSchedule(ScheduleModel Schedule)
        {
            JsonResult Retdata;
            try {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Schedule/InsertSchedule",
                    REST.Method.POST,
                    new {
                        ScheduleID = Schedule.ScheduleID,
                        Place = Schedule.Place,
                        StartTime = Schedule.StartTime.ToString("s"),
                        EndTime = Schedule.EndTime.ToString("s"),   
                        Topic = Schedule.Topic,
                        Description = Schedule.Description
                    }).Result;
                if (Result.Success) {
                    Retdata = Json(new {
                        Status = "Success",
                        Message = "Create Schedule Success!",
                        URL = Global.BaseURL + "/Schedule",
                    });
                } else {
                    Retdata = Json(new {
                        Status = "Failed",
                        Message = "Create Schedule Failed!",
                    });
                }
            } catch (Exception ex) {
                throw ex;
            }

            return Retdata;

        }
    }
}