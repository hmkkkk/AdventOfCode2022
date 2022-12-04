string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

var data = File.ReadAllLines(path);

int overlappingSections = 0;

foreach (var line in data)
{
    var sections = line.Split(",");

    var sectionOneRange = sections[0].Split("-");
    var sectionTwoRange = sections[1].Split("-");

    int minValueSectionOne = Int32.Parse(sectionOneRange[0]);
    int minValueSectionTwo = Int32.Parse(sectionTwoRange[0]);

    int enumberableCountSectionOne = Int32.Parse(sectionOneRange[1]) - Int32.Parse(sectionOneRange[0]);
    int enumberableCountSectionTwo = Int32.Parse(sectionTwoRange[1]) - Int32.Parse(sectionTwoRange[0]);

    var sectionOneItems = Enumerable.Range(minValueSectionOne, enumberableCountSectionOne + 1).ToArray();
    var sectionTwoItems = Enumerable.Range(minValueSectionTwo, enumberableCountSectionTwo + 1).ToArray();

    if (sectionOneItems.Any(s => sectionTwoItems.Contains(s)))
    {
        overlappingSections++;
    }
}

Console.WriteLine(overlappingSections);