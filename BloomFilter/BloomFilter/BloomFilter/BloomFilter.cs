﻿using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace BloomFilter
{
	public class BloomFilter
	{
		private const int _bloomSize = 1234567;
		private BitArray _bitArray = new BitArray(_bloomSize, false); 

		public BloomFilter()
		{

		}

		public BloomFilter(string word)
		{
			SetValueInBloomFilter(word);
		}

		public int CalculateHash(string input)
		{
			//I used modulus to keep the range low (otherwise it was returning ints > 1billion)
			return Math.Abs(input.GetHashCode()) % _bloomSize;
		}

		public int CalculateSecondHash(string word)
		{
			MD5 md5 = MD5.Create();
			byte[] inputBytes = Encoding.ASCII.GetBytes(word);
			byte[] hash = md5.ComputeHash(inputBytes);
			int totalHashValue = 0;

			for (int i = 0; i < hash.Length; i++)
			{
				var hashInt = Convert.ToInt16(hash[i]);
				totalHashValue += hashInt;
			}

			return totalHashValue;
		}

		public int CalculateThirdHash(string word)
		{
			int charValues = 0;

			foreach (char letter in word)
			{
				charValues += letter;
			}

			return charValues * 6;
		}

		public void SetValueInBloomFilter(string word)
		{
			var hashValue = CalculateHash(word);
			var secondHashValue = CalculateSecondHash(word);
			var thirdHashValue = CalculateThirdHash(word);

			_bitArray[hashValue] = true;
			_bitArray[secondHashValue] = true;
			_bitArray[thirdHashValue] = true;
		}

		public bool SearchValueInBloomFilter(string word)
		{
			var hashValue = CalculateHash(word);
			var secondHashValue = CalculateSecondHash(word);
			var thirdHashValue = CalculateThirdHash(word);

			if (_bitArray[hashValue] && _bitArray[secondHashValue] && _bitArray[thirdHashValue])
			{
				return true;
			}

			return false;
		}
	}
}
