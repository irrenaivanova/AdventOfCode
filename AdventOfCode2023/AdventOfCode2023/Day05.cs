namespace AdventOfCode2023
{
    public class Day05
    {
        public static void Task01(string input)
        {
            TaskCommon(input, ProcessSeedsTask01);
        }

        public static void Task02(string input)
        {
            TaskCommon(input, ProcessSeedsTask02);
        }

        private static void TaskCommon(string input, Action<string, List<List<long[]>>> seedProcessor)
        {
            List<int> rowsNumber = new List<int>();
            List<List<long[]>> maps = new List<List<long[]>>();
            string[] rows = input.Split("\r\n");

            for (int k = 0; k < rows.Length; k++)
            {
                if (string.IsNullOrWhiteSpace(rows[k]))
                {
                    continue;
                }

                char startSymbol = rows[k][0];
                if (char.IsLetter(startSymbol) && !rows[k].StartsWith("seeds: "))
                {
                    rowsNumber.Add(k + 1);
                }
            }

            for (int i = 0; i < rowsNumber.Count; i++)
            {
                List<long[]> map = new List<long[]>();
                int startRow = rowsNumber[i];
                int endRow = (i == rowsNumber.Count - 1) ? rows.Length - 1 : rowsNumber[i + 1] - 3;

                for (int j = startRow; j <= endRow; j++)
                {
                    long[] numbers = rows[j].Split(" ", StringSplitOptions.TrimEntries).Select(long.Parse).ToArray();
                    map.Add(new long[] { numbers[0], numbers[1], numbers[2] });
                }

                maps.Add(map);
            }

            seedProcessor(input, maps);
        }

        private static void ProcessSeedsTask01(string input, List<List<long[]>> maps)
        {
            decimal minLocation = decimal.MaxValue;

            string seedsRow = input.Split("\r\n").FirstOrDefault(row => row.StartsWith("seeds:"));
            if (seedsRow != null)
            {
                string[] args = seedsRow.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 1; j < args.Length; j++)
                {
                    long seed = long.Parse(args[j]);
                    long finalLocation = ProcessSingleSeed(seed, maps);
                    minLocation = Math.Min(minLocation, finalLocation);
                }
            }

            Console.WriteLine(minLocation);
        }

        private static void ProcessSeedsTask02(string input, List<List<long[]>> maps)
        {
            decimal minLocation = decimal.MaxValue;

            string seedsRow = input.Split("\r\n").FirstOrDefault(row => row.StartsWith("seeds:"));
            if (seedsRow != null)
            {
                string[] args = seedsRow.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 1; j < args.Length; j += 2)
                {
                    long start = long.Parse(args[j]);
                    long range = long.Parse(args[j + 1]);

                    for (int i = 0; i < range; i++)
                    {
                        long seed = start + i;
                        long finalLocation = ProcessSingleSeed(seed, maps);
                        minLocation = Math.Min(minLocation, finalLocation);
                    }
                }
            }

            Console.WriteLine(minLocation);
        }

        private static long ProcessSingleSeed(long seed, List<List<long[]>> maps)
        {
            long key = seed;
            long value = 0;

            for (int i = 0; i < maps.Count; i++)
            {
                var map = maps[i];
                bool isFound = false;

                for (int j = 0; j < map.Count; j++)
                {
                    long startValue = map[j][0];
                    long start = map[j][1];
                    long range = map[j][2];

                    if (key >= start && key < start + range)
                    {
                        long distance = key - start;
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
            
            return value;
        }
    }
}