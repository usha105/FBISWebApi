using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FBISWebApi.Models
{
    public class UserEntity
    {
        public int User_Id { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string User_Type { get; set; }
        public string Password_Act { get; set; }
        public DateTime Time_Stamp { get; set; }
        public int Div_cd { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string DOB { get; set; }
        public string Address_Line1 { get; set; }
        public string City { get; set; }
        public long Pincode { get; set; }
        public string Factrory_Name { get; set; }
        public string Email_Id { get; set; }
        public Int64 Mobile_No { get; set; }
        public Int64 LandLine_No { get; set; }
        public DateTime Reg_Date { get; set; }
        public string UserStatus { get; set; }
    }
}