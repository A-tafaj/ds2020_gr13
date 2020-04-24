using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;


/*
 * C:\Users\HP\source\repos\rsaa\rsaa\bin\Debug\netcoreapp3.1>rsaa create-user Fiek.1
Argumenti i dyte duhet te jete A-Z,a-z,0-9.

C:\Users\HP\source\repos\rsaa\rsaa\bin\Debug\netcoreapp3.1>rsaa create-user Fiek1
Eshte krijua celsi privat 'keys/Fiek1.xml'
Eshte krijua celse publik 'keys/Fiek1.pub.xml'

C:\Users\HP\source\repos\rsaa\rsaa\bin\Debug\netcoreapp3.1>rsaa create-user Fiek1
Gabim: Celesi 'Fiek1' ekziston paraprakisht.

C:\Users\HP\source\repos\rsaa\rsaa\bin\Debug\netcoreapp3.1>rsaa delete-user Fiek1
Eshte larguar celsi privat 'keys/Fiek1.xml'
Eshte larguar celse publik 'keys/Fiek1.pub.xml'

C:\Users\HP\source\repos\rsaa\rsaa\bin\Debug\netcoreapp3.1>rsaa delete-user Fiek1
Gabim: Celesi 'Fiek1' ekziston paraprakisht.

*/
namespace RsaSignature
{
    class Program
    {
        static void Main(string[] args)
        {
            void VerifyLength(int length)
            {
                if (args.Length < length)
                {
                    throw new Exception("Mungojne argumentet.");
                }
            }

            VerifyLength(1);

            string command = args[0];

            RsaEncryptor rsa;

            if (command=="create-user")
            {
                    
                        string command2 = args[1];
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i < command2.Length; i++)
                {
                    if ((command2[i] >= '0' && command2[i] <= '9') || (command2[i] >= 'A' && command2[i] <= 'Z' )|| (command2[i] >= 'a' && command2[i] <= 'z'))
                    {
                        sb.Append(command2[i].ToString());
                    }
                    else
                    {
                        Console.WriteLine("Argumenti i dyte duhet te jete A-Z,a-z,0-9.");
                        return;
                    }
                }
                command2 = sb.ToString();
                rsa = new RsaEncryptor();
                        string privateKey = rsa.GetPrivateKey();
                        string publicKey = rsa.GetPublicKey();
                string privkey = "keys/" + command2 + ".xml";
                string pubkey = "keys/" + command2 + ".pub.xml";
                if (File.Exists(privkey)&&File.Exists(pubkey))
                {
                    Console.WriteLine("Gabim: Celesi '"+command2+"' ekziston paraprakisht.");
                    return;
                }
                File.WriteAllText("keys/"+command2+".xml", privateKey);
                File.WriteAllText("keys/"+command2+".pub.xml", publicKey);
                
                Console.WriteLine("Eshte krijua celsi privat '"+privkey+"'");
                Console.WriteLine("Eshte krijua celse publik '"+pubkey+"'");
                
            }
            else if (command == "delete-user")
            {

                string command2 = args[1];
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < command2.Length; i++)
                {
                    if ((command2[i] >= '0' && command2[i] <= '9') || (command2[i] >= 'A' && command2[i] <= 'Z' )|| (command2[i] >= 'a' && command2[i] <= 'z'))
                    {
                        sb.Append(command2[i].ToString());
                    }
                    else
                    {
                        Console.WriteLine("Argumenti i dyte duhet te jete A-Z,a-z,0-9.");
                        return;
                    }
                }
                command2 = sb.ToString();
                rsa = new RsaEncryptor();
                string privateKey = rsa.GetPrivateKey();
                string publicKey = rsa.GetPublicKey();
                string privkey = "keys/" + command2 + ".xml";
                string pubkey = "keys/" + command2 + ".pub.xml";
                if (File.Exists(privkey) && File.Exists(pubkey))
                {
                    File.Delete(privkey);
                    File.Delete(pubkey);
                    Console.WriteLine("Eshte larguar celsi privat '" + privkey + "'");
                    Console.WriteLine("Eshte larguar celse publik '" + pubkey + "'");
                }
                else
                {
                    Console.WriteLine("Gabim: Celesi '"+command2+"' ekziston paraprakisht.");
                }
            }
        }
    }


    class RsaEncryptor
    {
        private readonly RSACryptoServiceProvider rsacsp;

        public RsaEncryptor()
        {
            rsacsp = new RSACryptoServiceProvider();
        }

        public RsaEncryptor(string privateKey)
        {
            rsacsp = new RSACryptoServiceProvider();
            rsacsp.FromXmlString(privateKey);
        }

        public string GetPublicKey()
        {
            return rsacsp.ToXmlString(false);
        }

        public string GetPrivateKey()
        {
            return rsacsp.ToXmlString(true);
        }

        public string EncryptTextFor(string plaintext, string publicKey)
        {
            var otherParty = new RSACryptoServiceProvider();
            otherParty.FromXmlString(publicKey);

            return EncryptText(plaintext, otherParty);
        }

        public string EncryptText(string plaintext)
        {
            return EncryptText(plaintext, this.rsacsp);
        }

        public string DecryptText(string ciphertext)
        {
            // Decryption

            // ciphertext (base64) -> ciphertext (byte[]) - Convert.FromBase64String
            byte[] ciphertextBytes = Convert.FromBase64String(ciphertext);

            // ciphertext (byte[]) -> plaintext (byte[])  - rsa.Decrypt
            byte[] plaintextBytes = rsacsp.Decrypt(ciphertextBytes, true);

            // plaintext (byte[])  -> plaintext (string)  - Encoding.UTF8.GetString
            string plaintext = Encoding.UTF8.GetString(plaintextBytes);

            return plaintext;
        }

        private static string EncryptText(string plaintext, RSACryptoServiceProvider rsa)
        {
            // Encryption

            // plaintext (string)  -> plaintext (byte[])  - Encoding.UTF8.GetBytes
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);

            // plaintext (byte[])  -> ciphertext (byte[]) - rsa.Encrypt
            byte[] ciphertextBytes = rsa.Encrypt(plaintextBytes, true);

            // ciphertext (byte[]) -> ciphertext (base64) - Convert.ToBase64String
            string ciphertextString = Convert.ToBase64String(ciphertextBytes);

            return ciphertextString;
        }
    }
}
