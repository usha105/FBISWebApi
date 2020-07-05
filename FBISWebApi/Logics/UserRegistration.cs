using FBISWebApi.DBAccess;
using FBISWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FBISWebApi.Logics
{
    public class UserRegistration
    {
       readonly Operation DbOperation = new Operation();
        public bool InsertDetails(UserEntity user)
        {
            bool status = Convert.ToBoolean(DbOperation.DML("Insert_newregistration", user.First_Name, user.Last_Name, user.User_Id, user.Password, user.Password_Act, user.DOB, user.Mobile_No, user.LandLine_No, user.Email_Id, user.Factrory_Name, user.City, user.Pincode, user.Password_Act));
            return status;
                          
        }
    }
}