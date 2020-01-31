using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus.SampleWebAPI.Web.Controllers
{
    public class ThreadController:Controllers
    {
        public ActionResult Index()
        {
            try
            {
                HomeViewModel VM = new HomeViewModel();

                RESTResult Result = new REST(
                    Global.WebAPIBaseURL,
                    "api/Training/RecDB/V1/App/Thread/GetAllThread",
                    REST.Method.GET).Result;

                if (Result.Success)
                {
                    VM.ListThread = Result.Deserialize<List<ThreadModel>>();
                }
                else
                {
                    VM.ThreadBook = new List<ThreadModel>();
                }
                return View(VM);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}