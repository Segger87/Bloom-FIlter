using System;
using System.Collections.Generic;

namespace BloomFilter
{
	public class RandomWordPicker
	{
		public List<string> RandomWordThatIsFalse = new List<string>();
		public List<string> RandomWordThatIsTrue = new List<string>();

		private string[] WordsNotInTheFilter =
		{
			"Sammmmmmmmmmmmm",
			"Barryyyyyyyy",
			"Garyyyyyy1",
			"Larryyyyyyyyy",
			"Harryyyyyyyy",
			"Carriesss",
			"Bobbbbbb",
			"FooBarBro",
			"Shaq Fu",
			"Fu Schnickens",
			"Hong Kong Fuey",
			"Shenmue"
		};

		private string[] WordsInTheFilter =
	{
			"AOL",
			"Absaraka's",
			"Serendip's",
			"polyzoic",
			"polyurethane",
			"factorabilities",
			"étrenness",
			"zanthoxyl",
			"yocked",
			"yocking",
			"yodling",
			"dynasty"
		};

		public RandomWordPicker()
		{
			RandomNumber(WordsNotInTheFilter);
		}

		private void RandomNumber(string[] words)
		{
			var random = new Random();

			for (int i = 0; i < 10; i++)
			{
				var rndNum = random.Next(0, words.Length);
				RandomWordThatShouldBeFalse(rndNum);
				RandomWordThatShouldBeTrue(rndNum);
			}
		}

		private void RandomWordThatShouldBeFalse(int number)
		{
			var randomWord = WordsNotInTheFilter[number];
			RandomWordThatIsFalse.Add(randomWord);
		}

		private void RandomWordThatShouldBeTrue(int number)
		{
			var randomWord = WordsInTheFilter[number];
			RandomWordThatIsTrue.Add(randomWord);
		}
	}
}
