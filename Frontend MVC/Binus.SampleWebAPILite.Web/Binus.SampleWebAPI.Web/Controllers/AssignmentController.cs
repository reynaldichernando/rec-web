using Binus.SampleWebAPI.Model.AppModel;
using Binus.SampleWebAPI.Web.Class;
using Binus.SampleWebAPI.Web.ViewModels;
using Binus.WebAPI.REST;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Web.Controllers
{
    public class AssignmentController : Controller
    {
        // GET: Assignment
        public ActionResult Index()
        {
            if (Session["token"] == null) return RedirectToAction("Index", "Login");

            try
            {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "/api/Training/RecDB/V1/App/Assignment/GetAllAssignment",
                    REST.Method.GET).Result;

                AssignmentViewModel avm = new AssignmentViewModel();
                avm.assignments = Result.Deserialize<List<AssignmentModel>>();


                return View("Index", avm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Insert(AssignmentModel Model)
        {
            JsonResult retData = new JsonResult();
            try
            {
                RESTResult Result;
                if (Model.AssignmentID == 0)
                {
                    Result = (new REST(Global.WebAPIBaseURL, "/api/Training/RecDB/V1/App/Assignment/InsertAssignment", REST.Method.POST, Model)).Result;
                }
                else
                {
                    Result = (new REST(Global.WebAPIBaseURL, "/api/Training/RecDB/V1/App/Assignment/UpdateAssignment", REST.Method.POST, Model)).Result;
                }

                if (Result.Success)
                {
                    retData = Json(new
                    {
                        Status = "Success",
                        Message = "Insert Assignment Success!",
                        URL = Global.BaseURL + "/Assignment"
                    });
                }
                else
                {
                    retData = Json(new
                    {
                        Status = "Failed",
                        Message = "Failed When Inserting Data.."
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

        public ActionResult Delete(AssignmentModel Model)
        {
            JsonResult retData = new JsonResult();
            try
            {
                RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/RecDB/V1/App/Assignment/DeleteAssignment", REST.Method.POST, Model)).Result;

                if (Result.Success)
                {
                    retData = Json(new
                    {
                        Status = "Success",
                        Message = "Delete Assignment Success!",
                        URL = Global.BaseURL + "/Assignment"
                    });
                }
                else
                {
                    retData = Json(new
                    {
                        Status = "Failed",
                        Message = "Failed When Deleting Data.."
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

        public ActionResult GetAssignment(int AssignmentID)
        {
            JsonResult retData = new JsonResult();
            try
            {
                RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/RecDB/V1/App/Assignment/GetAssignment?AssignmentID="+AssignmentID, REST.Method.GET)).Result;

                if (Result.Success)
                {
                    retData = Json(new
                    {
                        Status = "Success",
                        Message = "Get Assignment Success!",
                        Data = Result.Deserialize<AssignmentModel>()
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
    }
}