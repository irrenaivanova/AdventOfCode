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
    index = i + 1;
    break;
}

for (int i = index; i < input.Length; i++)
{
    string[] maze = input[i].Split(new char[] { '=', '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
    path.Add(maze[0], new string[] { maze[1], maze[2] });
}

int count = 0;
string[] nodes = path.Where(x => x.Key[2] == 'A').Select(x => x.Key).ToArray();
while (true)
{
    var instruction = instructions.Dequeue();
    
    for (int i = 0; i < nodes.Length; i++)
    {
        if (instruction == 'L')
        {
            nodes[i] = path[nodes[i]][0];
        }

        if (instruction == 'R')
        {
            nodes[i] = path[nodes[i]][1];
        }
    }

    count++;
    instructions.Enqueue(instruction);
    if (nodes.All(x => x[2] == 'Z'))
    {
        break;
    }
}
Console.WriteLine(count);