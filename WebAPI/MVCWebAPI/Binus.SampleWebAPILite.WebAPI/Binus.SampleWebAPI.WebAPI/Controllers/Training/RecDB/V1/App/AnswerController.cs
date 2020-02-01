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
    public class AnswerController : ApiController
    {
        private readonly IAnswerService _AnswerService;

        public AnswerController(IAnswerService _AnswerService)
        {
            this._AnswerService = _AnswerService;
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetAllAnswer()
        {
            List<AnswerModel> ListAnswer = (await _AnswerService.GetAllAnswer());

            return Json(ListAnswer);
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertAnswer(AnswerModel Model)
        {
            ExecuteResult Result = (await _AnswerService.InsertAnswer(Model));

            return Json(Result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> DeleteAnswer(AnswerModel Model)
        {
            ExecuteResult Result = (await _AnswerService.DeleteAnswer(Model));

            return Json(Result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> UpdateAnswer(AnswerModel Model)
        {
            ExecuteResult Result = (await _AnswerService.UpdateAnswer(Model));

            return Json(Result);
        }
    }
}