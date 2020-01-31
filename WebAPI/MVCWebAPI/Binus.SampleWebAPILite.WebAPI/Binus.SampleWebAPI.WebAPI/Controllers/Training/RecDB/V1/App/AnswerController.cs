using Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App;
using Microsoft.Web.Http;
using System.Web.Http;

namespace Binus.SampleWebAPI.WebAPI.Controllers.Training.RecDB.V1.App
{
    //[Authorize]
    [ApiVersion("1.0")]
    public class AnswerController : ApiController
    {
        private readonly IAnswerService _AnswerService;

        public AnswerController(IAnswerService _AnswerService)
        {
            this._AnswerService = _AnswerService;
        }

        //halo saya belajar github vs extension
        //code penting dll waw

    }
}