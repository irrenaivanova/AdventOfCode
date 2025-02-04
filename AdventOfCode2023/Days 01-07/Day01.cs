namespace AdventOfCode2023
{
    public class Day01
    {
        public static void Task01(string input)
        {
            int sum = 0;
            string[] rows = input.Split('\n');
            foreach (var row in rows)
            {
                if (row == null)
                {
                    continue;
                }

                sum += GetTheNumber(row);
            }

            Console.WriteLine(sum);
        }

        public static void Task02(string input)
        {
            int sum = 0;
            string[] rows = input.Split('\n');
            foreach (var row in rows)
            {
                if (row == null)
                {
                    continue;
                }

                sum += GetTheNumberFromTheString(row);
            }

            Console.WriteLine(sum);
        }

        private static int GetTheNumberFromTheString(string row)
        {
            Dictionary<string, int> validNumbers = new Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 },
            };

            int firstDigit = 0;
            int secondDigit = 0;

            int minIndexDict = int.MaxValue;
            int maxIndexDict = int.MinValue;
            string stringNumberF = string.Empty;
            string stringNumberL = string.Empty;
            int minIndexNumb = -1;
            int maxIndexNumb = -1;

            foreach (var number in validNumbers.Keys)
            {
                int indexFirst = row.IndexOf(number);
                int indexSecond = row.LastIndexOf(number);
                if (indexFirst != -1 && indexFirst < minIndexDict)
                {
                    minIndexDict = indexFirst;
                    stringNumberF = number;
                }

                if (indexSecond != -1 && indexSecond > maxIndexDict)
                {
                    maxIndexDict = indexSecond;
                    stringNumberL = number;
                }
            }

            for (int i = 0; i < row.Length; i++)
            {
                if (char.IsDigit(row[i]))
                {
                    minIndexNumb = i;
                    break;
                }
            }

            if (minIndexNumb != -1 && minIndexNumb < minIndexDict)
            {
                firstDigit = (int)row[minIndexNumb] - 48;
            }
            else
            {
                firstDigit = validNumbers[stringNumberF];
            }

            for (int i = row.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(row[i]))
                {
                    maxIndexNumb = i;
                    break;
                }
            }

            if (maxIndexNumb != -1 && maxIndexNumb > maxIndexDict)
            {
                secondDigit = (int)row[maxIndexNumb] - 48;
            }
            else
            {
                secondDigit = validNumbers[stringNumberL];
            }

            return (firstDigit * 10) + secondDigit;
        }

        private static int GetTheNumber(string row)
        {
            int firstDigit = -1;
            int secondDigit = -1;
            for (int i = 0; i < row.Length; i++)
            {
                if (char.IsDigit(row[i]))
                {
                    firstDigit = (int)row[i] - 48;
                    break;
                }
            }

            for (int i = row.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(row[i]))
                {
                    secondDigit = (int)row[i] - 48;
                    break;
                }
            }

            if (firstDigit == -1)
            {
                return 0;
            }

            return (firstDigit * 10) + secondDigit;
        }
    }
}
