namespace AdventOfCode2023
{
    public class Day05
    {
        public static void Task01(string input)
        {
            List<decimal> seeds = new List<decimal>();
            List<decimal> locations = new List<decimal>();
            List<int> rowsNumber = new List<int>();
            List<List<decimal[]>> maps = new List<List<decimal[]>>();
            string[] rows = input.Split("\r\n");
            for (int k = 0; k < rows.Length; k++)
            {
                if (string.IsNullOrWhiteSpace(rows[k]))
                {
                    continue;
                }

                if (rows[k].StartsWith("seeds:"))
                {
                    string[] args = rows[k].Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 1; j < args.Length; j++)
                    {
                        seeds.Add(decimal.Parse(args[j]));
                    }
                    continue;
                }

                char startSymbol = rows[k][0];
                if (char.IsLetter(startSymbol))
                {
                    rowsNumber.Add(k + 1);
                }
            }

            for (int i = 0; i < rowsNumber.Count; i++)
            {
                List<decimal[]> map = new List<decimal[]>();
                int startRow = rowsNumber[i];
                int endRow = 0;
                if (i == rowsNumber.Count - 1)
                {
                    endRow = rows.Length - 1;
                }
                else
                {
                    endRow = rowsNumber[i + 1] - 3;
                }

                for (int j = startRow; j <= endRow; j++)
                {
                    decimal[] numbers = rows[j].Split(" ", StringSplitOptions.TrimEntries).Select(decimal.Parse).ToArray();
                    decimal range = numbers[2];
                    map.Add(new decimal[] { numbers[0], numbers[1], numbers[2] });
                }

                maps.Add(map);
            }

            foreach (var seed in seeds)
            {
                decimal key = seed;
                decimal value = 0;
                for (int i = 0; i < maps.Count; i++)
                {
                    var map = maps[i];
                    bool isFound = false;
                    for (int j = 0; j < map.Count; j++)
                    {
                        decimal startValue = map[j][0];
                        decimal start = map[j][1];
                        decimal range = map[j][2];
                        if (key >= start && key < start + range)
                        {
                            decimal distance = key - start;
                            value = startValue + distance;
                            isFound = true;
                            break;
                        }

                        if (isFound)
                        {
                            break;
                        }
                    }

                    if (!isFound)
                    {
                        value = key;
                    }

                    key = value;
                }

                locations.Add(value);
            }

            Console.WriteLine(locations.Min());
        }

        public static void Task02(string input)
        {
            throw new NotImplementedException();
        }
    }
}