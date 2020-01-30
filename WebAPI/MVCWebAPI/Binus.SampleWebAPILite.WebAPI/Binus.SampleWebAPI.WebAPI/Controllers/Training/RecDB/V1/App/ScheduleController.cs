using Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App;
using Microsoft.Web.Http;
using System.Web.Http;

namespace Binus.SampleWebAPI.WebAPI.Controllers.Training.RecDB.V1.App
{
    //[Authorize]
    [ApiVersion("1.0")]
    public class ScheduleController : ApiController
    {
        private readonly IScheduleService _ScheduleService;

        public ScheduleController(IScheduleService _ScheduleService)
        {
            this._ScheduleService = _ScheduleService;
        }


    }
}