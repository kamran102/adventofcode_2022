using System.Diagnostics.CodeAnalysis;

namespace Adventofcode_2022.Day12;
public class Day_12_Breadth : IDay
{
    private readonly string base_path;

    private readonly int GoalHeight = 27;
    private readonly int StartHeight = 0;

    public Day_12_Breadth()
    {
        base_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    }

    public string Day => "Day 12";

    public string FirstFilePath => base_path + "/day12/input_1.txt";

    public string SecondFilePath => base_path + "/day12/input_1.txt";

    MazeNode[,] mazeArray;

    public string GetFirstOutput(string[] data)
    {
        MazeNode start;
        MazeNode end;
        var heightMap = ParseInput(data, out start, out end);

        int steps = FindShortestRoute(heightMap, start, end);

        return steps.ToString();
    }

    private MazeNode[] GetNeighbours(MazeNode[,] maze, MazeNode node, bool oneStepOnly = false)
    {
        var rtn = new List<MazeNode>();
        int maxX = maze.GetLength(1);
        int maxY = maze.GetLength(0);
        if (node.X > 0)
        {
            var left = maze[node.Y, node.X - 1];
            if (IsHeightValid(node, left, oneStepOnly)) rtn.Add(left);
        }

        if (node.X < maxX - 1)
        {
            var right = maze[node.Y, node.X + 1];
            if (IsHeightValid(node, right, oneStepOnly)) rtn.Add(right);
        }

        if (node.Y > 0)
        {
            var top = maze[node.Y - 1, node.X];
            if (IsHeightValid(node, top, oneStepOnly)) rtn.Add(top);
        }

        if (node.Y < maxY - 1)
        {
            var bottom = maze[node.Y + 1, node.X];
            if (IsHeightValid(node, bottom, oneStepOnly)) rtn.Add(bottom);
        }

        return rtn.OrderBy(p => p.DistanceFromStart).ToArray();
    }

    private static bool IsHeightValid(MazeNode src, MazeNode other, bool oneStepOnly)
    {
        bool neighbour = other.Height == src.Height;
        neighbour = neighbour || Math.Abs(other.Height - src.Height) == 1;
        if (!oneStepOnly)
        {
            neighbour = neighbour || other.Height < src.Height;
        }

        return neighbour;
    }

    private int FindShortestRoute(MazeNode[,] maze, MazeNode start, MazeNode end)
    {
        //var queue = maze.Nodes.OrderBy(p => p.DistanceFromStart).ToList();

        var queue = new List<MazeNode>();
        queue.Add(start);

        while (queue.Count() > 0)
        {
            var node = queue.First();

            if (node != end)
            {

                //if (queue.Count % 5 == 0)
                Console.WriteLine($"Working on {node}, with {queue.Count} remaining.");

                node.IsVisited = true;
                var neighbours = GetNeighbours(maze, node);
                foreach (var neighbour in neighbours)
                {
                    if (!neighbour.IsVisited)
                    {
                        node.DistanceToStart(neighbour);
                        if (!queue.Contains(neighbour))
                            queue.Add(neighbour);
                    }
                }
            }

            queue.Remove(node);
        }

        return end.DistanceFromStart ?? Int32.MaxValue;

        // MarkPath(maze, end);
        // BestSoFar = Int32.MaxValue;
        // var path = DeterminePath(maze, end, new MazeNode[0]);

        // Console.WriteLine(String.Join('\r', path.Select(p => (char)(p.Height + 96))));
        // return path.Length - 1;
    }

    private void MarkPath(MazeNode[,] maze, MazeNode goal)
    {
        var neighbours = GetNeighbours(maze, goal);
    }

    private int BestSoFar = Int32.MaxValue;

