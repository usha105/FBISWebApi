using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FBISWebApi.Logics
{
    public class Hashcode
    {

        public string Encrypt(string edata)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(edata);
            data = x.ComputeHash(data);
            String md5Hash = Convert.ToBase64String(data);
            return md5Hash;
        }
}
}