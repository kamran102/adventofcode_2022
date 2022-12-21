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
        var current = ParseInput(data);

        var oneThou = 0;
        var twoThou = 0;
        var threeThou = 0;

        var i = 0;
        var inputIdx = 0;
        Console.WriteLine(String.Join(",", current));
        while (i <= 3000)
        {
            var move = input[inputIdx];

            current = SpliceArray(current, move);
            Console.WriteLine($"Moving {move} : {String.Join(",", current)}");

            if (i == 1000)
            {
                var zero = Array.IndexOf(current, 0);
                oneThou = current[zero + 1];
            }
            if (i == 2000)
            {
                var zero = Array.IndexOf(current, 0);
                twoThou = current[zero + 1];
            }
            if (i == 3000)
            {
                var zero = Array.IndexOf(current, 0);
                threeThou = current[zero + 1];
            }
            i++;
            inputIdx++;
            if (inputIdx >= input.Length) inputIdx = 0;
        }


        return "";
    }

    public static int[] SpliceArray(int[] current, int move)
    {
        if (move == 0) return current.ToArray();

        var pos = Array.IndexOf(current, move);
        if (move >= 0)
        {
            var next = pos + 1;
            var newPos = next + move;

            // Determine if there is a wrap around
            if (newPos > current.Length)
            {
                // Wrap
                newPos = pos + 1 + move - (current.Length - 1);
                newPos = newPos % (current.Length - 1);
                newPos = newPos - 1;



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

                    var total = pre.Concat(mid).Concat(new int[] { move }).Concat(post).ToArray();
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