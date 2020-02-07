using Binus.SampleWebAPI.Model.AppModel;
using Binus.SampleWebAPI.Web.Class;
using Binus.SampleWebAPI.Web.ViewModels;
using Binus.WebAPI.REST;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Binus.SampleWebAPI.Web.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {

            return View();

            //try
            //{
            //    HomeViewModel VM = new HomeViewModel();

            //    RESTResult Result = new REST(
            //        Global.WebAPIBaseURL,
            //        "api/Training/BookDB/V1/App/Book/GetAllBook",
            //        REST.Method.GET).Result;

            //    if (Result.Success)
            //    {
            //        VM.ListBook = Result.Deserialize<List<BookModel>>();
            //    }
            //    else
            //    {
            //        VM.ListBook = new List<BookModel>();
            //    }
            //    return View(VM);

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        } 
        public ActionResult AboutUs()
        {
            return View();
        }
    }
}