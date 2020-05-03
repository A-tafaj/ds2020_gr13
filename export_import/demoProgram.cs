using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

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
                DirectoryInfo di = Directory.CreateDirectory("keys/");

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
                            Console.WriteLine("Eshte krijua celse publik '" + pubkey + "'");

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
                                Console.WriteLine("Eshte larguar celse publik '" + pubkey + "'");
                            }
                            else
                            {
                                Console.WriteLine("Gabim: Celesi '" + command2 + "' ekziston paraprakisht.");
                            }
                        }

                    }
                    catch
                    {
                        Console.WriteLine("Kerkesa duhet te jete: delete-user <emri>");
                        return;

                    }
                }
                //++++++++++++++++++++++++++++++++++ pjesen brenda ++ e kmei te vs2020 para kodit koment 

                else if (command == "export-key")
                {
                    try
                    {
                        if (args[1].Length != 0 && args[2].Length != 0)
                        {
                            string type = args[1];
                            string name = args[2];
                            //DirectoryInfo dir = Directory.CreateDirectory("keys/");
                            //We have di for directory $top.
                            string privKeysDir = /*dir*/ di + name + ".xml";
                            string pubKeysDir = /*dir*/di +name + ".pub.xml";
                            if (File.Exists(pubKeysDir) && File.Exists(privKeysDir))
                            {
                                if (args.Length == 3)
                                {
                                    if (type == "public")
                                    {
                                        string publicKey = File.ReadAllText(/*dir*/ di + name + ".pub.xml");
                                        char[] seperator = { '>' };////
                                        String[] strlist = publicKey.Split(seperator);
                                        foreach(String s in strlist){Console.Write(s + ">"); Console.WriteLine();}
                                        //string publicKey = File.ReadAllText(/*dir*/ di + name + ".pub.xml");
                                        //Console.WriteLine("\n" + publicKey + "\n");
                                    }
                                    else if (type == "private")
                                    {
                                        string privateKey = File.ReadAllText(/*dir*/ di + name + ".xml");
                                        privateKey = privateKey.Replace(">", ">" + System.Environment.NewLine);
                                        Console.WriteLine("\n" + privateKey + "\n");
                                    }
                                }
                                else if (args.Length == 4/*> 3*/)
                                {
                                    string expFile = args[3];
                                    DirectoryInfo expDir = Directory.CreateDirectory("exported/");
                                    using (StreamWriter strw = File.CreateText(expDir + expFile)) ;
                                    string publicKey = File.ReadAllText(/*dir*/ di + name + ".pub.xml");//
                                    File.WriteAllText(expDir + expFile, publicKey);
                                    Console.WriteLine("Celesi publik u ruajt ne fajllin " + expFile + ".xml");
                                }
                            }
                            else if(File.Exists(pubKeysDir) && !File.Exists(privKeysDir))
                            {

                                if (args.Length == 3)
                                {
                                    if (type == "public")
                                    {
                                        string publicKey = File.ReadAllText(/*dir*/ di + name + ".pub.xml");
                                        Console.WriteLine("\n" + publicKey + "\n");
                                    }
                                    else if (type == "private")
                                    {
                                        //string privateKey = File.ReadAllText(/*dir*/ di + name + ".xml");
                                        Console.WriteLine("\nGabim: Celesi privat " + name + " nuk ekziston\n");
                                    }
                                }
                                else if (args.Length == 4/*> 3*/)
                                {
                                    string expFile = args[3];
                                    DirectoryInfo expDir = Directory.CreateDirectory("exported/");
                                    using (StreamWriter strw = File.CreateText(expDir + expFile)) ;
                                    string publicKey = File.ReadAllText(/*dir*/ di + name + ".pub.xml");//
                                    File.WriteAllText(expDir + expFile, publicKey);
                                    Console.WriteLine("Celesi publik u ruajt ne fajllin " + expFile);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Gabim: Celesi publik " + name +" nuk ekziston.");
                            }
                        
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Kerkesa duhet te jete: export-key <public|private> <name> dhe [file] opsionale");
                    }
                }
                //++++++++++++++++++++++++++++++++++
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
                            //++++++
                            string privateKey = File.ReadAllText(di + input + ".xml");
                            //++++++
                            string tekst = args[2];

                            // Console.WriteLine(RSA.Encrypt(tekst, publicKey)+"\n\n");
                            Console.WriteLine("\n" + "+++++++++++" + publicKey + "\n");
                            Console.WriteLine("\n" + "+++++++++++" + privateKey + "\n");//++++++++++++
                            Console.WriteLine("++++++++++++++++\n" + WR.Base64Encode(input) + "." + WR.Base64Encode(randiv) + "." + WR.rsa_Encrypt(randKey, publicKey) + "." + WR.des_Encrypt(tekst, randKey, randiv));
                        }
                        else if (args.Length > 3)
                        {
                            string publicKey = File.ReadAllText(di + input + ".pub.xml");
                            string tekst = args[2];
                            string file = args[3];
                            DirectoryInfo di2 = Directory.CreateDirectory("files/");
                            using (StreamWriter sw = File.CreateText(di2 + file)) ;

                            string g = ("\n" + WR.Base64Encode(input) + "." + WR.Base64Encode(randiv) + "." + WR.rsa_Encrypt(randKey, publicKey) + "." + WR.des_Encrypt(tekst, randKey, randiv));
                            File.WriteAllText(di2 + file, g);

                            Console.WriteLine("Mesazhi i enkriptuar u ruajt ne fajllin" + "files/" + file);
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
                    Console.WriteLine("Kerkesa duhet te jete: <create-user> <delete-user> <write-message> <read-message>");
                    return;
                }
            }

        }
    }
}
