using System;
using System.Collections;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;


namespace BloomFilter
{
	class Program
	{
		static void Main(string[] args)
		{
			var program = new Program();
			var listOfWords = new DownloadWords();
			var test = new BloomFilter();

			foreach (var word in listOfWords.Words)
			{ 
				test.SetValuesInBloomFilter(word);
			}

			var result1 = test.CheckBloomFilter("Abderian's");
			var result2 = test.CheckBloomFilter("telangiectasias");
			var result3 = test.CheckBloomFilter("événements");
			var result4 = test.CheckBloomFilter("maw's");
			var result5 = test.CheckBloomFilter("BeastModeBarry");
			var result6 = test.CheckBloomFilter("2");
			var result7 = test.CheckBloomFilter("2582430957hfdjskfbsdkfbsjkdbf");

			Console.WriteLine(result1);
			Console.WriteLine(result2);
			Console.WriteLine(result3);
			Console.WriteLine(result4);
			Console.WriteLine(result5);
			Console.WriteLine(result6);
			Console.WriteLine(result7);
			Console.WriteLine();
			Console.ReadLine();
		}
	}
}
