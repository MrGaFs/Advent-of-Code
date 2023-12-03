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
				line = line[4..];
				string[] input = line.Split(": ");
				line = input[1];
				_ = int.TryParse(input[0], out int id);
				sum += IsGame(line) ? id : 0;
			}
			Console.WriteLine(sum);

			static bool IsGame(string Game)
			{
				string[] subGames = [.. Game.Split("; ")];
				foreach (string subGame in subGames)
				{
					if (!IsSubGame(subGame))
						return false;
				}
				return true;
			}

			static bool IsSubGame(string SubGameString)
			{
				Dictionary<string, int> Colors = new(){
				{"red", 12},
				{"green", 13},
				{"blue", 14},
			};
				string[] subGame = SubGameString.Split(", ");
				foreach (string pick in subGame)
				{
					string[] tmp = pick.Split();
					string color = tmp[1];
					_ = int.TryParse(tmp[0], out int numbersOfBalls);
					if (numbersOfBalls > Colors[color])
						return false;
				}
				return true;
			}
		}
	}
}
