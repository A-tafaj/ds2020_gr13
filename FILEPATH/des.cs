using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FILEPATH
{
    class des
    {
        public static string Encrypt(string plaintext, string key, string iv)
        {
            //string kk = Base64Decode(key);
            //string vv = Base64Decode(iv);
            byte[] bptext = Encoding.UTF8.GetBytes(plaintext);

            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();



            objDES.Padding = PaddingMode.Zeros;
            objDES.Mode = CipherMode.ECB;


            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, objDES.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(bptext, 0, bptext.Length);
            cs.Close();
            byte[] bciphertext = ms.ToArray();

            return Convert.ToBase64String(bciphertext);
        }

        public static string Decrypt(string ciphertext, string key, string iv)
        {
            byte[] bcptext = Convert.FromBase64String(ciphertext);

            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();

            objDES.Padding = PaddingMode.Zeros;
            objDES.Mode = CipherMode.ECB;

            MemoryStream ms = new MemoryStream();
            byte[] bdecrypted = new byte[ms.Length];
            CryptoStream cs = new CryptoStream(ms, objDES.CreateDecryptor(), CryptoStreamMode.Read);
            cs.Read(bdecrypted, 0, bdecrypted.Length);
            cs.Close();

            return Encoding.UTF8.GetString(bdecrypted);
        }
    }
}
