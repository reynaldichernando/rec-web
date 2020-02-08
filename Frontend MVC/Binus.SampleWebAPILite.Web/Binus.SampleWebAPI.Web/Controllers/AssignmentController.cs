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
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

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
                Model.AssignmentFilepath = "./Assignment/" + Model.Title + "/" + Model.AssignmentFilepath;
                if (Model.AssignmentID == 0)
                {
                    Result = (new REST(Global.WebAPIBaseURL, "/api/Training/RecDB/V1/App/Assignment/InsertAssignment", REST.Method.POST, 
                        new { 
                            Title = Model.Title,
                            Description = Model.Description,
                            AssignmentFilepath = Model.AssignmentFilepath,
                            DateDue = Model.DateDue.ToString("s")
                        })).Result;

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
                    AssignmentModel model = Result.Deserialize<AssignmentModel>();
                    var temp = new { 
                        AssignmentID = model.AssignmentID,
                        Title = model.Title,
                        Description = model.Description,
                        AssignmentFilepath = model.AssignmentFilepath,
                        DateDue = model.DateDue.ToString("s"),
                        DateUploaded = model.DateUploaded.ToString("s")
                    };
                    retData = Json(new
                    {
                        Status = "Success",
                        Message = "Get Assignment Success!",
                        Data = temp
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

        public ActionResult UploadAnswer(AnswerModel Model, string Title)
        {
            JsonResult retData = new JsonResult();
            try
            {
                RESTResult Result;
                Model.AnswerFilepath = "./Answer/" + Title + "/" + Model.UserID + "/"+ Model.AnswerFilepath;
                Result = (new REST(Global.WebAPIBaseURL, "/api/Training/RecDB/V1/App/Answer/InsertAnswer", REST.Method.POST, Model)).Result;

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

        [HttpGet]
        public async Task<ActionResult> DownloadAnswer(string AssignmentID)
        {
            string UserID = Session["UserID"].ToString();
            JsonResult retData = new JsonResult();
            try
            {
                RESTResult Result;
                Result = (new REST(Global.WebAPIBaseURL, "/api/Training/RecDB/V1/App/Answer/GetAnswer?AssignmentID="+AssignmentID+"&UserID="+UserID, REST.Method.GET)).Result;

                if (Result.Success)
                {
                    AnswerModel Model = Result.Deserialize<AnswerModel>();
                    return await DownloadFile(Model.AnswerFilepath);
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

        [HttpGet]
        public ActionResult CheckAnswer(int AssignmentID)
        {
            return RedirectToAction("Index", "Answer", new { id = AssignmentID });
        }

        [HttpPost]
        public async Task<ActionResult> Upload(HttpPostedFileBase file, String path)
        {

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=recprojectstorage;AccountKey=wMy00xgnLUx0QVAE+ulUMOt0512O1VFheAflKAfuNqqXv2z6m1EtgVTx9Bcf/TED3WKJa3uTsqxmskoFRewnQQ==;EndpointSuffix=core.windows.net");
            CloudBlobClient BlobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer storageContainer = BlobClient.GetContainerReference("test");
            try
            {
                if (file.ContentLength > 0)
                {
                    string fileName = path + Path.GetFileName(file.FileName);
                    CloudBlockBlob blockBlob = storageContainer.GetBlockBlobReference(fileName);
                    await blockBlob.UploadFromStreamAsync(file.InputStream);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return new EmptyResult();
        }

        [HttpGet]
        public async Task<ActionResult> DownloadFile(string fileName)
        {
            MemoryStream ms = new MemoryStream();
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=recprojectstorage;AccountKey=wMy00xgnLUx0QVAE+ulUMOt0512O1VFheAflKAfuNqqXv2z6m1EtgVTx9Bcf/TED3WKJa3uTsqxmskoFRewnQQ==;EndpointSuffix=core.windows.net");
            CloudBlobClient BlobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = BlobClient.GetContainerReference("test");

            if (await container.ExistsAsync())
            {
                CloudBlob file = container.GetBlobReference(fileName);

                if (await file.ExistsAsync())
                {
                    await file.DownloadToStreamAsync(ms);
                    Stream blobStream = file.OpenReadAsync().Result;
                    return File(blobStream, file.Properties.ContentType, file.Name);
                }
                else
                {
                    return Content("File does not exist");
                }
            }
            else
            {
                return Content("Container does not exist");
            }
        }
    }
}