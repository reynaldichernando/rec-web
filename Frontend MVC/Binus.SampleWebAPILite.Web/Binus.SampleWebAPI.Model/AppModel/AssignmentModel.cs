using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Binus.SampleWebAPI.Model.AppModel
{
    public class AssignmentModel
    {
        public int AssignmentID { get; set; }
        public string Title { get; set; }
        public DateTime DateDue { get; set; }
        public DateTime DateUploaded { get; set; }
        public string Description { get; set; }
        public string AssignmentFilepath { get; set; }
    }
}
