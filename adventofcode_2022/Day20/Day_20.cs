namespace AdventOfCode_2022.Day20;
public class Day_20 : IDay
{
    private readonly string base_path;
    public Day_20()
    {
        base_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    }

    public string Day => "Day 20";

    public string FirstFilePath => base_path + "/Day20/input_1.txt";

    public string SecondFilePath => base_path + "/Day20/input_1.txt";

    public string GetFirstOutput(string[] data)
    {
        var input = ParseInput(data);
        Console.WriteLine(input.Count());
        Console.WriteLine(input.Distinct().Count());

        if (input.Count() != input.Distinct().Count()) throw new InvalidOperationException();
        var current = ParseInput(data);

        var inputIdx = 0;
        Console.WriteLine(String.Join(",", current));
        var res = new List<int>();
        for (int x = 0; x < 3; x++)
        {
            for (int i = 0; i < 1000; i++)
            {

                var move = input[inputIdx];

                current = SpliceArray(current, move);
                //Console.WriteLine($"Moving {move} : {String.Join(",", current)}");
                inputIdx++;
                if (inputIdx >= input.Length) inputIdx = 0;
            }

            var zero = Array.IndexOf(current, 0);
            res.Add(current[zero + 1]);

        }



        return (res.Sum()).ToString();
    }


    public static int[] SpliceArray(int[] current, int move)
    {
        if (move == 0) return current.ToArray();

        // TODO : This is wrong assumption
        // There may be multiple values of {move} within the array
        var pos = Array.IndexOf(current, move);
        if (move >= 0)
        {
            var next = pos + 1;
            var newPos = next + move;

            // Determine if there is a wrap around
            if (newPos > current.Length)
            {
                // Wrap
                newPos = pos + 1 + move - (current.Length);
                newPos = newPos % (current.Length);
                //newPos = newPos - 1;

                var pre = new int[0];
                var mid = new int[0];
                var post = new int[0];
                var total = new int[0];

                if (newPos > pos)
                {
                    pre = current[0..pos];
                    mid = current[(pos + 1)..newPos];
                    post = current[newPos..];
                    total = pre.Concat(mid).Concat(new int[] { move }).Concat(post).ToArray();
                }
                else
                {
                    pre = current[0..newPos]; ;
                    mid = current[newPos..pos];
                    post = current[(pos + 1)..];
                    total = pre.Concat(new int[] { move }).Concat(mid).Concat(post).ToArray();
                }

                return total;
            }
            else
            {
                var pre = current[0..pos];
                var mid = current[next..newPos];
                var post = current[newPos..];

                var total = pre.Concat(mid).Concat(new int[] { move }).Concat(post).ToArray();
                return total;
            }
        }
        else
        {
            if (pos + move > 0)
            {
                // No Wrap
                var newPos = pos + move;
                var pre = current[0..newPos];
                var mid = current[newPos..pos];
                var post = current[(pos + 1)..];

                var total = pre.Concat(new int[] { move }).Concat(mid).Concat(post).ToArray();
                return total;
            }
            else
            {

                var newPos = pos + move + current.Length;
                if (newPos > pos)
                {
                    var pre = current[0..pos];
                    var mid = current[(pos + 1)..newPos];
                    var post = current[newPos..];

                    var total = pre.Concat(mid).Concat(new int[] { move }).Concat(post).ToArray();
                    return total;
                }
                else
                {

                    var pre = current[0..newPos];
                    var mid = current[newPos..pos];
                    var post = current[(pos + 1)..];

                    var total = pre.Concat(new int[] { move }).Concat(mid).Concat(post).ToArray();
                    return total;
                }

            }
        }

        return current;
    }

    private int[] ParseInput(string[] data)
    {
        return data.Select(p => Int32.Parse(p)).ToArray();
    }

    public string GetSecondOutput(string[] data)
    {
        return "";
    }
}