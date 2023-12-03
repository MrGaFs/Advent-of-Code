using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

namespace MonkeyDLuffy
{
	internal class MonkeyDLuffy
	{
		public static void Main(string[] args)
		{
			var fileStream = new FileStream(@"./in.txt", FileMode.Open, FileAccess.Read);
			using var streamReader = new StreamReader(fileStream, Encoding.UTF8);
			string line;
			long sum = 0;
			while ((line = streamReader.ReadLine()) != null)
			{
				int num = new StringNumbers(line).Number;
				Console.WriteLine(num);
				sum += num;
			}
			Console.WriteLine(sum);
		}
	}
	class StringNumbers(string Word)
	{
		public string Word = Word;
		readonly List<(string, int)> NumbersList = [
		("one", 1),
	("1", 1),
	("two", 2),
	("2", 2),
	("three", 3),
	("3", 3),
	("four", 4),
	("4", 4),
	("five", 5),
	("5", 5),
	("six", 6),
	("6", 6),
	("seven", 7),
	("7", 7),
	("eight", 8),
	("8", 8),
	("nine", 9),
	("9", 9)
			];
		int firstNumber()
		{
			int ret = 0;
			int minPos = int.MaxValue;
			foreach ((string, int) entry in NumbersList)
			{
				int pos = Word.IndexOf(entry.Item1);
				if (pos != -1 && pos < minPos)
				{
					minPos = pos;
					ret = entry.Item2;
				}
			}
			return ret;
		}
		int lastNumber()
		{
			int ret = 0;
			int maxPos = int.MinValue;
			foreach ((string, int) entry in NumbersList)
			{
				int pos = Word.LastIndexOf(entry.Item1);
				if (pos != -1 && pos > maxPos)
				{
					maxPos = pos;
					ret = entry.Item2;
				}
			}
			return ret;
		}
		public int Number { get => firstNumber() * 10 + lastNumber(); }
	}
}
