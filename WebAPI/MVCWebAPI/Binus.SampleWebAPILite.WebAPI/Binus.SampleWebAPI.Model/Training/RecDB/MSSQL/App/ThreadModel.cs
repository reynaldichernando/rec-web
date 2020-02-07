using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Model.Training.RecDB.MSSQL.App
{
    public class ThreadModel
    {
        public int? ThreadID { get; set; }
        public int? UserID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
