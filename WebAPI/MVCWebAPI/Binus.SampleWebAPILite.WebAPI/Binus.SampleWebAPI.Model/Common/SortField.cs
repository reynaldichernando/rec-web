using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binus.SampleWebAPI.Model.Common
{
    public class SortField
    {
        public enum Direction { Ascending=0, Descending=2}
        public string FieldName { get; set; }
        public Direction Sort { get; set; }
    }
}
