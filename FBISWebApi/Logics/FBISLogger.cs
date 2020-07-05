using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Xml.XPath;
using System.Xml.Linq;

namespace FBISWebApi.Logics
{
    public static class FbisLogger
    {
        static string ServerPath = AppDomain.CurrentDomain.BaseDirectory + "\\LogFile" + "\\Tracking";
        static string FileName = "\\FBISLog.txt";
        static string path = ServerPath + FileName;
        static string LoggerPath = ConfigurationManager.AppSettings["LoggerLocation"];
        public static void Log(string LogEntry,string ipAddress, string LogInformation, string LogFilePath)
        {
            string KeyName = "EnableLogging";
            Boolean flag = AddKeyList(KeyName);
            if (flag)
            {
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine(LogEntry + " - Path: " + LogFilePath + " IP Address:" + ipAddress +" Function: " + LogInformation + " Log Date: " + DateTime.Now.ToString());
                sw.Write("text");
                sw.Flush();
                sw.Close();
            }
        }


        public static bool AddKeyList(string KeyName)
        {
            XElement xele = XElement.Load(System.IO.Path.GetFullPath(HttpContext.Current.Server.MapPath(LoggerPath))).XPathSelectElement("//add[@key='" + KeyName + "']");
            if (xele != null && xele.Attribute("value").Value == "true")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}