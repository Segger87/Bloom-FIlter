using System.Net;

namespace BloomFilter
{
	public class WordDownloader
	{
		private string _wordsDownloaded { get; set; }
		public string[] Words { get; set; }

		public WordDownloader()
		{
			DownloadWordsFromSource();
			SplitWordsIntoArray();
		}

		private void DownloadWordsFromSource()
		{
			using (var webClient = new WebClient())
			{
				_wordsDownloaded = (webClient.DownloadString(@"http://codekata.com/data/wordlist.txt"));
			}
		}

		private void SplitWordsIntoArray()
		{
			Words = _wordsDownloaded.Split('\n');
		}
	}
}
