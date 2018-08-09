using System;
using System.Security.Cryptography;
using System.Text;


namespace BloomFilter
{
	class Program
	{
		static void Main(string[] args)
		{
			var program = new Program();
			string hash = program.CalculateMD5Hash("Sam");
			Console.Write(hash);
			Console.ReadLine();
		}


		private string CalculateMD5Hash(string input)
		{
			MD5 md5 = MD5.Create();

			byte[] inputBytes = Encoding.ASCII.GetBytes(input);
			byte[] hash = md5.ComputeHash(inputBytes);

			StringBuilder stringBuilder = new StringBuilder();

			for (int i = 0; i < hash.Length; i++)
			{
				stringBuilder.Append(hash[i].ToString("x2"));
			}

			return stringBuilder.ToString();
		}
	}
}
