using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Rss4Mobi.Common
{
    public class Md5
    {
        public static string GetMd5Pass(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            string pass = input;
            var p = Encoding.UTF8.GetBytes(pass);
            byte[] bytes = md5.ComputeHash(p);
            var sb = new StringBuilder(32);
            foreach (byte letter in bytes)
            {
                int value = Convert.ToInt32(letter);
                string hexOutput = String.Format("{0:x}", value);
                if (hexOutput.Length == 1)
                    hexOutput = "0" + hexOutput;
                sb.Append(hexOutput);

            }
            return sb.ToString();
        }
    }
}