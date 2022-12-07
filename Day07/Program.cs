using System.Linq;

string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

var data = File.ReadAllLines(path);

Dictionary<string, int> directories = new Dictionary<string, int>();

string dirPathString = "";

foreach (var line in data)
{
    var lineSplit = line.Split(" ");
    if (lineSplit[1] == "cd")
    {
        if (lineSplit[2] == "/")
        {
            dirPathString = "";
        }
        else if (lineSplit[2] == "..")
        {
            dirPathString = dirPathString.Substring(0, Math.Max(dirPathString.LastIndexOf("/"), 1));
        }
        else
        {
            dirPathString += $"/{lineSplit[2]}";
        }

        if (!directories.Any(x => x.Key == dirPathString))
        {
            directories.Add(dirPathString, 0);
        }
    }
    else if (Int32.TryParse(lineSplit[0], out int fileSize))
    {
        directories[dirPathString] = directories[dirPathString] + fileSize;
    }
}

int sum = directories.Sum(x => x.Value);

int totalDiscSpace = 70000000;

int spaceNeeded = 30000000;

int spaceLeft = totalDiscSpace - sum;

List<int> directorySizesIncludingSubDirectories = new List<int>();

foreach (var directory in directories)
{
    int totalDirectorySize = directories.Where(x => x.Key.StartsWith(directory.Key)).Sum(x => x.Value);

    directorySizesIncludingSubDirectories.Add(totalDirectorySize);
}

int answer = directorySizesIncludingSubDirectories.Where(x => x + spaceLeft > spaceNeeded).Min();

Console.WriteLine(answer);
