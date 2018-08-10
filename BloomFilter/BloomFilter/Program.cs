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

			var test = new BloomFilter("Sam");
			var a = test.CheckBloomFilter("Sam");
			var test2 = new BloomFilter("Bob");
			var b = test2.CheckBloomFilter("Bob");
			
			Console.WriteLine(a);
			Console.WriteLine(b);
			Console.ReadLine();
		}
	}
}
