using System;
using System.Collections;

namespace BloomFilter
{
	public class BloomFilter
	{
		private const int bloomSize = 1234567;
		public BitArray bitArray = new BitArray(bloomSize, false); 

		public BloomFilter()
		{

		}

		public BloomFilter(string word)
		{
			SetValueInBloomFilter(word);
		}

		public int CalculateHash(string input)
		{
			//Math.Absolute always returns positive number
			//I used modulus to keep the range low (otherwise it was returning ints > 1billion)
			return Math.Abs(input.GetHashCode()) % bloomSize;
		}

		public void SetValueInBloomFilter(string word)
		{
			var hash = CalculateHash(word);
			bitArray[hash] = true;
		}

		public bool SearchValueInBloomFilter(string word)
		{
			var hash = CalculateHash(word);

			if (bitArray[hash] != true)
			{
				return false;
			}
			return true;
		}
	}
}
