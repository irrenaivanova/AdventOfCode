namespace AdventOfCode2023
{
    public class Day04
    {
        public static void Task01(string input)
        {
            int sum = 0;
            string[] rows = input.Split("\r\n");
            foreach (var row in rows)
            {
                sum += Points(row);
            }

            Console.WriteLine(sum);
        }

        private static int Points(string row)
        {
            string[] parts = row.Split(new char[] { ':', '|' }, StringSplitOptions.TrimEntries);
            HashSet<int> win = parts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();
            HashSet<int> cards = parts[2].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();
            int winning = 0;
            foreach (var card in cards)
            {
                if (win.Contains(card))
                {
                    winning++;
                }
            }

            if (winning == 0)
            {
                return 0;
            }

            return (int)Math.Pow(2, winning-1);
        }
            public static void Task02(string input)
        {
            throw new NotImplementedException();
        }
    }
}