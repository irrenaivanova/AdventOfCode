namespace AdventOfCode2023
{
    public class Day07
    {
        public static void Task01(string[] input)
        {
            List<Hand> hands = new List<Hand>();
            foreach (var line in input)
            {
                string[] parts = line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                hands.Add(new Hand(parts[0], int.Parse(parts[1])));
            }

            hands = hands.OrderBy(x => x).ToList();
            long result = hands.Select((x, i) => x.Bid * (i + 1)).Sum();
            Console.WriteLine(result);

        }

        public static void Task02(string[] input)
        {
            throw new NotImplementedException();
        }
    }

    public class Hand : IComparable<Hand>
    {
        public Hand(string cards, int bid)
        {
            this.Cards = cards;
            this.Bid = bid;
        }

        public string Cards { get; set; }

        public int Bid { get; set; }

        public int Strength
        {
            get
            {
                var rankCounts = this.Cards.GroupBy(c => c).Select(g => g.Count()).OrderByDescending(x => x).ToList();
                if (rankCounts[0] == 5)
                {
                    return 7;
                }

                if (rankCounts[0] == 4)
                {
                    return 6;
                }

                if (rankCounts[0] == 3 && rankCounts[1] == 2)
                {
                    return 5;
                }

                if (rankCounts[0] == 3)
                {
                    return 4;
                }

                if (rankCounts[0] == 2 && rankCounts[1] == 2)
                {
                    return 3;
                }

                if (rankCounts[0] == 2)
                {
                    return 2;
                }

                return 1;
            }
        }

        public int[] StrengthOfEachCard
        {
            get
            {
                int[] strength = new int[this.Cards.Length];
                for (int i = 0; i < this.Cards.Length; i++)
                {
                    if (char.IsDigit(this.Cards[i]))
                    {
                        strength[i] = (int)char.GetNumericValue(this.Cards[i]);
                    }

                    if (this.Cards[i] == 'T')
                    {
                        strength[i] = 10;
                    }

                    if (this.Cards[i] == 'J')
                    {
                        strength[i] = 11;
                    }

                    if (this.Cards[i] == 'Q')
                    {
                        strength[i] = 12;
                    }

                    if (this.Cards[i] == 'K')
                    {
                        strength[i] = 13;
                    }

                    if (this.Cards[i] == 'A')
                    {
                        strength[i] = 14;
                    }
                }

                return strength;
            }
        }

        public int CompareTo(Hand other)
        {
            if (this.Strength > other.Strength)
            {
                return 1;
            }

            if (this.Strength < other.Strength)
            {
                return -1;
            }

            for (int i = 0; i < Math.Min(this.StrengthOfEachCard.Length, other.StrengthOfEachCard.Length); i++)
            {
                if (this.StrengthOfEachCard[i] > other.StrengthOfEachCard[i])
                {
                    return 1;
                }

                if (this.StrengthOfEachCard[i] < other.StrengthOfEachCard[i])
                {
                    return -1;
                }
            }

            return 0;
        }
    }
}
