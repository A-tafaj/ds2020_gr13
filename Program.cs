using System;
using System.Globalization;
using System.Text;
//Fillimisht duhet te cekni se cilin shembull deshironi ta ekzekutoni :Case apo Sentence .
/*Ne fillim duhet te cekni se si deshironi ta ndryshoni "case" ne njeren nga keto llojet:
 (lower,upper,capitalize,inverse,alternate),nese jepet gabim do te paraqes si "Invalid orders"
 */
namespace Case
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Case or Sentence ?");
            string SorC = Console.ReadLine().ToLower();
            if (SorC == "sentence")
            {
                Console.WriteLine("Shkruani fjalite:");
                
                string str1 = Console.ReadLine();
                string b = Console.ReadLine();
                string str3 = Console.ReadLine();
                string c = Console.ReadLine();
                Console.WriteLine("Grupi i dyte i fjalive-->");
                string d = Console.ReadLine();
                string str6 = Console.ReadLine();
                string e = Console.ReadLine();
                string f = Console.ReadLine();
                Console.WriteLine("============================================================================");
                Console.Write(str1.ToLower() + " "); str2(b); Console.Write(" " + str3.ToUpper() + " "); str4(c);
                Console.WriteLine(); str5(d); Console.Write(" " + str6.ToLower() + " "); str7(e); Console.Write(" "); str8(f);
                Console.WriteLine("\n============================================================================");
                static void str2(string b)
                {
                    
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < b.Length; i++)
                    {

                        if (i == 0 || i == 7)
                        {
                            sb.Append(b[i].ToString().ToUpper());
                        }
                        else
                        {
                            sb.Append(b[i].ToString().ToLower());
                        }
                    }
                    sb.ToString();
                    Console.Write(sb);
                }
                 static void str4(string c)
                {

                    
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < c.Length; i++)
                    {

                        if (i == 2 || i == 7 || i == 11)
                        {
                            sb.Append(c[i].ToString().ToUpper());
                        }
                        else
                        {
                            sb.Append(c[i].ToString().ToLower());
                        }
                    }
                    sb.ToString();
                    Console.Write(sb);
                }
                static void str5(string d)
                {

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < d.Length; i++)
                    {

                        if (i == 0)
                        {
                            sb.Append(d[i].ToString().ToUpper());
                        }
                        else
                        {
                            sb.Append(d[i].ToString().ToLower());
                        }
                    }
                    sb.ToString();
                    Console.Write(sb);
                }
                static void str7(string e)
                {

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < e.Length; i++)
                    {

                        if (i == 0)
                        {
                            sb.Append(e[i].ToString().ToUpper());
                        }
                        else
                        {
                            sb.Append(e[i].ToString().ToLower());
                        }
                    }
                    sb.ToString();
                    Console.Write(sb);
                }
                static void str8(string f)
                {

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < f.Length; i++)
                    {

                        if (i == 0)
                        {
                            sb.Append(f[i].ToString().ToUpper());
                        }
                        else
                        {
                            sb.Append(f[i].ToString().ToLower());
                        }
                    }
                    sb.ToString();
                    Console.Write(sb);
                }
            }
            else
            {
                Console.Write("Case form:");
                string str = Console.ReadLine().ToLower();
                Console.WriteLine("Convertion :" + str.ToUpperInvariant());
                Console.Write("Enter a string please:");
                string convertion = Console.ReadLine();
                if (str == "lower")
                {
                    Console.WriteLine(convertion.ToLower());
                }
                else if (str == "upper")
                {
                    Console.WriteLine(convertion.ToUpper());
                }
                else if (str == "capitalize")//Huazuar nga Interneti.
                {
                    string cap = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(convertion.ToLower());
                    Console.WriteLine(cap);
                }
                else if (str == "inverse")//Huazuar pjeserisht nga interneti.
                {


                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < convertion.Length; i++)
                    {

                        if ((convertion[i] >= 'a' && convertion[i] <= 'z') || convertion[i] == ' ')
                        {
                            sb.Append(convertion[i].ToString().ToUpper());
                        }
                        else if ((convertion[i] >= 'A' && convertion[i] <= 'Z') || convertion[i] == ' ')
                        {
                            sb.Append(convertion[i].ToString().ToLower());
                        }
                    }
                    sb.ToString();
                    Console.WriteLine(sb);
                }
                else if (str == "alternate")//huazuar pjeserisht nga Interneti.
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
    }
/*Shembulli per Sentence:
 *Case or Sentence ?
sentence
Shkruani fjalite:
pershendetje,
fjalia e pare.
fjalia e dyte!
fjalia e trete.
Grupi i dyte i fjalive-->
pershendetje,
fjalia e pare.
fjalia e dyte!
fjalia e trete.
============================================================================
pershendetje,  Fjalia E pare.  FJALIA E DYTE!  fjAlia E trEte.
Pershendetje,  fjalia e pare.  Fjalia e dyte!  Fjalia e trete.
============================================================================
 */
/*=============================================================================
 * Shembulli per case
 * Case or Sentence ?
case
Case form:lower
Convertion :LOWER
Enter a string please:Pershendetje nga FIEK!
pershendetje nga fiek!
=====================================================
    Case or Sentence ?
case
Case form:upper
Convertion :UPPER
Enter a string please:Pershendetje nga FIEK!
PERSHENDETJE NGA FIEK!
==========================================================
    Case or Sentence ?
case
Case form:capitalize
Convertion :CAPITALIZE
Enter a string please:Pershendetje nga FIEK!
Pershendetje Nga Fiek!

    =====================================================
    Case or Sentence ?
case
Case form:inverse
Convertion :INVERSE
Enter a string please:Pershendetje nga FIEK!
pERSHENDETJE NGA fiek

==========================================================
Case or Sentence ?
case
Case form:alternate
Convertion :ALTERNATE
Enter a string please:Pershendetje nga FIEK!
pErShEnDeTjE NgA FiEk!


C:\Users\HP\source\repos\Case\Case\bin\Debug\netcoreapp3.1\Case.exe (process 10284) exited with code 0.
To automatically close the console when debugging stops, enable Tools->Options->Debugging->Automatically close the console when debugging stops.
Press any key to close this window . . .

 */
