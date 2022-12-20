namespace Adventofcode_2022.Day12;

public class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Height { get; set; }

    public Node(int x, int y, int height)
    {
        X = x;
        Y = y;
        Height = height;
    }

    public int Adjacent(Node n)
    {
        if
        (
            (n.Height <= Height + 1) &&
            (n.Y == Y && (n.X - 1 == X || n.X - 1 == X)) ||
            (n.X == X && (n.Y - 1 == Y || n.Y + 1 == Y))
        )
            return 1;
        return 0;
    }

    Node[] neighbours = new Node[0];

    public IEnumerable<Node> GetNeighbours(Node[] nodes, Node goal)
    {
        if (neighbours.Length == 0)
        {
            var rtn = new List<Node?>();
            rtn.Add(nodes.FirstOrDefault(p => p.X == X - 1 && p.Y == Y));
            rtn.Add(nodes.FirstOrDefault(p => p.X == X + 1 && p.Y == Y));
            rtn.Add(nodes.FirstOrDefault(p => p.X == X && p.Y == Y - 1));
            rtn.Add(nodes.FirstOrDefault(p => p.X == X && p.Y == Y + 1));

            rtn = rtn.Where(p => p != null && p.Height <= Height + 1).OrderBy(p => p.DistanceToGoal).ToList();
            neighbours = rtn.ToArray()!;
        }

        return neighbours;
    }

    public override string ToString()
    {
        return $"{X},{Y}@{(Height == 0 ? 'S' : Height == 27 ? 'E' : (char)(Height + 96))}";
    }

    double _distance;
    public double DistanceToGoal => _distance; 

    internal double GetHeuristicDistanceToGoal(Node goal)
    {
        // Manhattan distance
        //_distance = Math.Abs(goal.X - X) + Math.Abs(goal.Y - Y);

        int x = goal.X - X;
        int y = goal.Y - Y;
        _distance = Math.Sqrt((x * x) + (y * y));
        return DistanceToGoal;
    }
}