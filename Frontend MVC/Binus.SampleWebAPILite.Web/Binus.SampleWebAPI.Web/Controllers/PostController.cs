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
            try
            {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Post/DeletePost",
                    REST.Method.POST,
                    Post).Result;
                System.Diagnostics.Debug.WriteLine(Result.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }
        public ActionResult UpdatePost(PostModel Post)
        {
            try
            {
                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Post/UpdatePost",
                    REST.Method.POST,
                    Post).Result;
                System.Diagnostics.Debug.WriteLine(Result.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
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
                System.Diagnostics.Debug.WriteLine(Result.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Index");
        }
    }
}