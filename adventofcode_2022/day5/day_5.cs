namespace adventofcode_2022.day5;
public class day_5 : IDay
{
    private const int Index_NumberOfItemsToMove = 1;
    private const int Index_StackToMoveFrom = 3;
    private const int Index_StackToMoveTo = 5;
    private readonly string base_path;
    public day_5()
    {
        base_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    }

    public string Day => "Day 5";

    public string FirstFilePath => base_path + "/day5/input_1.txt";

    public string SecondFilePath => base_path + "/day5/input_1.txt";

    public string GetFirstOutput(string[] data)
    {
        Stack<char>[] stack = ParseAsStack(data);
        processSteps(data, stack, false);
        return ReadFirstItemFromAllStacks(stack);
    }

    public string GetSecondOutput(string[] data)
    {
        Stack<char>[] stack = ParseAsStack(data);
        processSteps(data, stack, true);
        return ReadFirstItemFromAllStacks(stack);
    }

    private static string ReadFirstItemFromAllStacks(Stack<char>[] stack)
    {
        var rtn = "";
        foreach (var s in stack)
        {
            var ch = ' ';
            if (s.TryPeek(out ch)) rtn = rtn + ch;
        }

        return rtn;
    }

    private Stack<char>[] ParseAsStack(string[] data)
    {
        var len = (int)Math.Ceiling(data[0].Length / 4.0);
        var stack = new Stack<char>[len];

        for (int i = 0; i < stack.Length; i++)
        {
            stack[i] = new Stack<char>();
        }

        var dx = data.Reverse();

        foreach (var d in dx)
        {
            ParseLine(stack, d);
        }

        return stack;
    }

    private void ParseLine(Stack<char>[] stack, string line)
    {
        for (int i = 0; i < line.Length; i += 4)
        {
            // Only work with stack line
            if (!line.Contains('[')) continue;

            var idx = i / 4;
            if (line[i] == '[')
            {
                // has char
                stack[idx].Push(line[i + 1]);
            }
        }
    }

    private static void processSteps(string[] data, Stack<char>[] stack, bool moveAll)
    {
        foreach (var i in data)
        {
            // Only work for move line
            if (!i.StartsWith("move")) continue;

            var d = i.Split(' ');

            int numberToMove = Int32.Parse(d[Index_NumberOfItemsToMove]);
            int from = Int32.Parse(d[Index_StackToMoveFrom]) - 1;
            int to = Int32.Parse(d[Index_StackToMoveTo]) - 1;

            MoveStackItems(stack, from, to, numberToMove, moveAll);
        }
    }

    private static void MoveStackItems(Stack<char>[] stack, int from, int to, int numberToMove, bool moveInOrder)
    {
        var list = new List<char>();
        for (int j = 0; j < numberToMove; j++)
        {
            list.Add(stack[from].Pop());
        }

        if (moveInOrder)
            list.Reverse();

        foreach (var c in list)
        {
            stack[to].Push(c);
        }
    }
}