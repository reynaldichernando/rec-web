
using Binus.SampleWebAPI.Model.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus.SampleWebAPI.Web.ViewModels
{
    public class UserViewModel
    {
        public List<UserModel> ListUser { get; set; }
        public UserModel User;
    }
}