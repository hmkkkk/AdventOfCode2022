string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

var data = File.ReadAllLines(path);

char[] alphabetArray = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

int result = 0;

for (int i = 0; i < data.Length; i+= 3)
{
    string firstLine = data[i];
    string secondLine = data[i+1];
    string thirdLine = data[i+2];

    char commonChar = firstLine.FirstOrDefault(f => secondLine.Contains(f) && thirdLine.Contains(f));

    result += Array.IndexOf(alphabetArray, commonChar) + 1;
}

Console.WriteLine(result);