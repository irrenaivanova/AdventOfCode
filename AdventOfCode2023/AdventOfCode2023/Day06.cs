namespace AdventOfCode2023
{
    public class Day06
    {
        public static void Task01(string input)
        {
            List<Game> games = new List<Game>();
            string[] rows = input.Split('\n');
            int[] times = rows[0].Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();
            int[] distances = rows[1].Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToArray();
            for (int i = 0; i < times.Length; i++)
            {
                games.Add(new Game() { Time = times[i], Distance = distances[i] });
            }

            int result = 1;
            foreach (var game in games)
            {
                result *= WaysOfWinning(game);
            }

            Console.WriteLine(result);
        }

        private static int WaysOfWinning(Game game)
        {
            int result = 0;
            for (int i = 1; i < game.Time; i++)
            {
                if ((game.Time - i) * i > game.Distance)
                {
                    result++;
                }
            }

            return result;
        }

        public static void Task02(string input)
        {
            throw new NotImplementedException();
        }
    }

    public class Game
    {
        public int Time { get; set; }

        public int Distance { get; set; }
    }

}