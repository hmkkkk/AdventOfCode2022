namespace Day08;
class Program
{
    static void Main(string[] args)
    {
        var monkeyItems = new List<List<ulong>>
        {
            new List<ulong> { 64, 89, 65, 95 },
            new List<ulong> { 76, 66, 74, 87, 70, 56, 51, 66 },
            new List<ulong> { 91, 60, 63 },
            new List<ulong> { 92, 61, 79, 97, 79 },
            new List<ulong> { 93, 54 },
            new List<ulong> { 60, 79, 92, 69, 88, 82, 70 },
            new List<ulong> { 64, 57, 73, 89, 55, 53 },
            new List<ulong> { 62 }
        };

        ulong mod = 3 * 13 * 2 * 11 * 5 * 17 * 19 * 7;

        var itemsInspectedByMonkey = new List<ulong> { 0, 0, 0, 0, 0, 0, 0, 0 };

        for (int round = 0; round < 10000; round++)
        {
            for (int i = 0; i < monkeyItems.Count; i++)
            {
                var itemsPassedCheck = new List<ulong>();
                var itemsDidntPassCheck = new List<ulong>();

                for (int j = 0; j < monkeyItems[i].Count; j++)
                {
                    itemsInspectedByMonkey[i]++;

                    monkeyItems[i][j] = ExecuteOperation(monkeyItems[i][j], i);
                    //monkeyItems[i][j] /= 3;

                    monkeyItems[i][j] %= mod;


                    if (ItemPassedCheck(monkeyItems[i][j], i)) itemsPassedCheck.Add(monkeyItems[i][j]);
                    else itemsDidntPassCheck.Add(monkeyItems[i][j]);
                }

                MoveItemsToAnotherMonkeys(itemsPassedCheck, itemsDidntPassCheck, i, monkeyItems);

                monkeyItems[i] = new List<ulong>();
            }
        }

        // Sort the list in descending order
        itemsInspectedByMonkey.Sort((a, b) => b.CompareTo(a));

        Console.WriteLine((itemsInspectedByMonkey[0] * itemsInspectedByMonkey[1]));
    }

    public static ulong ExecuteOperation(ulong item, int monkeyIndex)
    {
        return monkeyIndex switch
        {
            0 => item * 7,
            1 => item + 5,
            2 => item * item,
            3 => item + 6,
            4 => item * 11,
            5 => item + 8,
            6 => item + 1,
            7 => item + 4,
            _ => 0
        };
    }

    public static bool ItemPassedCheck(ulong item, int monkeyIndex)
    {
        return monkeyIndex switch
        {
            0 => item % 3 == 0,
            1 => item % 13 == 0,
            2 => item % 2 == 0,
            3 => item % 11 == 0,
            4 => item % 5 == 0,
            5 => item % 17 == 0,
            6 => item % 19 == 0,
            7 => item % 7 == 0,
            _ => false
        };
    } 

    public static void MoveItemsToAnotherMonkeys(List<ulong> itemsPassed, List<ulong> itemsNotPassed, int monkeyIndex, List<List<ulong>> monkeyItems)
    {
        switch (monkeyIndex)
        {
            case 0:
                monkeyItems[4].AddRange(itemsPassed);
                monkeyItems[1].AddRange(itemsNotPassed);
                break;
            case 1:
                monkeyItems[7].AddRange(itemsPassed);
                monkeyItems[3].AddRange(itemsNotPassed);
                break;
            case 2:
                monkeyItems[6].AddRange(itemsPassed);
                monkeyItems[5].AddRange(itemsNotPassed);
                break;
            case 3:
                monkeyItems[2].AddRange(itemsPassed);
                monkeyItems[6].AddRange(itemsNotPassed);
                break;
            case 4:
                monkeyItems[1].AddRange(itemsPassed);
                monkeyItems[7].AddRange(itemsNotPassed);
                break;
            case 5:
                monkeyItems[4].AddRange(itemsPassed);
                monkeyItems[0].AddRange(itemsNotPassed);
                break;
            case 6:
                monkeyItems[0].AddRange(itemsPassed);
                monkeyItems[5].AddRange(itemsNotPassed);
                break;
            case 7:
                monkeyItems[3].AddRange(itemsPassed);
                monkeyItems[2].AddRange(itemsNotPassed);
                break;
            default:
                break;
        }
    }
}

        