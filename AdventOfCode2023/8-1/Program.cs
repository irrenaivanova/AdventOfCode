string[] input = File.ReadAllLines("input.txt");
Queue<char> instructions = new Queue<char>();
Dictionary<string, string[]> path = new Dictionary<string, string[]>();

int index = 0;
for (int i = 0; i < input.Length; i++)
{
    if (!string.IsNullOrWhiteSpace(input[i]))
    {
        foreach (var c in input[i])
        {
            instructions.Enqueue(c);
        }
        continue;
    }
    index = i+1;
    break;
}

for (int i = index; i < input.Length; i++)
{
    string[] maze = input[i].Split(new char[] { '=', '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
    path.Add(maze[0],new string[] { maze[1], maze[2] });
}

string start = "AAA";

int count = 0;
while(true)
{
    var instruction = instructions.Dequeue();
    if (instruction == 'L')
    {
        start = path[start][0];
    }

    if (instruction == 'R')
    {
        start = path[start][1];
    }
    count++;
    instructions.Enqueue(instruction);
    if (start == "ZZZ")
    {
        break;
    }
}
Console.WriteLine(count);




