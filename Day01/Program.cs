string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

var data = File.ReadAllLines(path);

List<int> topThree = new List<int> { 0, 0, 0 };
int currentVal = 0;

foreach (var line in data)
{
    if (String.IsNullOrEmpty(line))
    {
        if (topThree.Any(x => x < currentVal))
        {
            int indexOfMin = topThree.IndexOf(topThree.Min());
            topThree[indexOfMin] = currentVal;
        }

        currentVal = 0;
        continue;
    }

    Int32.TryParse(line, out int lineVal);
    currentVal += lineVal;
}


Console.WriteLine(topThree.Sum());
