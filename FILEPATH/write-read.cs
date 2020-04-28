using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FILEPATH
{
    class WR
    {
        public static string des_Encrypt(string plaintext, string key, string iv)
        {
            //string kk = Base64Decode(key);
            //string vv = Base64Decode(iv);
            byte[] bptext = Encoding.UTF8.GetBytes(plaintext);
          //  byte[] pllugi = Convert.FromBase64String(key);
            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();


            objDES.Key = Convert.FromBase64String(key);
            objDES.IV = Convert.FromBase64String(iv);
            objDES.Padding = PaddingMode.Zeros;
            objDES.Mode = CipherMode.ECB;


            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, objDES.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(bptext, 0, bptext.Length);
            cs.Close();
            byte[] bciphertext = ms.ToArray();

            return Convert.ToBase64String(bciphertext);
        }

        public static string des_Decrypt(string ciphertext, string key, string iv)
        {
            byte[] bcptext = Convert.FromBase64String(ciphertext);

            DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
            objDES.Key = Convert.FromBase64String(key);
            objDES.IV = Convert.FromBase64String(iv);
            objDES.Padding = PaddingMode.Zeros;
            objDES.Mode = CipherMode.ECB;

            MemoryStream ms = new MemoryStream(bcptext);
            byte[] bdecrypted = new byte[ms.Length];
            CryptoStream cs = new CryptoStream(ms, objDES.CreateDecryptor(), CryptoStreamMode.Read);
            cs.Read(bdecrypted, 0, bdecrypted.Length);
            cs.Close();

            return Encoding.UTF8.GetString(bdecrypted);
        }

        public static string rsa_Encrypt(string textToEncrypt, string publicKeyString)
        {
            var bytesToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);

            using (var rsa = new RSACryptoServiceProvider())
            {
                try
                {
                    rsa.FromXmlString(publicKeyString.ToString());
                    var encryptedData = rsa.Encrypt(bytesToEncrypt, true);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        public static string rsa_Decrypt(string textToDecrypt, string privateKeyString)
        {
            var bytesToDecrypt = Encoding.UTF8.GetBytes(textToDecrypt);

            using (var rsa = new RSACryptoServiceProvider())
            {
                try
                {

                    rsa.FromXmlString(privateKeyString);

                    var resultBytes = Convert.FromBase64String(textToDecrypt);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string plaintext)
        {
            var plaintextBytes = Convert.FromBase64String(plaintext);
            return Encoding.UTF8.GetString(plaintextBytes);
        }
    }
}
