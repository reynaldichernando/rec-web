﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Model.AppModel
{
    public class AnswerModel
    {
        public int? AssignmentID { get; set; }
        public int? UserID { get; set; }
        public string Name { get; set; }
        public int? AnswerID { get; set; }
        public DateTime? DateUploaded { get; set; }
        public string AnswerFilepath { get; set; }
    }
}
