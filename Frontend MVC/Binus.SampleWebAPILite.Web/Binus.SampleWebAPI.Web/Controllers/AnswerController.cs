using Binus.SampleWebAPI.Model.AppModel;
using Binus.SampleWebAPI.Web.Class;
using Binus.SampleWebAPI.Web.ViewModels;
using Binus.WebAPI.REST;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Binus.SampleWebAPI.Web.Controllers
{
    public class AnswerController : Controller
    {
        // GET: Answer
        [HttpGet]
        public ActionResult Index(int id)
        {
            if (Session["token"] == null) return RedirectToAction("Index", "Login");

            try
            {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "/api/Training/RecDB/V1/App/Answer/GetAllAnswer?AssignmentID="+id,
                    REST.Method.GET).Result;

                AnswerViewModel avm = new AnswerViewModel();
                avm.answers = Result.Deserialize<List<AnswerModel>>();

                return View("Index", avm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<ActionResult> DownloadAnswer(string AssignmentID, string UserID)
        {
            JsonResult retData = new JsonResult();
            try
            {
                RESTResult Result;
                Result = (new REST(Global.WebAPIBaseURL, "/api/Training/RecDB/V1/App/Answer/GetAnswer?AssignmentID=" + AssignmentID + "&UserID=" + UserID, REST.Method.GET)).Result;

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