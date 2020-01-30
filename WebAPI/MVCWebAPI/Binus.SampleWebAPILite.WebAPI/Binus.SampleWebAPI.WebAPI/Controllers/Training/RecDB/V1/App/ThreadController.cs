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
    //[Authorize]
    [ApiVersion("1.0")]
    public class ThreadController : ApiController
    {
        private readonly IThreadService _ThreadService;

        public ThreadController(IThreadService _ThreadService)
        {
            this._ThreadService = _ThreadService;
        }

   
    }
}