using FBISWebApi.Logics;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FBISWebApi.DBAccess
{
    public class Operation : IOperation
    {
        private string appRunningId;

        private SqlConnection con;// = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public void DDL(SqlConnection con1,SqlCommand cmd)
        {
            appRunningId = Guid.NewGuid().ToString();
            try
            {
                con= new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
                con1.Open();
                cmd.ExecuteNonQuery();
                con1.Close();
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.LogFile("Exception:" + e.Message.ToString(), appRunningId);
             }
        }
        public DataSet GetRecord(SqlCommand cmd)
        {
            appRunningId = Guid.NewGuid().ToString();
            try
            {
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDA.Fill(dataSet);
                return dataSet;
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.LogFile("Exception:" + e.Message.ToString(), appRunningId);
                return null;
            }
        }
        public DataSet GetRecordAll(string proc)
        {
            con= new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(proc, con);
            SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDA.Fill(dataSet);
            return dataSet;
        }
        public SqlCommand GetSpParam(string proc)
        {
            con= new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Sp_GetProcParam", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProcName", proc);
            return cmd;
        }
        
        public void InsertData(string proc, dynamic[] col)
        {
            con= new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand cmd = GetSpParam(proc);
            DataSet ds = GetRecord(cmd);
            int i = 0;
            SqlCommand cmdInsert = new SqlCommand(proc, con);
            cmdInsert.CommandType = CommandType.StoredProcedure;
            try
            {
                foreach (DataRow dataRow in ds.Tables[0].Rows)
                {
                    cmdInsert.Parameters.AddWithValue(dataRow[0].ToString(), col[i]);
                    i++;
                }
            }
            catch (Exception e)
            {
                Log log = new Log();
                log.LogFile("Exception:" + e.Message.ToString(), appRunningId);

            }
            DDL(con, cmdInsert);
        }
        //get the record according to given paremeter
        public DataSet DDL(string proc, params dynamic[] col)
        {
            con= new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            SqlCommand sqlCommand = GetSpParam(proc);
            DataSet dataSet = GetRecord(sqlCommand);
            int i = 0;
            SqlCommand cmdGet = new SqlCommand(proc, con);
            cmdGet.CommandType = CommandType.StoredProcedure;
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                cmdGet.Parameters.AddWithValue(dataRow[0].ToString(), col[i]);
                i++;
            }
            dataSet = GetRecord(cmdGet);
            return dataSet;
        }

        //insert records and update flag 1,0 accoring to database update
        public int DML(string proc, params dynamic[] col)
        {
            if (con != null)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            }
            else
            {
                return 0;
            }
                SqlCommand cmd = GetSpParam(proc);
                DataSet ds = GetRecord(cmd);
                SqlCommand cmd1 = new SqlCommand(proc, con);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter();

                int i = 0;
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    if (item[1].ToString() == "INOUT")
                    {
                        sqlParameter.ParameterName = item[0].ToString();
                        sqlParameter.SqlDbType = SqlDbType.Int;
                        sqlParameter.Direction = ParameterDirection.Output;
                        cmd1.Parameters.Add(sqlParameter);
                    }
                    else
                    {
                        cmd1.Parameters.AddWithValue(item[0].ToString(), col[i]);
                    }
                    i++;
                }

                con.Open();
                int flag = cmd1.ExecuteNonQuery();
                con.Close();
            
            return flag;
        }
    }
}