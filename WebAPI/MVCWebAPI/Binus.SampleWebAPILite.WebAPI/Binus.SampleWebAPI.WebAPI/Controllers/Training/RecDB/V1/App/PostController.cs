using Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App;
using Microsoft.Web.Http;
using System.Web.Http;

namespace Binus.SampleWebAPI.WebAPI.Controllers.Training.RecDB.V1.App
{
    //[Authorize]
    [ApiVersion("1.0")]
    public class PostController : ApiController
    {
        private readonly IPostService _PostService;

        public PostController(IPostService _PostService)
        {
            this._PostService = _PostService;
        }


    }
}