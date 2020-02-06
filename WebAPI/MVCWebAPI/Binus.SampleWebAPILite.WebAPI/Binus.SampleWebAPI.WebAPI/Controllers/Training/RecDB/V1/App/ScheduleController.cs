using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.App;
using Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App;
using Binus.WebAPI.Model.MSSQL;
using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Binus.SampleWebAPI.WebAPI.Controllers.Training.RecDB.V1.App
{
    [ApiVersion("1.0")]
    [Authorize]
    public class ScheduleController : ApiController
    {
        private readonly IScheduleService _ScheduleService;

        public ScheduleController(IScheduleService _ScheduleService)
        {
            this._ScheduleService = _ScheduleService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetScheduleByID(string ScheduleID){
            return Json(await _ScheduleService.GetScheduleByID(ScheduleID));
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllSchedule()
        {
            List<ScheduleModel> ListSchedule = (await _ScheduleService.GetAllSchedule());

            return Json(ListSchedule);
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertSchedule(ScheduleModel Model)
        {
            ExecuteResult Result = (await _ScheduleService.InsertSchedule(Model));

            return Json(Result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> DeleteScheduleByID(string ScheduleID)
        {
            ExecuteResult Result = (await _ScheduleService.DeleteScheduleByID(ScheduleID));

            return Json(Result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> UpdateSchedule(ScheduleModel Model)
        {
            ExecuteResult Result = (await _ScheduleService.UpdateSchedule(Model));

            return Json(Result);
        }
    }
}