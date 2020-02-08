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
    public class PostController : Controller
    {
        public ActionResult Index()
        {
            PostViewModel VM = new PostViewModel();
            try
            {
                int ThreadID = Convert.ToInt32(Session["ThreadID"]);
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Post/GetPost?ThreadID="+ ThreadID,
                    REST.Method.GET).Result;
                RESTResult Result2 = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Thread/GetOneThread?ThreadID=" + ThreadID,
                    REST.Method.GET).Result;
                if (Result.Success && Result2.Success)
                {
                    VM.ListPost = Result.Deserialize<List<PostModel>>();
                    VM.Thread = Result2.Deserialize<ThreadModel>();
                    VM.UserID = Convert.ToInt32(Session["UserID"]);
                    return View(VM);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }

        public ActionResult DeletePost(PostModel Post)
        {
            JsonResult Retdata;
            try
            {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Post/DeletePost",
                    REST.Method.POST,
                    Post).Result;

                if (Result.Success)
                {
                    Retdata = Json(new
                    {
                        URL = Global.BaseURL + "/Post",
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
        public ActionResult UpdatePost(PostModel Post)
        {
            JsonResult Retdata;
            try
            {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Post/UpdatePost",
                    REST.Method.POST,
                    Post).Result;
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

        public ActionResult GetPostByID(int PostID)
        {
            JsonResult retData = new JsonResult();
            try
            {
                RESTResult Result = (new REST(Global.WebAPIBaseURL, "/api/Training/RecDB/V1/App/Post/GetPostByID?PostID=" + PostID, REST.Method.GET)).Result;
                PostModel Post = Result.Deserialize<PostModel>();
                if (Result.Success)
                {
                    retData = Json(new
                    {
                        Status = "Success",
                        Message = "Get Post Success!",
                        Data = new
                        {
                            PostID = Post.PostID,
                            ThreadID = Post.ThreadID,
                            UserID = Post.UserID,
                            Content = Post.Content
                        }
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

        public ActionResult CreatePost(PostModel Post)
        {
            try
            {
                Post.ThreadID = Convert.ToInt32(Session["ThreadID"]);
                Post.UserID = Convert.ToInt32(Session["UserID"]);
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Post/InsertPost",
                    REST.Method.POST,
                    Post).Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }
    }
}