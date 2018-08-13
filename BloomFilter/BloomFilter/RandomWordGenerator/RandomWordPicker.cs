using System;
using System.Collections.Generic;

namespace BloomFilter
{
	public class RandomWordPicker
	{
		public List<string> RandomWordThatShouldBeFalse = new List<string>();
		public List<string> RandomWordThatShouldBeTrue = new List<string>();

		private string[] WordsNotInTheFilter =
		{
			"Sammmmmmmmmmmmm",
			"Barryyyyyyyy",
			"Garyyyyy",
			"Larryyyyyyyyy",
			"Harryyyyyyyy",
			"Carriesss",
			"Bobbbbbb",
			"FooBarBro",
			"Shaq Fu",
			"Fu Schnickens",
			"Hong Kong Fuey"
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
			"yodling"
		};

		public RandomWordPicker()
		{
			GenerateRandomNumber(WordsInTheFilter);
		}

		private void GenerateRandomNumber(string[] words)
		{
			var random = new Random();

			for (int i = 0; i < 10; i++)
			{
				var rndNum = random.Next(0, words.Length);
				ProduceARandomWordThatShouldBeFalse(rndNum);
				ProduceARandomWordThatShouldBeTrue(rndNum);
			}
		}

		private void ProduceARandomWordThatShouldBeFalse(int number)
		{
			var randomWord = WordsNotInTheFilter[number];
			RandomWordThatShouldBeFalse.Add(randomWord);
		}

		private void ProduceARandomWordThatShouldBeTrue(int number)
		{
			var randomWord = WordsInTheFilter[number];
			RandomWordThatShouldBeTrue.Add(randomWord);
		}
	}
}
