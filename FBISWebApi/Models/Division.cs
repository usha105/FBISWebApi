using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FBISWebApi.Models
{
    public class Division
    {
        public int CircleCode { get; set; }
        public string DivName { get; set; }
        public string DivCode { get; set; }
        public string Status { get; set; }
        public string TimeStamp { get; set; }
        public string DivisionCD { get; set; }
    }
}