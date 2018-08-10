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
			BitArray bitArray = new BitArray(1000, false);

			var sam = program.CalculateMD5Hash("Sam");
			var bob = program.CalculateMD5Hash("Bob");

			bitArray = program.SetValuesInBloomFilter(bitArray, sam);
			var search = program.CheckBloomFilter(bitArray, sam);
			var search2 = program.CheckBloomFilter(bitArray, bob);


			Console.WriteLine(search);
			Console.WriteLine(search2);
			Console.ReadLine();
		}

		private int[] CalculateMD5Hash(string input)
		{
			MD5 md5 = MD5.Create();

			byte[] inputBytes = Encoding.ASCII.GetBytes(input);
			byte[] hash = md5.ComputeHash(inputBytes);
			int[] hashInts = new int[5];

			for (int i = 0; i < 5; i++)
			{
				var hashInt = Convert.ToInt32(hash[i]);
					hashInts[i] = hashInt;
			}

			return hashInts;
		}

		private BitArray SetValuesInBloomFilter(BitArray bitArray, int[]input)
		{
			foreach (var item in input)
			{
				bitArray[item] = true;
			}

			return bitArray;
		}

		private bool CheckBloomFilter(BitArray bloom, int[] input)
		{
			foreach (var item in input)
			{
				if(!bloom[item]){
					return false;
				}
			}
			return true;
		}
	}
}
