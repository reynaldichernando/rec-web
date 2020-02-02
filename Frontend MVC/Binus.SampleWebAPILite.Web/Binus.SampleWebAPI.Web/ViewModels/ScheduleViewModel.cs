
using Binus.SampleWebAPI.Model.AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus.SampleWebAPI.Web.ViewModels
{
    public class ScheduleViewModel
    {
        public List<ScheduleModel> ListSchedule { get; set; }
        public ScheduleModel Schedule;
    }
}