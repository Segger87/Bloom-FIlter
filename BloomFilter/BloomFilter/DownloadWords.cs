using System.Net;

namespace BloomFilter
{
	public class DownloadWords
	{
		private string _wordsDownloaded { get; set; }
		public string[] Words { get; set; }

		public DownloadWords()
		{
			using (var webClient = new WebClient())
			{
				_wordsDownloaded = (webClient.DownloadString(@"http://codekata.com/data/wordlist.txt"));
			}

			SplitWordsIntoArray();
		}

		private void SplitWordsIntoArray()
		{
			Words = _wordsDownloaded.Split('\n');
		}
	}
}
