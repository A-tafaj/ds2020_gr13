using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;
/*===========================================================================

C:\Users\HP\source\repos\rsaa\rsaa\bin\Debug\netcoreapp3.1>rsaa create-user Kompjuterika
Eshte krijua celsi privat 'keys/Kompjuterika.xml'
Eshte krijua celse publik 'keys/Kompjuterika.pub.xml'
==============================================================================*/
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

            if (command == "create-user")
            {

                string command2 = args[1];
                rsa = new RsaEncryptor();
                string privateKey = rsa.GetPrivateKey();
                string publicKey = rsa.GetPublicKey();
                File.WriteAllText("keys/" + command2 + ".xml", privateKey);
                File.WriteAllText("keys/" + command2 + ".pub.xml", publicKey);
                string privkey = "keys/" + command2 + ".xml";
                string pubkey = "keys/" + command2 + ".pub.xml";
                Console.WriteLine("Eshte krijua celsi privat '" + privkey + "'");
                Console.WriteLine("Eshte krijua celse publik '" + pubkey + "'");

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
