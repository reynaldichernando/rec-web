using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Model.AppModel
{
    public class BookModel
    {
        public int BookID { set; get; }
        public string BookName { set; get; }
        public string BookDesc { set; get; }
        public int BookQty { set; get; }
    }
}
