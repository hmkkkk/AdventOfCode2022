string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

var data = File.ReadAllText(path);

int messageLength = 14;

for (int i = 0; i < data.Length - messageLength; i++)
{
    string message = data.Substring(i, messageLength);

    if (message.Distinct().Count() == message.Length) 
    {
        Console.WriteLine(i + messageLength);
        break;
    }
}