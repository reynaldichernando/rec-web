using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Model.AppModel
{
    public class PostModel
    {
        public int PostID { get; set; }
        public int ThreadID { get; set; }
        public int UserID { get; set; }
        public string Content { get; set; }
    }
}
