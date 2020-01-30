using Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App;
using Microsoft.Web.Http;
using System.Web.Http;

namespace Binus.SampleWebAPI.WebAPI.Controllers.Training.RecDB.V1.App
{
    //[Authorize]
    [ApiVersion("1.0")]
    public class AssignmentController : ApiController
    {
        private readonly IAssignmentService _AssignmentService;

        public AssignmentController(IAssignmentService _AssignmentService)
        {
            this._AssignmentService = _AssignmentService;
        }


    }
}