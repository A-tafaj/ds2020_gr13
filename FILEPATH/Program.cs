using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace RS
{
    class Test
    {
        public static void Main(String[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "write-message")
                {
                    string input = args[1];
                    string pubkey = "keys/" + input + ".pub.xml";
                    DESCryptoServiceProvider objDes = new DESCryptoServiceProvider();
                    objDes.GenerateKey();
                    objDes.GenerateIV();
                    var randKey = Convert.ToBase64String(objDes.Key);
                    var randIV = Convert.ToBase64String(objDes.IV);

                    if (File.Exists(pubkey))
                    {
                        string publicKey = File.ReadAllText("keys/" + input + ".pub.xml");
                        string tekst = args[2];
                       // Console.WriteLine(RSA.Encrypt(tekst, publicKey)+"\n\n");
                      //  Console.WriteLine(publicKey);
                        Console.WriteLine("\n"+Base64Encode(input) + "." + randIV+"."+ RSA.Encrypt(tekst, publicKey));

                    }
                }

            }
            static string Base64Encode(string plainText)
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                return Convert.ToBase64String(plainTextBytes);
            }





        }
    }

}