using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Threading;

namespace SIGURIA
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                string command = args[0];

                RsaEncryptor rsa;
                DirectoryInfo di = Directory.CreateDirectory(@"C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\keys\");

                if (command == "create-user")
                {
                    try
                    {
                        if (args[1].Length != 0)
                        {
                            string command2 = args[1];
                            StringBuilder sb = new StringBuilder();
                            for (int i = 0; i < command2.Length; i++)
                            {
                                if ((command2[i] >= '0' && command2[i] <= '9') || (command2[i] >= 'A' && command2[i] <= 'Z') || (command2[i] >= 'a' && command2[i] <= 'z') || command2[i] == '_')
                                {
                                    sb.Append(command2[i].ToString());
                                }
                                else
                                {
                                    Console.WriteLine("Emrat duhet të përmbajnë vetëm simbolet A-Z, a-z, 0-9,dhe _");
                                    return;
                                }
                            }
                            command2 = sb.ToString();
                            rsa = new RsaEncryptor();
                            string privateKey = rsa.GetPrivateKey();
                            string publicKey = rsa.GetPublicKey();
                            string privkey = di + command2 + ".xml";
                            string pubkey = di + command2 + ".pub.xml";
                            if (File.Exists(privkey) && File.Exists(pubkey))
                            {
                                Console.WriteLine("Gabim: Celesi '" + command2 + "' ekziston paraprakisht.");
                                return;
                            }
                            File.WriteAllText(di + command2 + ".xml", privateKey);
                            File.WriteAllText(di + command2 + ".pub.xml", publicKey);

                            Console.WriteLine("Eshte krijua celsi privat '" + privkey + "'");
                            Console.WriteLine("Eshte krijua celsi publik '" + pubkey + "'");

                        }
                    }
                    catch
                    {
                        Console.WriteLine("Kerkesa duhet te jete: create-user <emri>");
                        return;
                    }
                }
                
                else if (command == "delete-user")
                {
                    try
                    {
                        if (args[1].Length != 0)
                        {
                            string command2 = args[1];
                            StringBuilder sb = new StringBuilder();
                            for (int i = 0; i < command2.Length; i++)
                            {
                                if ((command2[i] >= '0' && command2[i] <= '9') || (command2[i] >= 'A' && command2[i] <= 'Z') || (command2[i] >= 'a' && command2[i] <= 'z') || command2[i] == '_')
                                {
                                    sb.Append(command2[i].ToString());
                                }
                                else
                                {
                                    Console.WriteLine("Emrat duhet të përmbajnë vetëm simbolet A-Z, a-z, 0-9,dhe _");
                                    return;
                                }
                            }
                            command2 = sb.ToString();
                            rsa = new RsaEncryptor();
                            string privateKey = rsa.GetPrivateKey();
                            string publicKey = rsa.GetPublicKey();
                            string privkey = di + command2 + ".xml";
                            string pubkey = di + command2 + ".pub.xml";
                            if (File.Exists(privkey) && File.Exists(pubkey))
                            {
                                File.Delete(privkey);
                                File.Delete(pubkey);
                                Console.WriteLine("Eshte larguar celsi privat '" + privkey + "'");
                                Console.WriteLine("Eshte larguar celsi publik '" + pubkey + "'");
                            }
                            else
                            {
                                Console.WriteLine("Gabim: Celesi '" + command2 + "' nuk ekziston.");
                            }
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Kerkesa duhet te jete: delete-user <emri>");
                        return;

                    }
                }
                else if (command == "list-keys")//Komande shtese -> listimi i celesave (needs to convert from path name > name:) 
                {

                    Dictionary<string, string> list_keys = new Dictionary<string, string>();
                    string[] fCount = Directory.GetFiles(@"C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\keys\", "*.xml");

                    foreach (string k in fCount)
                    {
                        string val = File.ReadAllText(@k, Encoding.UTF8);
                        list_keys.Add(k, val);

                    }
                    foreach (KeyValuePair<string, string> item in list_keys)
                    {
                        Console.WriteLine("Key: {0}, \nValue: {1}\n\n", item.Key, item.Value);

                    }
                }

                else if (command == "write-message")
                {
                    string input = args[1];

                    string pubkey = di + input + ".pub.xml";
                    DESCryptoServiceProvider objDes = new DESCryptoServiceProvider();

                    string randKey = Convert.ToBase64String(objDes.Key);
                    string randiv = Convert.ToBase64String(objDes.IV);


                    if (File.Exists(pubkey))
                    {
                        if (args.Length == 3)
                        {

                            string publicKey = File.ReadAllText(di + input + ".pub.xml");
                            string tekst = args[2];

                            Console.WriteLine("\n" + WR.Base64Encode(input) + "." + WR.Base64Encode(randiv) + "." + WR.rsa_Encrypt(randKey, publicKey) + "." + WR.des_Encrypt(tekst, randKey, randiv));
                        }
                        else if (args.Length == 4)
                        {
                            string publicKey = File.ReadAllText(di + input + ".pub.xml");
                            string tekst = args[2];
                            string file = args[3];
                            DirectoryInfo di2 = Directory.CreateDirectory(@"C:\Users\Admin\Desktop\GIT\siguri-grup\ds2\files\");
                            using (StreamWriter sw = File.CreateText(di2 + file)) ;

                            string g = ("\n" + WR.Base64Encode(input) + "." + WR.Base64Encode(randiv) + "." + WR.rsa_Encrypt(randKey, publicKey) + "." + WR.des_Encrypt(tekst, randKey, randiv));
                            File.WriteAllText(di2 + file, g);

                            Console.WriteLine("Mesazhi i enkriptuar u ruajt ne fajllin: " +di2 + file);
                        }
                        else
                        {
                            Console.WriteLine("Numri i argumenteve nuk eshte valid!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Celesi publik " + input + " nuk ekziston.");
                    }
                }
                else if (command == "read-message")
                {
                    string cipher = args[1];
                    var array = cipher.Split(new[] { '.' }, 4);

                    string firstElem = array[0];
                    string second = array[1];
                    string third = array[2];
                    string fourth = array[3];
                    if (WR.Check_Base64(firstElem) && WR.Check_Base64(second) && WR.Check_Base64(third) && WR.Check_Base64(fourth))
                    {
                        string input = WR.Base64Decode(firstElem);
                        string privkey = di + input + ".xml";

                        if (File.Exists(privkey))
                        {
                            Console.WriteLine("Marresi: " + input);
                            string privateKey = File.ReadAllText(di + input + ".xml");

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
                        Console.WriteLine("Nuk eshte Base64!");
                    }
                }
                else
                {
                    Console.WriteLine("Kerkesa duhet te jete: <create-user> <delete-user> <write-message> <read-message>");
                    return;
                }
            }

        }
    }
}