    private MazeNode[] DeterminePath(MazeNode[,] maze, MazeNode start, MazeNode[] path)
    {
        path = path.Concat(new MazeNode[] { start }).ToArray();
        var neighbours = GetNeighbours(maze, start, true);
        var paths = new List<MazeNode[]>();

        Console.WriteLine($"Processing path {path.Length} on ({start}) with {neighbours.Length}...");

        // The path is too long
        if (paths.Count > BestSoFar)
        {
            Console.WriteLine("Path too long, Abort.");
            return path;
        }

        foreach (var neighbour in neighbours)
        {
            if (path.Contains(neighbour)) continue;

            var nextPath = new MazeNode[path.Length];

            if (neighbour.IsStart == true)
            {
                nextPath = new MazeNode[path.Length + 1];
                path.CopyTo(nextPath, 0);
                nextPath[path.Length] = neighbour; // last node
            }
            else
            {
                path.CopyTo(nextPath, 0);
                nextPath = DeterminePath(maze, neighbour, nextPath);
            }

            paths.Add(nextPath);
        }


        var optimal = paths.Where(p => p.Any(p => p.IsStart)).OrderBy(p => p.Length).ToList();
        if (optimal.Count == 0) return path;

        var rtn = optimal.First();
        if (rtn.Length < BestSoFar) BestSoFar = rtn.Length;

        return optimal.First();
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

    private MazeNode[,] ParseInput(string[] data, out MazeNode start, out MazeNode end)
    {
        start = null;
        end = null;

        int width = data[0].Length;
        int height = data.Length;
        MazeNode[,] nodes = new MazeNode[height, width];

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                switch (data[row][col])
                {
                    case 'S':
                        var nodeStart = new MazeNode(col, row, StartHeight, false, true, true, 0);
                        nodes[row, col] = nodeStart;
                        start = nodeStart;

                        break;
                    case 'E':
                        var nodeEnd = new MazeNode(col, row, GoalHeight, true, false, false);
                        nodes[row, col] = nodeEnd;
                        end = nodeEnd;
                        break;
                    default:
                        int tileHeight = ((int)data[row][col]) - 96;
                        nodes[row, col] = new MazeNode(col, row, tileHeight, false, false, false);
                        break;
                }
            }
        }

        return nodes;
    }

    public string GetSecondOutput(string[] data)
    {
        MazeNode start;
        MazeNode end;
        var heightMap = ParseInput(data, out start, out end);

        IList<MazeNode> startingPoints = new List<MazeNode>();

        int height = 'a' - 96;

        for (int i = 0; i < heightMap.GetLength(0); i++)
        {
            for (int j = 0; j < heightMap.GetLength(1); j++)
            {
                if (heightMap[i, j].Height == height)
                {
                    startingPoints.Add(heightMap[i, j]);
                }
            }
        }

        startingPoints.Add(start);

        int steps = Int32.MaxValue;
        int shortest = Int32.MaxValue;

        foreach (var node in startingPoints)
        {
            var copy = ParseInput(data, out start, out end);
            var copyNode = copy[node.Y, node.X];
            copyNode.DistanceFromStart = 0;
            copyNode.IsStart = true;
            copyNode.IsVisited = false;

            // Reset false start
            start.DistanceFromStart = Int32.MaxValue;
            start.IsStart = false;
            start.IsVisited = false;

            steps = FindShortestRoute(copy, copyNode, end);
            if (steps < shortest) shortest = steps;
        }

        return shortest.ToString();
    }
}

record MazeNode(int X, int Y, int Height, bool IsGoal) : IComparable<MazeNode>, IEqualityComparer<MazeNode>
{
    public bool IsUnreachable { get; set; }
    public bool IsVisited { get; set; }
    public int? DistanceFromStart { get; set; }

    public bool HasRouteToGoal { get; set; }

    public bool IsStart { get; set; }

    public MazeNode(int X, int Y, int Height, bool IsGoal, bool IsStart, bool visited, int DistanceFromStart = Int32.MaxValue)
        : this(X, Y, Height, IsGoal)
    {
        this.IsVisited = IsVisited;
        this.DistanceFromStart = DistanceFromStart;
        this.IsStart = IsStart;
    }

    internal void DistanceToStart(MazeNode neighbour)
    {
        int current = DistanceFromStart.Value;
        if (current == Int32.MaxValue)
        {
            this.IsUnreachable = true;
            //this.IsVisited = false;
            Console.Error.WriteLine("Attempting to calculate distance on node with no distance value");
            return;
        }

        int distance = current + 1;
        if (neighbour.DistanceFromStart > distance)
            neighbour.DistanceFromStart = current + 1;
    }

    public override string ToString()
    {
        return $"{X},{Y} : {(Char)(96 + Height)} : {DistanceFromStart}";
    }

    public int CompareTo(MazeNode? other)
    {
        if (other is null) return -1;

        return DistanceFromStart.Value.CompareTo(other.DistanceFromStart.Value);
    }

    public bool Equals(MazeNode? a, MazeNode? b)
    {
        if (a == null && b == null) return true;

        if (a?.X == b?.X && a?.Y == b?.Y) return true;

        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public int GetHashCode([DisallowNull] MazeNode obj)
    {
        return obj.GetHashCode();
    }
}