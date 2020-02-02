using Binus.WebAPI.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Model.AppModel
{
    public class UserModel : AuthUser
    {
        public int? UserID { get; set; }
        //public string Password { get; set; }
        public string Name { get; set; }
        //public string Email { get; set; }
        public string Role { get; set; }
    }
}
