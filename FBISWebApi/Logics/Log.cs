using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FBISWebApi.Logics
{
    public class Log
    {
        public void LogFile(string tasknames, string appRunningId)
        {
            string logpath = AppDomain.CurrentDomain.BaseDirectory + "\\LogFile"+"\\Error";
            string fileName1 = logpath + "\\FBIS_LOG" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            FileInfo fii = new FileInfo(fileName1);
            try
            {
                if (fii.Exists)
                {
                    using (StreamWriter sw = fii.AppendText())
                    {
                        sw.WriteLine("{0}---" + tasknames + "", DateTime.Now.ToString() + " -- " + appRunningId);
                        sw.WriteLine("__________________________________________________________________________________________");

                    }
                }
                else
                    using (StreamWriter sw = fii.CreateText())
                    {
                        sw.WriteLine("{0}---" + tasknames + "", DateTime.Now.ToString() + " -- " + appRunningId);
                        sw.WriteLine("______________________________________");
                    }
            }

            catch (Exception Ex)
            {
                LogFile(Ex.Message + Ex.StackTrace, appRunningId);
            }
        }
    }
}