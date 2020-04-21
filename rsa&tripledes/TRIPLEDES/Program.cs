﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace TripleDES_1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                try
                {
                    if (args[0].Equals("e"))
                    {
                        string plaintexti = args[1];
                        string ciphertexti = Encrypt(plaintexti, args[2]);

                        Console.WriteLine("Encrypted text: " + ciphertexti);
                    }
                    else
                    {
                        string ciphertext = args[1];
                        string decryptedText = Decrypt(ciphertext, args[2]);

                        Console.WriteLine("Decrypted text: " + decryptedText);
                    }

                    Console.ReadKey();
                }




                catch (Exception)
                {

                    throw;
                }
            }
        }
        static string Encrypt(string plaintext, string key)
        {
            byte[] bytePlaintext = Encoding.UTF8.GetBytes(plaintext);

            TripleDESCryptoServiceProvider objTripleDES = new TripleDESCryptoServiceProvider();
            if (key.Length != 24)
                return "Madhesia e celesit nuk eshte valide!";

            objTripleDES.Key = Encoding.UTF8.GetBytes(key);
            objTripleDES.Padding = PaddingMode.Zeros;
            objTripleDES.Mode = CipherMode.ECB;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, objTripleDES.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(bytePlaintext, 0, bytePlaintext.Length);
            cs.Close();

            byte[] byteCiphertext = ms.ToArray();

            return Convert.ToBase64String(byteCiphertext);
        }

        static string Decrypt(string ciphertext, string key)
        {
            byte[] byteCiphertext = Convert.FromBase64String(ciphertext);

            TripleDESCryptoServiceProvider objTripleDES = new TripleDESCryptoServiceProvider();
            if (key.Length != 24)
                return "Madhesia e celesit nuk eshte valide!";

            objTripleDES.Key = Encoding.UTF8.GetBytes(key);
            objTripleDES.Padding = PaddingMode.Zeros;
            objTripleDES.Mode = CipherMode.ECB;

            MemoryStream ms = new MemoryStream(byteCiphertext);
            byte[] byteDecryptedtext = new byte[ms.Length];
            CryptoStream cs = new CryptoStream(ms, objTripleDES.CreateDecryptor(), CryptoStreamMode.Read);
            cs.Read(byteDecryptedtext, 0, byteDecryptedtext.Length);
            cs.Close();

            return Encoding.UTF8.GetString(byteDecryptedtext);
        }
    }
}