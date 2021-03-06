﻿using Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.User
{
    public class UserModel
    {
        public int? UserID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public string Salt = "!@#!@#";
       
        public string Token { get; set; }
    }
}
