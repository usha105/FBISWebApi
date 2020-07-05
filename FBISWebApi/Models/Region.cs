using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FBISWebApi.Models
{
    public class Region
    {
        public int CircleCode { get; set; }
        public string CircleName { get; set; }
        public string Status { get; set; }
        public string TimeStamp { get; set; }
        public string  CircleCD { get; set; }
        public string DistrictName { get; set; }
    }
}