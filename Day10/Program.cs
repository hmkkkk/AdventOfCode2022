string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

var data = File.ReadAllLines(path);

int x = 1;
int cycle = 0;

string signal = "";

foreach (var line in data)
{
    cycle++;

    if (Math.Abs(x - (cycle - 1) % 40) <= 1) signal += "#";
    else signal += ".";

    if (line.StartsWith("addx"))
    {
        cycle++;

        if (Math.Abs(x - (cycle - 1) % 40) <= 1) signal += "#";
        else signal += ".";

        x += Int32.Parse(line.Split(" ")[1]);
    }
}

int numSubstrings = signal.Length / 40 + (signal.Length % 40 > 0 ? 1 : 0);

for (int i = 0; i < numSubstrings; i++)
{
    int startIndex = i * 40;
    int endIndex = Math.Min((i + 1) * 40, signal.Length);

    Console.WriteLine(signal.Substring(startIndex, endIndex - startIndex)); 
}