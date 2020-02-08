using Binus.SampleWebAPI.Model.AppModel;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Binus.SampleWebAPI.Web.ViewModels
{
    public class AssignmentViewModel
    {
        public List<AssignmentModel> assignments { get; set; }
        public List<AssignmentModel> GetCurrentAssignment()
        {
            List<AssignmentModel> temp = new List<AssignmentModel>();
            foreach (AssignmentModel item in assignments)
            {
                if(item.DateDue.CompareTo(DateTime.Now) > 0)
                {
                    temp.Add(item);
                }
            }
            return temp;
        }

        public List<AssignmentModel> GetPastAssignment()
        {
            List<AssignmentModel> temp = new List<AssignmentModel>();
            foreach (AssignmentModel item in assignments)
            {
                if (item.DateDue.CompareTo(DateTime.Now) <= 0)
                {
                    temp.Add(item);
                }
            }
            return temp;
        }
    }
}