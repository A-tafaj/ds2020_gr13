using System;
using System.Globalization;
using System.Text;
/*Ne fillim duhet te cekni se si deshironi ta ndryshoni "case" ne njeren nga keto llojet:
 (lower,upper,capitalize,inverse,alternate),nese jepet gabim do te paraqes si "Invalid orders"
 */
namespace Case
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Case form:");
            string str = Console.ReadLine().ToLower();
            Console.WriteLine("Convertion :"+str.ToUpperInvariant());
            Console.Write("Enter a string please:");
            string convertion = Console.ReadLine();
            if (str == "lower")
            {
                Console.WriteLine(convertion.ToLower());
            }
            else if (str=="upper")
            {
                Console.WriteLine(convertion.ToUpper());
            }
            else if(str=="capitalize")//Huazuar nga Interneti.
            {
                string cap = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(convertion.ToLower());
                Console.WriteLine (cap);
            }
            else if(str== "inverse")//Huazuar pjeserisht nga interneti.
            {


                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < convertion.Length; i++)
                {

                    if ((convertion[i] >= 'a' && convertion[i] <= 'z')||convertion[i]==' ')
                    {
                        sb.Append(convertion[i].ToString().ToUpper());
                    }
                    else if((convertion[i] >= 'A' && convertion[i] <= 'Z')|| convertion[i] == ' ')
                    {
                        sb.Append(convertion[i].ToString().ToLower());
                    }
                }
                sb.ToString();
                Console.WriteLine(sb);
            }
            else if(str=="alternate")//huazuar pjeserisht nga Interneti.
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < convertion.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        sb.Append(convertion[i].ToString().ToLower());
                    }
                    else
                    {
                        sb.Append(convertion[i].ToString().ToUpper());
                    }
                }
                sb.ToString();
                Console.WriteLine(sb);
            }
            else
            {
                Console.Error.WriteLine("Invalid orders.");
            }
            Console.ReadLine();
        }
    }
}
