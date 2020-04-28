using FILEPATH;
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
                    // objDes.GenerateKey();
                    //objDes.GenerateIV();
                    //string randKey = Convert.ToBase64String(objDes.Key);
                    //string randIV = Convert.ToBase64String(objDes.IV);
                    string randKey = "11112222";
                    string randiv = "22221111";
                    if (File.Exists(pubkey))
                    {
                        string publicKey = File.ReadAllText("keys/" + input + ".pub.xml");
                        string tekst = args[2];

                        // Console.WriteLine(RSA.Encrypt(tekst, publicKey)+"\n\n");
                        //  Console.WriteLine(publicKey);
                        Console.WriteLine("\n" + Base64Encode(input) + "." + Base64Encode(randiv) + "." + RSA.Encrypt(randKey, publicKey) + "." + des.Encrypt(tekst, randKey, randiv));

                    }
                }
                else if (args[0] == "read-message")
                {
                    string cipher = args[1];
                    var array = cipher.Split(new[] { '.' }, 4);

                    string firstElem = array[0];
                    string second = array[1];
                    string third = array[2];
                    string fourth = array[3];

                    string input = Base64Decode(firstElem);
                    string privkey = "keys/" + input + ".xml";

                    if (File.Exists(privkey))
                    {
                        Console.WriteLine("Marresi: " + input);
                        string privateKey = File.ReadAllText("keys/" + input + ".xml");

                        var encodedTextBytes = Convert.FromBase64String(second);

                        string iv_get = Encoding.UTF8.GetString(encodedTextBytes);

                        string rsaKey_get = RSA.Decrypt(third, privateKey);
                        Console.WriteLine("Dekriptimi: " + des.Decrypt(fourth, rsaKey_get, iv_get));
                    }

                }



                static string Base64Encode(string plainText)
                {
                    var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                    return Convert.ToBase64String(plainTextBytes);
                }
                static string Base64Decode(string base64EncodedData)
                {
                    var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                }

            }


        }
    }

}