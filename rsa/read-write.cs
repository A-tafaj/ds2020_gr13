using System;
using System.Dynamic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace read_msg
{
    class Program
    {
        static void Main(string[] args)
        {
            string Blerim = "blerim";
            
            DESCryptoServiceProvider objDes = new DESCryptoServiceProvider();
            objDes.GenerateKey();
            objDes.GenerateIV();
            
            var randKey = Convert.ToBase64String(objDes.Key);
            var randIV = Convert.ToBase64String(objDes.IV);
            
            Console.WriteLine(Base64Encode(Blerim) + "."+randKey + "." +randIV);

        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}