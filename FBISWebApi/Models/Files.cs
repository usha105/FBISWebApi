using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FBISWebApi.Models
{
    public class Files
    {
        public string encl { get; set; }
        public string name { get; set; }
        public string docType { get; set; }
        public string fac_Id { get; set; }
        public string enclExtn { get; set; }
    }
}