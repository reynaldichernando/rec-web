using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.App;
using Binus.SampleWebAPI.Services.Training.RecDB.MSSQL.App;
using Microsoft.Web.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Binus.SampleWebAPI.WebAPI.Controllers.Training.RecDB.V1.App
{
    [Authorize]
    [ApiVersion("1.0")]
    public class PostController : ApiController
    {
        private readonly IPostService _PostService;

        public PostController(IPostService _PostService)
        {
            this._PostService = _PostService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> InsertPost(PostModel Post)
        {
            return Json(await _PostService.InsertPost(Post));

        }

        [HttpPost]
        public async Task<IHttpActionResult> UpdatePost(PostModel Post)
        {
            return Json(await _PostService.UpdatePost(Post));

        }

        [HttpPost]
        public async Task<IHttpActionResult> DeletePost(PostModel Post)
        {
            return Json(await _PostService.DeletePost(Post));

        }

        [HttpGet]
        public async Task<IHttpActionResult> GetPost(int ThreadID)
        {
            List<PostModel> ListPost = (await _PostService.GetPost(ThreadID));
            return Json(ListPost);
        }

    }
}