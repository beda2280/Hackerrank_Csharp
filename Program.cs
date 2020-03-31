using System;
using System.Collections.Generic;

namespace Hackerrank
{
	class Program
	{
		static void Main(string[] args)
		{
			/* A program that prints integers from 1 to N. But for integers that are multiples of A, print 'F', 
			and for multiples of B, print 'B'. For integers which are multiples of both A and B, print 'FB'.*/

			Console.Write("\n Please enter number of integers: ");
			int n = int.Parse(Console.ReadLine());

			Console.Write("\nPlease select first integers that are multiples of A: ");
			int A = int.Parse(Console.ReadLine());

			Console.Write("\nPlease select second integers that are multiples of B: ");
			int B = int.Parse(Console.ReadLine());

			for (int i = 1; i <= n; i++)
			{
				if (i % A == 0 && i % B == 0)
				{
					Console.WriteLine("FB", i);
				}
				else if (i % B == 0)
				{
					Console.Write("B", i);
				}
				else if (i % A == 0)
				{
					Console.Write("F", i);
				}

				Console.Write("{0}", i + " ");
			}

			/*-------------------------------------------------------------------------*/
			String[] helptext = { "Purchase", "Order", "Item", "help", "can't", "find", "item", "item", "is ",
						"too", "much", "part", "of", "purchase", "need", "fic", "for", "image",
				        "item", "delivered", "too", "fast", "purchase", "order", "too", "big", "is",
				         "purchase", "order", "coming", "?", "too", "big", "why", ""};
			String sol = retrieveMostFrequentlyUsedWords(helptext);

			// Print word having highest frequency  
			Console.WriteLine("\n\nMost frequently used word in the help search box:" + sol);

			/*-------------------------------------------------------------------------*/

			Console.WriteLine("\n\nHello Simple Math World!\n");
			int val1 = 2;
			int val2 = 3;
			int sum = val1 + val2;
			Console.WriteLine("\n2 + 3 = " + sum + "\n");
			Console.WriteLine("\n------------------------------------\n");

			int[,] mat = {{1,  4,  7, 11, 15},
						  {2,  5,  8, 12, 19},
						  {3,  6,  9, 16, 22},
						  {10, 13, 14, 17, 24},
						  {18, 21, 23, 26, 30} };

			search(mat, 4, 13);
			Console.WriteLine("\n------------------------------------\n");

			/*-----------------------------------------------------------------------*/

			List<String> myco = new List<string>();
			myco.Add("One");
			myco.Add("Two");
			myco.Add("Three");
			myco.Sort();
			myco.Insert(1, "Four");
			myco.RemoveAt(2);
			foreach (String NextItem in myco)
			{
				Console.WriteLine(NextItem);
			}
			/*-----------------------------------------------------------------------*/
		}

		private static void search(int[,] mat, int n, int x)
		{
			int i = 0, j = n - 1;

			while (i < n && j >= 0)
			{
				if (mat[i, j] == x)
				{
					Console.Write("\n n Found at " + i + ", " + j);
					return;
				}

				if (mat[i, j] > x)
					j--;
				else
					i++;
			}

			Console.Write("\n n Element not found\n");
			return;
		}

		public static String retrieveMostFrequentlyUsedWords(String[] helptext)
		{
			 
			Dictionary<String, int> hs = new Dictionary<String, int>();

			// Iterate through array of words  
			for (int i = 0; i < helptext.Length; i++)
			{
				// If word already exist in Dictionary  
				// then increase it's count by 1  
				if (hs.ContainsKey(helptext[i]))
				{
					hs[helptext[i]] = hs[helptext[i]] + 1;
				}

				// Otherwise add word to Dictionary  
				else
				{
					hs.Add(helptext[i], 1);
				}
			}
			// Create set to iterate over Dictionary  
			String key = "";
			int value = 0;

			foreach (KeyValuePair<String, int> me in hs)
			{
				// Check for word having highest frequency  
				if (me.Value > value)
				{
					value = me.Value;
					key = me.Key;
				}
			}
			// Return word having highest frequency  
			return key;
		}
	}
}
