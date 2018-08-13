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
			var randomWord = new RandomWordPicker();

			foreach (var random in randomWord.RandomWordThatShouldBeFalse)
			{
				var result = bloomFilter.SearchValueInBloomFilter(random);
				Console.WriteLine($"The Word {random} which is expected to be False returns {result}");
			}
		}

		private void RandomSearchesExpectedToBeTrue(BloomFilter bloomFilter)
		{
			var randomWord = new RandomWordPicker();

			foreach (var random in randomWord.RandomWordThatShouldBeTrue)
			{
				var result = bloomFilter.SearchValueInBloomFilter(random);
				Console.WriteLine($"The Word {random} which is expected to be True returns {result}");
			}
		}
	}
}
