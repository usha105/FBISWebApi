
using FBISWebApi.DBAccess;
using FBISWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FBISWebApi.Logics
{
    public class Circle
    {
      readonly Operation DbOperation = new Operation();

        // Get All Region
        public DataSet GetRegion()
        {
            // get region database using stored procedure
            DataSet allRegion = DbOperation.GetRecordAll("Sp_GetRegion");
            return allRegion;
        }
        // get division by region
        public DataSet GetDivision(string circleName)
        {
            DataSet divisionByRegion = DbOperation.DDL("sp_Select_division", circleName);
            return divisionByRegion;
        }
    }
}