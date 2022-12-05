string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

var data = File.ReadAllLines(path);

var stacks = new List<Stack<char>>();

for (int i = 0; i < 9; i++)
{
    stacks.Add(new Stack<char>());
}

for (int row = 7; row >= 0; row--) // we go from bottom up so stack items are in the correct order
{
    int stack = 0;
    for (int j = 1; j < data[row].Length; j += 4, stack++)
    {
        char crate = data[row][j];
        if (crate != ' ')
        {
            stacks[stack].Push(crate);
        }
    }
}

for (int i = 10; i < data.Length; i++)
{
    var instruction = data[i].Split(" ");

    int count = Int32.Parse(instruction[1]);
    int fromStack = Int32.Parse(instruction[3]) - 1;
    int targetStack = Int32.Parse(instruction[5]) - 1;


    Stack<char> tempStack = new Stack<char>();
    for (int j = 0; j < count; j++)
    {
        if (stacks[fromStack].Count == 0) break;
        tempStack.Push(stacks[fromStack].Pop());
    }

    while (tempStack.Count > 0)
    {
        stacks[targetStack].Push(tempStack.Pop());
    }
}

foreach (var stack in stacks)
{
    Console.Write(stack.Pop());
}