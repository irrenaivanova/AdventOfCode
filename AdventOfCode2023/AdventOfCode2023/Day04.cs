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
                int winning = WiningCards(row);
                sum += (int)Math.Pow(2, winning - 1);
            }

            Console.WriteLine(sum);
        }

        public static void Task02(string input)
        {
            Dictionary<int, int> cardsCount = new Dictionary<int, int>();
            string[] rows = input.Split("\r\n");
            for (int i = 0; i < rows.Length; i++)
            {
                if (!cardsCount.ContainsKey(i + 1))
                {
                    cardsCount.Add(i + 1, 1);
                }
                else
                {
                    cardsCount[i + 1]++;
                }

                int cardsNumber = cardsCount[i + 1];
                int winning = WiningCards(rows[i]);
                for (int j = 1; j <= winning; j++)
                {
                    if (!cardsCount.ContainsKey(i + 1 + j))
                    {
                        cardsCount.Add(i + 1 + j, 0);
                    }
                    cardsCount[i + j + 1] += cardsNumber;
                }

            }

            Console.WriteLine(cardsCount.Values.Sum());
        }


        private static int WiningCards(string row)
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

            return winning;
        }
    }
}