using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Http;
using FBISWebApi.Models;
using System.Configuration;

namespace FBISWebApi.Logics
{
    public class FolderCreate
    {
        static string ServerPath = ConfigurationManager.AppSettings["LogFileLocation"];

        public bool CreateDirectory(string id, List<Files> f)
        {
            bool isSavedSuccessfully = false;
            if(f.Count > 0)
            {
                string path = ServerPath;
                string pathString = Path.Combine(path, id);
                Directory.CreateDirectory(pathString);
                foreach(var files in f)
                {
                    Byte[] bytes = Convert.FromBase64String(files.encl);
                    File.WriteAllBytes(pathString+Path.PathSeparator+files.name, bytes);
                    isSavedSuccessfully = true;
                }
            }
            return isSavedSuccessfully;
        }
        public List<Files> FetchFiles(string facId)
        {
            List<Files> list = new List<Files>();
            string path = ServerPath;
            string pathString = Path.Combine(path, facId);
            DirectoryInfo d = new DirectoryInfo(@pathString);
            FileInfo[] Files = d.GetFiles("*.pdf");
            foreach (FileInfo file in Files)
            {
                Byte[] bytes = File.ReadAllBytes(file.FullName);
                String file1 = Convert.ToBase64String(bytes);
                var cr = new Files
                {
                    encl = file1,
                    docType= "application/pdf",
                    enclExtn= file.Extension,
                    fac_Id=facId,
                    name=file.Name
                };
                list.Add(cr);
            }
            return list;
        }
    }
}