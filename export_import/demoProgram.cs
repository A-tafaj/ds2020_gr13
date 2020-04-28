using System;
namespace Transfer
{
    class Program
    {
        public static void Main(String[] args)
        {

            if (args.Length > 0)
            {
                if (args[0] == "export-key")
                {
                    string emri = args[1];
                }
                else if (args[0] == "import-key")
                {
                    string emri = args[1];
                }
                else
                {
                    Console.WriteLine("Shtypni njeren nga keto komanda: <export-key> ose <import-key>");
                }


            }


        }
    }

}