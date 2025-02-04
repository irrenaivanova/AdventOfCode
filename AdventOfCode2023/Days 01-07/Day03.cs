namespace AdventOfCode2023
{
    public class Day03
    {
        public static void Task01(string input)
        {
            string[] rows = input.Split("\r\n");
            char[,] matrix = ReadTheMatrix(rows);
            int sum = 0;
            for (int i = 0; i < rows.Length; i++)
            {
                string row = rows[i];
                string number = string.Empty;
                int startIndex = -1;
                bool startNumber = false;
                for (int j = 0; j < row.Length; j++)
                {
                    if (char.IsDigit(row[j]))
                    {
                        if (!startNumber)
                        {
                            startIndex = j;
                            startNumber = true;
                        }

                        number += ((int)char.GetNumericValue(row[j])).ToString();
                        if (j == row.Length - 1)
                        {
                            sum += TheNumberSum(number, startIndex, i, matrix);
                            startNumber = false;
                            number = string.Empty;
                        }
                    }
                    else
                    {
                        if (!startNumber)
                        {
                            continue;
                        }
                        else
                        {
                            sum += TheNumberSum(number, startIndex, i, matrix);
                            startNumber = false;
                            number = string.Empty;
                        }
                    }
                }
            }

            Console.WriteLine(sum);
        }

        private static int TheNumberSum(string numberString, int startIndex, int row, char[,] matrix)
        {
            int number = int.Parse(numberString);
            int startX = row - 1 < 0 ? 0 : row - 1;
            int startY = startIndex - 1 < 0 ? 0 : startIndex - 1;
            int endX = row + 1 > matrix.GetLength(0) - 1 ? matrix.GetLength(0) - 1 : row + 1;
            int endY = startIndex + numberString.Length > matrix.GetLength(1) - 1 ? matrix.GetLength(1) - 1 : startIndex + numberString.Length;

            for (int i = startX; i <= endX; i++)
            {
                for (int j = startY; j <= endY; j++)
                {
                    if (!char.IsDigit(matrix[i, j]) && matrix[i, j] != '.')
                    {
                        return number;
                    }
                }
            }

            return 0;
        }

        public static void Task02(string input)
        {
            Dictionary<(int, int), List<string>> stars = new Dictionary<(int, int), List<string>>();
            string[] rows = input.Split("\r\n");
            char[,] matrix = ReadTheMatrix(rows);

            for (int i = 0; i < rows.Length; i++)
            {
                string row = rows[i];
                string number = string.Empty;
                int startIndex = -1;
                bool startNumber = false;
                for (int j = 0; j < row.Length; j++)
                {
                    if (char.IsDigit(row[j]))
                    {
                        if (!startNumber)
                        {
                            startIndex = j;
                            startNumber = true;
                        }

                        number += ((int)char.GetNumericValue(row[j])).ToString();
                        if (j == row.Length - 1)
                        {
                            List<int[]> starsCoord = TheCoordinatesOfStar(number, startIndex, i, matrix);
                            foreach (var coord in starsCoord)
                            {
                                var newCoord = (coord[0], coord[1]);
                                if (!stars.ContainsKey(newCoord))
                                {
                                    stars.Add(newCoord, new List<string>());
                                }

                                stars[newCoord].Add(number);
                            }

                            startNumber = false;
                            number = string.Empty;
                        }
                    }
                    else
                    {
                        if (!startNumber)
                        {
                            continue;
                        }
                        else
                        {
                            List<int[]> starsCoord = TheCoordinatesOfStar(number, startIndex, i, matrix);
                            foreach (var coord in starsCoord)
                            {
                                var newCoord = (coord[0], coord[1]);
                                if (!stars.ContainsKey(newCoord))
                                {
                                    stars.Add(newCoord, new List<string>());
                                }

                                stars[newCoord].Add(number);
                            }

                            startNumber = false;
                            number = string.Empty;
                        }
                    }
                }
            }

            int sum = 0;
            foreach (var star in stars.Where(x => x.Value.Count == 2))
            {
                sum += int.Parse(star.Value[0]) * int.Parse(star.Value[1]);
            }

            Console.WriteLine(sum);
        }

        private static List<int[]> TheCoordinatesOfStar(string numberString, int startIndex, int row, char[,] matrix)
        {
            List<int[]> list = new List<int[]>();
            int number = int.Parse(numberString);
            int startX = row - 1 < 0 ? 0 : row - 1;
            int startY = startIndex - 1 < 0 ? 0 : startIndex - 1;
            int endX = row + 1 > matrix.GetLength(0) - 1 ? matrix.GetLength(0) - 1 : row + 1;
            int endY = startIndex + numberString.Length > matrix.GetLength(1) - 1 ? matrix.GetLength(1) - 1 : startIndex + numberString.Length;

            for (int i = startX; i <= endX; i++)
            {
                for (int j = startY; j <= endY; j++)
                {
                    if (matrix[i, j] == '*')
                    {
                        list.Add(new int[] { i, j });
                    }
                }
            }

            return list;
        }

        private static char[,] ReadTheMatrix(string[] rows)
        {
            char[,] matrix = new char[rows.Length, rows[0].Length];
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    matrix[i, j] = rows[i][j];
                }
            }

            return matrix;
        }
    }
}