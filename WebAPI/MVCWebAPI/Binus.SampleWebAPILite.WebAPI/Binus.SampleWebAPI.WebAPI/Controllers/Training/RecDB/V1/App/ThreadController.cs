using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.App;
using Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Binus.SampleWebAPI.WebAPI.Controllers.Training.RecDB.V1.App
{
    [Authorize]
    [ApiVersion("1.0")]
    public class ThreadController : ApiController
    {
        private readonly IThreadService _ThreadService;

        public ThreadController(IThreadService _ThreadService)
        {
            this._ThreadService = _ThreadService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllThread()
        {
            List<ThreadModel> ListThread = (await _ThreadService.GetAllThread());
            return Json(ListThread);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetOneThread(int ThreadID)
        {
            ThreadModel Thread = (await _ThreadService.GetOneThread(ThreadID));
            return Json(Thread);
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertThread(ThreadModel Thread)
        {
            return Json(await _ThreadService.InsertThread(Thread));

        }

        [HttpPost]
        public async Task<IHttpActionResult> UpdateThread(ThreadModel Thread)
        {
            return Json(await _ThreadService.UpdateThread(Thread));

        }

        [HttpPost]
        public async Task<IHttpActionResult> DeleteThread(ThreadModel Thread)
        {
            return Json(await _ThreadService.DeleteThread(Thread));

        }
    }
}