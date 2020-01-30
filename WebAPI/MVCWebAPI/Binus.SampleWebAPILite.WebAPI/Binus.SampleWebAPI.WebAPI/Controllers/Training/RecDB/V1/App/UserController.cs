using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.User;
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
    public class UserController : ApiController
    {
        private readonly IUserService _UserService;

        public UserController(IUserService _UserService)
        {
            this._UserService = _UserService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> GetUserLogin(UserModel User)
        {
            return Json(await _UserService.GetUserLogin(User));
        }

        [HttpPost]
        public async Task<IHttpActionResult> RegisterUser(UserModel User)
        {
            return Json(await _UserService.RegisterUser(User));
        }

        //method xddd baru saya disiniii coyyy eh gajadi deh pengen buat conflict gw lmao
    }
}