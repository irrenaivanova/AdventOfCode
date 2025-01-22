namespace AdventOfCode2023
{
    public class Day02
    {
        public static void Task01(string input)
        {
            int sum = 0;
            string[] rows = input.Split("\r\n");
            foreach (var row in rows)
            {
                sum += GetTheIdOfPossibleRows(row);
            }

            Console.WriteLine(sum);
        }

        public static void Task02(string input)
        {
            int sum = 0;
            string[] rows = input.Split("\r\n");
            foreach (var row in rows)
            {
                sum += GetThePowerOfTheRow(row);
            }

            Console.WriteLine(sum);
        }

        private static int GetThePowerOfTheRow(string row)
        {
            string[] input = row.Split(": ");
            string[] sets = input[1].Split("; ");
            Dictionary<string, int> bag = new Dictionary<string, int>
            {
                { "red", 0 },
                { "green", 0 },
                { "blue", 0 },
            };
            for (int i = 0; i < sets.Length; i++)
            {
                string[] byColour = sets[i].Split(", ");
                foreach (var pair in byColour)
                {
                    string[] numberColour = pair.Split(" ");
                    int number = int.Parse(numberColour[0]);
                    string colour = numberColour[1];
                    if (bag[colour] < number)
                    {
                        bag[colour] = number;
                    }
                }
            }

            return bag["red"] * bag["green"] * bag["blue"];
        }

        private static int GetTheIdOfPossibleRows(string row)
        {
            Dictionary<string, int> bag = new Dictionary<string, int>
            {
                { "red", 12 },
                { "green", 13 },
                { "blue", 14 },
            };
            bool isPossible = true;
            string[] input = row.Split(": ");
            string[] sets = input[1].Split("; ");
            for (int i = 0; i < sets.Length; i++)
            {
                string[] byColour = sets[i].Split(", ");
                foreach (var pair in byColour)
                {
                    string[] numberColour = pair.Split(" ");
                    int number = int.Parse(numberColour[0]);
                    string colour = numberColour[1];
                    if (bag[colour] < number)
                    {
                        isPossible = false;
                        break;
                    }
                }

                if (!isPossible)
                {
                    break;
                }
            }

            if (!isPossible)
            {
                return 0;
            }

            return int.Parse(input[0].Split(" ").ToArray()[1]);
        }
    }
}