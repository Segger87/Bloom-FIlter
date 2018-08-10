using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BloomFilter
{
	public class BloomFilter
	{
		public BitArray bitArray = new BitArray(1000, false); 

		public BloomFilter()
		{

		}

		public BloomFilter(string word)
		{
			var hash = CalculateMD5Hash(word);
			SetValuesInBloomFilter(bitArray, hash);
		}

		private int[] CalculateMD5Hash(string input)
		{
			MD5 md5 = MD5.Create();
			byte[] inputBytes = Encoding.ASCII.GetBytes(input);
			byte[] hash = md5.ComputeHash(inputBytes);
			int[] hashInts = new int[5];

			for (int i = 0; i < 5; i++)
			{
				var hashInt = Convert.ToInt16(hash[i]);
				hashInts[i] = hashInt;
			}

			return hashInts;
		}

		private BitArray SetValuesInBloomFilter(BitArray bitArray, int[] input)
		{
			foreach (var item in input)
			{
				bitArray[item] = true;
			}

			return bitArray;
		}

		public bool CheckBloomFilter(string word)
		{
			var hash = CalculateMD5Hash(word);

			foreach (var i in hash)
			{
				if (!bitArray[i])
				{
					return false;
				}
			}
			return true;
		}
	}
}
