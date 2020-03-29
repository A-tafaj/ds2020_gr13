using System;
namespace ds
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length > 0)
			{
				if (args[0]=="four-square")
				{
					try
					{
						if (args[1] == "encrypt")
						{
							try
							{
								string plaintext = args[2];
								string key1 = args[3];
								string key2 = args[4];
								Console.WriteLine("Encryption: " + FS.Encrypt(plaintext, key1, key2));
							}

							catch (Exception)
							{
								Console.WriteLine("You should put arguments in this order: <plaintext> <key1> <key2>" +
									"\nIf plaintext is a sentence, put them in \"\", key must be one word and contain only letters!");
							}
						}
						else if (args[1] == "decrypt")
						{
							try
							{
								string ciphertext = args[2];
								string key1 = args[3];
								string key2 = args[4];
								Console.WriteLine("Decryption: " + FS.Decrypt(ciphertext, key1, key2));
							}

							catch (Exception)
							{
								Console.WriteLine("You should put arguments in this order: <ciphertext> <key1> <key2>");
							}
						}
						else
						{
							Console.WriteLine("Your command should be: <encrypt> or <decrypt> ");
						}
					}
					catch (Exception)
					{
						Console.WriteLine("COMMANDS: <encrypt> <decrypt>");
					}
				}

				else if (args[0] == "case")
				{
					try
					{
						if (args[1] == "lower")
						{
							string word = args[2];
							Console.WriteLine(word.ToLower());
						}
						else if (args[1] == "upper")
						{
							string word = args[2];
							Console.WriteLine(word.ToUpper());
						}
						else if (args[1] == "capitalize")
						{
							string word = args[2];
							Console.WriteLine(CASE.Capitalize(word));
						}
						else if (args[1] == "inverse")
						{
							string word = args[2];
							Console.WriteLine(CASE.Inverse(word));
						}
						else if (args[1] == "alternating")
						{
							string word = args[2];
							Console.WriteLine(CASE.Alternating(word));
						}
						else if (args[1] == "sentence")
						{
							string a = args[2];
							Console.Write(a.ToLower() + ", " + CASE.Str2(a) + ". " + a.ToUpper() + "! " + CASE.Str4(a) + ".\n" + CASE.Str5(a) + ", " + a.ToLower() + ". " + CASE.Str7(a) + "! " + CASE.Str8(a) + ".");
						}
						else
							Console.WriteLine("Your command was wrong, choice one of the cases: <lower> <upper> <capitalize> <inverse> <alternating> <sentence>");
					}
					catch (Exception)
					{
						Console.WriteLine("CASES: <lower> <upper> <capitalize> <inverse> <alternating> <sentence> ");
					}
				}
				else
				{
					Console.WriteLine("You should provide a valid METHOD: <four-square> <case> <rail-fence>");
				}
			}
		}
	}
}