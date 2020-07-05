using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FBISWebApi.DBAccess
{
    interface IOperation
    {
        DataSet DDL(string proc, params dynamic[] col);
        int DML(string proc, params dynamic[] col);
    }
}
