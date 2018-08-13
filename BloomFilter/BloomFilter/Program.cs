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
			var rand = new RandomWordPicker();

			foreach (var r in rand.RandomWordThatShouldBeFalse)
			{
				var result = bloomFilter.SearchValueInBloomFilter(r);
				Console.WriteLine($"The Word {r} which is expected to be False returns {result}");
			}
		}

		private void RandomSearchesExpectedToBeTrue(BloomFilter bloomFilter)
		{
			var rand = new RandomWordPicker();

			foreach (var r in rand.RandomWordThatShouldBeTrue)
			{
				var result = bloomFilter.SearchValueInBloomFilter(r);
				Console.WriteLine($"The Word {r} which is expected to be True returns {result}");
			}
		}
	}
}
