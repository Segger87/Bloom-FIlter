using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BloomFilter.Tests
{
	[TestClass]
	public class BloomFilterUnitTests
	{
		[TestMethod]
		public void BloomFilterSearchMethod_MatchesExpectedWord_IsTrue()
		{
			//Arrange
			const string expectedWord1 = "Abderian's";
			const string expectedWord2 = "telangiectasias";
			const string expectedWord3 = "événements";
			const string expectedWord4 = "maw's";
			const string expectedWord5 = "liquidizer's";

			var listOfWords = new DownloadWords();
			var bloomFilter = new BloomFilter();

			//Act
			foreach (var word in listOfWords.Words)
			{
				bloomFilter.SetValueInBloomFilter(word);
			}

			//Assert
			Assert.IsTrue(bloomFilter.SearchValueInBloomFilter(expectedWord1));
			Assert.IsTrue(bloomFilter.SearchValueInBloomFilter(expectedWord2));
			Assert.IsTrue(bloomFilter.SearchValueInBloomFilter(expectedWord3));
			Assert.IsTrue(bloomFilter.SearchValueInBloomFilter(expectedWord4));
			Assert.IsTrue(bloomFilter.SearchValueInBloomFilter(expectedWord5));
		}

		[TestMethod]
		public void BloomFilterSearchMethod_DoesntFindExpectedWord_IsUsuallyFalse()
		{
			//I use the term usually false as there is always a change of a false positive
			//Arrange
			const string expectedWord1 = "BeastModeBarry";
			const string expectedWord2 = "BarryModeBeast";
			const string expectedWord3 = "ModeBeastBarry";
			const string expectedWord4 = "ModeBarryBeast";
			const string expectedWord5 = "BeastBarryMode";

			var listOfWords = new DownloadWords();
			var bloomFilter = new BloomFilter();

			//Act
			foreach (var word in listOfWords.Words)
			{
				bloomFilter.SetValueInBloomFilter(word);
			}

			//Assert
			Assert.IsFalse(bloomFilter.SearchValueInBloomFilter(expectedWord1));
			Assert.IsFalse(bloomFilter.SearchValueInBloomFilter(expectedWord2));
			Assert.IsFalse(bloomFilter.SearchValueInBloomFilter(expectedWord3));
			Assert.IsFalse(bloomFilter.SearchValueInBloomFilter(expectedWord4));
			Assert.IsFalse(bloomFilter.SearchValueInBloomFilter(expectedWord5));
		}

		[TestMethod]
		public void ExpectedCalculateHashInteger_ReturnsANumberGreaterThan0_IsTrue()
		{
			//Arrange
			const string testWord = "abcdefg";
			const string testWord2 = "hijklmno";
			const string testWord3 = "pqrstuvwxyz";
			var bloomFilter = new BloomFilter();

			//Act
			var expectedHashCode = bloomFilter.CalculateHash(testWord);
			var expectedHashCode2 = bloomFilter.CalculateHash(testWord2);
			var expectedHashCode3 = bloomFilter.CalculateHash(testWord3);

			//Assert
			Assert.IsTrue(expectedHashCode > 0);
			Assert.IsTrue(expectedHashCode2 > 0);
			Assert.IsTrue(expectedHashCode3 > 0);
		}

		[TestMethod]
		public void ExpectedCalculateSecondMD5Hash_ReturnsANumberGreaterThan0_IsTrue()
		{
			//Arrange
			const string testWord = "abcdefg";
			const string testWord2 = "hijklmno";
			const string testWord3 = "pqrstuvwxyz";
			var bloomFilter = new BloomFilter();

			//Act
			var expectedHashCode = bloomFilter.CalculateSecondHash(testWord);
			var expectedHashCode2 = bloomFilter.CalculateSecondHash(testWord2);
			var expectedHashCode3 = bloomFilter.CalculateSecondHash(testWord3);

			//Assert
			Assert.IsTrue(expectedHashCode > 0);
			Assert.IsTrue(expectedHashCode2 > 0);
			Assert.IsTrue(expectedHashCode3 > 0);
		}
	}
}
