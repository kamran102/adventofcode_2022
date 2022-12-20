namespace Adventofcode_2022.Day12;
public class Day_12 : IDay
{
    private readonly string base_path;

    private readonly int GoalHeight = 27;
    private readonly int StartHeight = 0;

    public Day_12()
    {
        base_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    }

    public string Day => "Day 12";

    public string FirstFilePath => base_path + "/day12/input_1.txt";

    public string SecondFilePath => base_path + "/day12/input_1.txt";

    int[,] visited;

    public string GetFirstOutput(string[] data)
    {
        int[,] heightMap = ParseInput(data);
        var pathTaken = new Tuple<int, int>[0];

        int steps = FindRoute(heightMap, pathTaken, startHeight, startWidth) - 1;

        return steps.ToString();
    }

    private int FindRoute(int[,] heightMap, Tuple<int, int>[] pathTaken, int h, int w)
    {
        // We walk North, South, East, West from current position recursively
        int currentHeight = heightMap[h, w];
        var next = new Tuple<int, int>[pathTaken.Length + 1];
        pathTaken.CopyTo(next, 0);
        next[pathTaken.Length] = new Tuple<int, int>(h, w);

        if (currentHeight == GoalHeight) return 1;

        int rtnN = 9999, rtnS= 9999, rtnE = 9999, rtnW = 9999;

        //OutputPath(next);
        
        // North
        if (CanMoveHere(heightMap, next, h, w, h - 1, w))
        {
            Console.WriteLine($"{next.Length}\t[{h},{w}] N");
            rtnN = FindRoute(heightMap, next, h - 1, w);
        }

        // South
        if (CanMoveHere(heightMap, next, h, w, h + 1, w))
        {
            Console.WriteLine($"{next.Length}\t[{h},{w}] S");
            rtnS = FindRoute(heightMap, next, h + 1, w);
        }

        // East
        if (CanMoveHere(heightMap, next, h, w, h, w - 1))
        {
            Console.WriteLine($"{next.Length}\t[{h},{w}] E");
            rtnE = FindRoute(heightMap, next, h, w - 1);
        }

        // West
        if (CanMoveHere(heightMap, next, h, w, h, w + 1))
        {
            Console.WriteLine($"{next.Length}\t[{h},{w}] W");
            rtnW = FindRoute(heightMap, next, h, w + 1);
        }

        int rtn = Math.Min(Math.Min(rtnN, rtnS), Math.Min(rtnE, rtnW));

        Console.WriteLine($"{next.Length}\t{next.Length}: {rtn}");

        return rtn + 1;
    }

    private void OutputPath(IList<Tuple<int, int>> pathTaken)
    {
        var output = "";

        foreach (var item in pathTaken)
        {
            output += $"[{item.Item1},{item.Item2}] ";
        }

        Console.WriteLine(output);
    }

    private bool CanMoveHere(int[,] heightMap, Tuple<int, int>[] pathTaken, int h1, int w1, int h2, int w2)
    {
        var tuple = new Tuple<int, int>(h2, w2);

        if (
            !pathTaken.Contains(tuple) &&
        (h1 >= 0 && h1 < heightMap.GetLength(0)) &&
            (h2 >= 0 && h2 < heightMap.GetLength(0)) &&
            (w1 >= 0 && w1 < heightMap.GetLength(1)) &&
            (w2 >= 0 && w2 < heightMap.GetLength(1)))
        {

            int currentHeight = heightMap[h1, w1];
            int nextHeight = heightMap[h2, w2];

            if (
                nextHeight < currentHeight ||
                nextHeight == currentHeight ||
                nextHeight == currentHeight + 1)
            {
                return true;
            }
        }
        return false;
    }

    private int startWidth = -1;
    private int startHeight = -1;
    private int[,] ParseInput(string[] data)
    {
        int width = data[0].Length;
        int height = data.Length;

        var rtn = new int[height, width];

        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                switch (data[h][w])
                {
                    case 'S':
                        rtn[h, w] = StartHeight;
                        startHeight = h;
                        startWidth = w;
                        break;
                    case 'E':
                        rtn[h, w] = GoalHeight;
                        break;
                    default:
                        rtn[h, w] = ((int)data[h][w]) - 96;
                        break;
                }
            }
        }

        for (int h = 0; h < rtn.GetLength(0); h++)
        {
            for (int w = 0; w < rtn.GetLength(1); w++)
            {
                Console.Write((char)(rtn[h, w] + 96));
            }
            Console.WriteLine("");
        }
        return rtn;
    }

    public string GetSecondOutput(string[] data)
    {
        return "";
    }
}