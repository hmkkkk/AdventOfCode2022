using System.Drawing;

namespace Day08;
class Program
{
    static void Main(string[] args)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "input.txt");

        var data = File.ReadAllLines(path);

        var pointsVisitedByTail = new List<Point>();

        var rope = new List<Point>()
        {
            new Point(0,0),
            new Point(0,0),
            new Point(0,0),
            new Point(0,0),
            new Point(0,0),
            new Point(0,0),
            new Point(0,0),
            new Point(0,0),
            new Point(0,0),
            new Point(0,0)
        };

        foreach (var line in data)
        {
            string[] lineSplit = line.Split(" ");

            string direction = lineSplit[0];
            int distance = Int32.Parse(lineSplit[1]);

            for (int i = 0; i < distance; i++)
            {
                Move(rope, direction);
                if (!pointsVisitedByTail.Any(x => x.Equals(rope[9])))
                {
                    pointsVisitedByTail.Add(rope[9]);
                }
            }
        }


        Console.WriteLine(pointsVisitedByTail.Count);
    }

    public static void Move(List<Point> rope, string direction)
    {
        Point headAfterMove = new Point(rope[0].X, rope[0].Y);

        switch (direction)
        {
            case "U":
                headAfterMove.Y++;
                break;
            case "D":
                headAfterMove.Y--;
                break;
            case "L":
                headAfterMove.X--;
                break;
            case "R":
                headAfterMove.X++;
                break;
            default:
                break;
        }

        rope[0] = headAfterMove;

        for (int i = 1; i < rope.Count; i++)
        {
            if (!PointsAreTouching(rope[i - 1], rope[i]))
            {
                rope[i] = MoveTail(rope[i - 1], rope[i]);
            }
        }
    }

    public static Point MoveTail(Point head, Point tail)
    {
        if (head.X == tail.X)
        {
            if (head.Y > tail.Y)
            {
                tail.Y++;
            }
            else
            {
                tail.Y--;
            }
        }
        else if (head.Y == tail.Y)
        {
            if (head.X > tail.X)
            {
                tail.X++;
            }
            else
            {
                tail.X--;
            }
        }
        else if (head.X > tail.X)
        {
            if (head.Y > tail.Y)
            {
                tail.Y++;
                tail.X++;
            }
            else
            {
                tail.Y--;
                tail.X++;
            }
        }
        else if (head.X < tail.X)
        {
            if (head.Y > tail.Y)
            {
                tail.Y++;
                tail.X--;
            }
            else
            {
                tail.Y--;
                tail.X--;
            }
        }

        return tail;
    }

    public static bool PointsAreTouching(Point p1, Point p2)
    {
        int deltaX = Math.Abs(p1.X - p2.X);
        int deltaY = Math.Abs(p1.Y - p2.Y);

        return deltaX <= 1 && deltaY <= 1;
    }
}

