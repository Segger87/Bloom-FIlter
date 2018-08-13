using System;

namespace BloomFilter
{
	class Program
	{
		static void Main(string[] args)
		{
			new Program().ExecuteBloomFilter();
		}

		private void ExecuteBloomFilter()
		{
			Console.WriteLine("Downloading Words...");
			var listOfWords = new WordDownloader();
			var bloomFilter = new BloomFilter();
			Console.WriteLine("Searching Words...");

			foreach (var word in listOfWords.Words)
			{
				bloomFilter.SetValueInBloomFilter(word);
			}

			RandomSearchesExpectedToBeFalse(bloomFilter);
			RandomSearchesExpectedToBeTrue(bloomFilter);
			Console.ReadLine();
		}

		private void RandomSearchesExpectedToBeFalse(BloomFilter bloomFilter)
		{
			string expectedToBeFalse = "BeastModeBarry";
			string expectedToBeFalse2 = "2";
			string expectedToBeFalse3 = "socagers1";

			var result1 = bloomFilter.SearchValueInBloomFilter(expectedToBeFalse);
			var result2 = bloomFilter.SearchValueInBloomFilter(expectedToBeFalse2);
			var result3 = bloomFilter.SearchValueInBloomFilter(expectedToBeFalse3);

			Console.WriteLine($"The Word {expectedToBeFalse} which is expected to be False returns {result1}");
			Console.WriteLine($"The Word {expectedToBeFalse2} which is expected to be False returns {result2}");
			Console.WriteLine($"The Word {expectedToBeFalse3} which is expected to be False returns {result3}");
		}

		private void RandomSearchesExpectedToBeTrue(BloomFilter bloomFilter)
		{
			string expectedToBeTrue = "ADP's";
			string expectedToBeTrue2 = "jambokking";
			string expectedToBeTrue3 = "socagers";

			var result1 = bloomFilter.SearchValueInBloomFilter(expectedToBeTrue);
			var result2 = bloomFilter.SearchValueInBloomFilter(expectedToBeTrue2);
			var result3 = bloomFilter.SearchValueInBloomFilter(expectedToBeTrue3);

			Console.WriteLine($"The Word {expectedToBeTrue} which is expected to be True returns {result1}");
			Console.WriteLine($"The Word {expectedToBeTrue2} which is expected to be True returns {result2}");
			Console.WriteLine($"The Word {expectedToBeTrue3} which is expected to be True returns {result3}");
		}
	}
}
