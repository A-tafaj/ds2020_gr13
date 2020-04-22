using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RSA
{
    class Program
    {
        static RSACryptoServiceProvider objRSA = new RSACryptoServiceProvider();
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                try
                {
                    if (args[0].Equals("p"))
                    {
                        RSAParameters objParameters = objRSA.ExportParameters(true);
                        string strP = BitConverter.ToString(objParameters.P);
                        string strQ = BitConverter.ToString(objParameters.Q);
                        string strN = BitConverter.ToString(objParameters.Modulus);
                        string strE = BitConverter.ToString(objParameters.Exponent);
                        string strD = BitConverter.ToString(objParameters.D);

                        Console.WriteLine("P: " + strP);
                        Console.WriteLine("Q: " + strQ);
                        Console.WriteLine("n: " + strN);
                        Console.WriteLine("e: " + strE);
                        Console.WriteLine("d: " + strD);
                    }
                    else if (args[0].Equals("e"))
                    {
                        byte[] bytePlaintexti = Encoding.UTF8.GetBytes(args[1]);
                        byte[] byteCiphertexti = objRSA.Encrypt(bytePlaintexti, true);

                        Console.WriteLine(Convert.ToBase64String(byteCiphertexti));

                        Console.WriteLine("A deshironi te beni dekriptimin?");
                        string q = Console.ReadLine();

                        if (q.Equals("P") || q.Equals("p"))
                        {
                            byte[] byteDecryptedtext = objRSA.Decrypt(byteCiphertexti, true);

                            Console.WriteLine("Texti i dekriptuar: " + Encoding.UTF8.GetString(byteDecryptedtext));
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}