using System.Text;

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

            long result = 1;
            foreach (var game in games)
            {
                result *= WaysOfWinning(game);
            }

            Console.WriteLine(result);
        }

        private static long WaysOfWinning(Game game)
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
            string[] rows = input.Split('\n');
            string[] times = rows[0].Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            string[] distances = rows[1].Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            var sbTimes = new StringBuilder();
            foreach (string s in times)
            {
                sbTimes.Append(s);
            }
            long time = long.Parse(sbTimes.ToString().Trim());

            var sbDistance = new StringBuilder();
            foreach (string s in distances)
            {
                sbDistance.Append(s);
            }

            long distance = long.Parse(sbDistance.ToString().Trim());


            var game = new Game() { Time = time, Distance = distance};
            Console.WriteLine(WaysOfWinning2(game));

        }

        private static long WaysOfWinning2(Game game)
        {
            // x * (totalTime - x) > record + 1
            long totalTime = game.Time;
            long record = game.Distance;

            long d = totalTime * totalTime - 4 * record;
            long x1 = (long)Math.Floor((double)(totalTime + (long)Math.Sqrt(d))/2);
            long x2 = (long)Math.Ceiling((double)(totalTime - (long)Math.Sqrt(d)) / 2);

            return x1 - x2 + 1;
        }

    }


    public class Game
    {
        public long Time { get; set; }

        public long Distance { get; set; }
    }

}