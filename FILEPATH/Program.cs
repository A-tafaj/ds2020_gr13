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
                        if (args.Length == 3)
                        {


                            string publicKey = File.ReadAllText("keys/" + input + ".pub.xml");
                            string tekst = args[2];

                            // Console.WriteLine(RSA.Encrypt(tekst, publicKey)+"\n\n");
                            //  Console.WriteLine(publicKey);
                            Console.WriteLine("\n" + WR.Base64Encode(input) + "." + WR.Base64Encode(randiv) + "." + WR.rsa_Encrypt(randKey, publicKey) + "." + WR.des_Encrypt(tekst, randKey, randiv));
                        }
                        else if (args.Length>3)
                        {
                            string publicKey = File.ReadAllText("keys/" + input + ".pub.xml");
                            string tekst = args[2];
                            string file = args[3];
                            using (StreamWriter sw = File.CreateText("files/" + file));

                            string g = ("\n" + WR.Base64Encode(input) + "." + WR.Base64Encode(randiv) + "." + WR.rsa_Encrypt(randKey, publicKey) + "." + WR.des_Encrypt(tekst, randKey, randiv));
                            File.WriteAllText("files/" + file, g);

                            Console.WriteLine("Mesazhi i enkriptuar u ruajt ne fajllin" + "files/"+file);
                        }
                    }

                    else
                    {
                        Console.WriteLine("Celesi publik " + input + " nuk ekziston.");
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

                    string input = WR.Base64Decode(firstElem);
                    string privkey = "keys/" + input + ".xml";

                    if (File.Exists(privkey))
                    {
                        Console.WriteLine("Marresi: " + input);
                        string privateKey = File.ReadAllText("keys/" + input + ".xml");

                        

                        string iv_get = WR.Base64Decode(second);

                        string rsaKey_get = WR.rsa_Decrypt(third, privateKey);
                        Console.WriteLine("Dekriptimi: " + WR.des_Decrypt(fourth, rsaKey_get, iv_get));
                    }
                    else
                    {
                        Console.WriteLine("Celesi privat " + input + " nuk ekziston.");
                    }

                }
                else
                {
                    Console.WriteLine("Dy komandat e cashme jane: <write-message> dhe <read-message>");
                }



                

            }


        }
    }

}