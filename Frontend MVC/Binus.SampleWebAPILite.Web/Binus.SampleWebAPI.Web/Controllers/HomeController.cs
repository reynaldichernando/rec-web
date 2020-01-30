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

            try
            {
                HomeViewModel VM = new HomeViewModel();

                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/BookDB/V1/App/Book/GetAllBook",
                    REST.Method.GET).Result;

                if (Result.Success)
                {
                    VM.ListBook = Result.Deserialize<List<BookModel>>();
                }
                else
                {
                    VM.ListBook = new List<BookModel>();
                }
                return View(VM);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public ActionResult NewBook()
        {
            return View();
        }

        public ActionResult Insert(BookModel book)
        {
            RESTResult Result = new REST(
                        Global.WebAPIBaseURL,
                        "/api/Training/BookDB/V1/App/Book/InsertBookWithModel",
                        REST.Method.POST,
                        ConfigurationManager.AppSettings["OAuthBookDB"],
                        book
                    ).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Update(int BookID)
        {
            RESTResult Result = new REST(
                        Global.WebAPIBaseURL,
                        $"/api/Training/BookDB/V1/App/Book/GetOneBook?BookID={BookID}",
                        REST.Method.GET,
                        ConfigurationManager.AppSettings["OAuthBookDB"]
                    ).Result;
            BookModel book = Result.Deserialize<BookModel>();
            return View("Update", book);
        }

        public ActionResult UpdateBook(BookModel book)
        {
            RESTResult ResultDel = new REST(
                        Global.WebAPIBaseURL,
                        "/api/Training/BookDB/V1/App/Book/UpdateBook",
                        REST.Method.POST,
                        ConfigurationManager.AppSettings["OAuthBookDB"],
                        book
                    ).Result;
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int BookID)
        {
            RESTResult Result = new REST(
                        Global.WebAPIBaseURL,
                        $"/api/Training/BookDB/V1/App/Book/GetOneBook?BookID={BookID}",
                        REST.Method.GET,
                        ConfigurationManager.AppSettings["OAuthBookDB"]
                    ).Result;
            BookModel book = Result.Deserialize<BookModel>();
            return View("Detail",book);
        }

        public ActionResult Delete(int BookID)
        {
            RESTResult Result = new REST(
                        Global.WebAPIBaseURL,
                        $"/api/Training/BookDB/V1/App/Book/GetOneBook?BookID={BookID}",
                        REST.Method.GET,
                        ConfigurationManager.AppSettings["OAuthBookDB"]
                    ).Result;
            BookModel book = Result.Deserialize<BookModel>();

            RESTResult ResultDel = new REST(
                        Global.WebAPIBaseURL,
                        "/api/Training/BookDB/V1/App/Book/DeleteBook",
                        REST.Method.POST,
                        ConfigurationManager.AppSettings["OAuthBookDB"],
                        book
                    ).Result;
            return RedirectToAction("Index");
        }

        

    }
}