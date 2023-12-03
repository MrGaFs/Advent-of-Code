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
				int l = 0, r = line.Length - 1;
				int leftNumber = 0, rightNumber = 0;
				while (l != -1 || r != -1)
				{
					if (l != -1 && isNumber(line[l]))
					{
						leftNumber = line[l] - '0';
						l = -1;
					}
					if (r != -1 && isNumber(line[r]))
					{
						rightNumber = line[r] - '0';
						r = -1;
					}
					if (l != -1) ++l;
					if (r != -1) --r;
				}
				sum += leftNumber * 10 + rightNumber;
			}
			Console.WriteLine(sum);
			bool isNumber(char letter)
			{
				return letter >= '0' && letter <= '9';
			}
		}
	}
}