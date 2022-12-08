namespace Day08;
class Program
{
    static void Main(string[] args)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

        var data = File.ReadAllLines(path);

        List<int> scenicScores = new List<int>();

        for (int i = 1; i < data.Length - 1; i++)
        {
            List<char> treeRowSizes = data[i].ToList();

            List<int> treeRowSizesParsed = treeRowSizes.Select(x => int.Parse(x.ToString())).ToList();

            for (int j = 1; j < data[i].Length - 1; j++)
            {
                List<int> treeColumnSizesParsed = new List<int>();

                for (int k = 0; k < data.Length; k++)
                {
                    treeColumnSizesParsed.Add(Int32.Parse(data[k][j].ToString()));
                }

                int currentTreeSize = Int32.Parse(data[i][j].ToString());

                var treesToTheLeft = treeRowSizesParsed.Take(j).Reverse();
                var treesToTheRight = treeRowSizesParsed.Skip(j + 1);

                var treesAbove = treeColumnSizesParsed.Take(i).Reverse();
                var treesBelow = treeColumnSizesParsed.Skip(i + 1);

                int scenicScore = 1;

                scenicScore *= CountTrees(treesToTheLeft, currentTreeSize);
                scenicScore *= CountTrees(treesToTheRight, currentTreeSize);
                scenicScore *= CountTrees(treesAbove, currentTreeSize);
                scenicScore *= CountTrees(treesBelow, currentTreeSize);

                scenicScores.Add(scenicScore);
            }
        }

        Console.WriteLine(scenicScores.Max());
    }

    private static int CountTrees(IEnumerable<int> trees, int currentTreeSize)
    {
        int count = trees.TakeWhile(x => x < currentTreeSize).Count();

        if (count == trees.Count())
            return count;
        return count + 1;
    }
}