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
				line = line.Split(": ")[1];
				sum += GameScore(line);
			}
			Console.WriteLine(sum);

			static long GameScore(string Game)
			{
				Dictionary<string, long> Colors = new(){
				{"red", 0},
				{"green", 0},
				{"blue", 0},
			};
				string[] subGames = [.. Game.Split("; ")];
				foreach (string subGame in subGames)
				{
					string[] subGamePicks = subGame.Split(", ");
					foreach (string pick in subGamePicks)
					{
						string[] tmp = pick.Split();
						string color = tmp[1];
						_ = long.TryParse(tmp[0], out long numbersOfBalls);
						if (numbersOfBalls > Colors[color])
							Colors[color] = Math.Max(Colors[color], numbersOfBalls);
					}
				}
				return Colors.Values.Aggregate((a, b) => a * b);
			}
		}
	}
}
