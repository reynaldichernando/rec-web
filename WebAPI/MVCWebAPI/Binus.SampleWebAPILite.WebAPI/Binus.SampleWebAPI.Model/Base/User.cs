using System;
using System.ComponentModel.DataAnnotations;

namespace Binus.SampleWebAPI.Model.Serpong.Common
{
    [Serializable]
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public char Stsrc { get; set; }
        public string UserIn { get; set; }
        public string UserUp { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime? DateUp { get; set; }
    }
}
