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
    public class AssignmentController : ApiController
    {
        private readonly IAssignmentService _AssignmentService;

        public AssignmentController(IAssignmentService _AssignmentService)
        {
            this._AssignmentService = _AssignmentService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllAssignment()
        {
            List<AssignmentModel> ListAssignment = (await _AssignmentService.GetAllAssignment());

            return Json(ListAssignment);
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertAssignment(AssignmentModel Model)
        {
            ExecuteResult Result = (await _AssignmentService.InsertAssignment(Model));

            return Json(Result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> DeleteAssignment(AssignmentModel Model)
        {
            ExecuteResult Result = (await _AssignmentService.DeleteAssignment(Model));

            return Json(Result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> UpdateAssignment(AssignmentModel Model)
        {
            ExecuteResult Result = (await _AssignmentService.UpdateAssignment(Model));

            return Json(Result);
        }
    }
}