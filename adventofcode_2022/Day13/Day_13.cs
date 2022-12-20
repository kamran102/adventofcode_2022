using System.Collections.Immutable;

namespace Adventofcode_2022.Day13;
public class Day_13 : IDay
{
    private readonly string base_path;
    public Day_13()
    {
        base_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    }

    public string Day => "Day 13";

    public string FirstFilePath => base_path + "/Day13/input_1.txt";

    public string SecondFilePath => base_path + "/Day13/input_1.txt";

    public string GetFirstOutput(string[] data)
    {
        int sum = 0;
        var items = data.Where(p => !string.IsNullOrWhiteSpace(p)).Chunk(2).ToArray();

        for (int i = 0; i < items.Length; i++)
        {
            var left = ParseLine(items[i][0], out _);
            var right = ParseLine(items[i][1], out _);

            var x = left.CompareTo(right);
            if (x < 0) sum += i + 1;
        }

        return sum.ToString();
    }



    public string GetSecondOutput(string[] data)
    {
        int sum = 0;
        var items = data.Where(p => !string.IsNullOrWhiteSpace(p)).Chunk(2).ToArray();
        var pairs = new List<LinkedPair>();
        for (int i = 0; i < items.Length; i++)
        {
            pairs.Add(ParseLine(items[i][0], out _));
            pairs.Add(ParseLine(items[i][1], out _));
        }

        var div1 = ParseLine("[[2]]", out _);
        var div2 = ParseLine("[[6]]", out _);
        pairs.Add(div1);
        pairs.Add(div2);

        pairs.Sort();

        int pos1 = pairs.IndexOf(div1)+1;
        int pos2 = pairs.IndexOf(div2)+1;

        sum = pos1 * pos2;
        return sum.ToString();
    }

    private LinkedPair ParseLine(ReadOnlySpan<char> head, out ReadOnlySpan<char> tail)
    {
        head = head[1..];
        var rtn = ImmutableList.CreateBuilder<LinkedPair>();
        while (head.Length > 0)
        {
            var c = head[0];
            if (c == ']') break;
            else if (c == ',') head = head[1..];
            else rtn.Add(ParseItem(head, out head));
        }

        tail = head[1..];

        return new ListPair(rtn.ToImmutable());
    }

    private LinkedPair ParseList(ReadOnlySpan<char> input, out ReadOnlySpan<char> tail)
    {
        input = input[1..];
        var result = ImmutableList.CreateBuilder<LinkedPair>();
        while (input.Length > 0)
        {
            var ch = input[0];
            if (ch == ']')
                break;
            else if (ch == ',')
                input = input[1..];
            else
            {
                result.Add(ParseItem(input, out input));
            }
        }
        tail = input[1..];

        return new ListPair(result.ToImmutable());
    }

    private LinkedPair ParseItem(ReadOnlySpan<char> input, out ReadOnlySpan<char> tail)
    {
        char c = input[0];
        switch (c)
        {
            case '[': return ParseList(input, out tail);
            default: return ParseNumber(input, out tail);
        }
    }

    private NumberPair ParseNumber(ReadOnlySpan<char> input, out ReadOnlySpan<char> tail)
    {
        var length = input.IndexOfAny(',', ']');
        tail = input[length..];
        return new NumberPair(int.Parse(input[..length]));
    }

    abstract record LinkedPair : IComparable<LinkedPair>
    {
        public int CompareTo(LinkedPair? other)
        {
            if (this is NumberPair num1a && other is NumberPair num2a)
            {
                return num1a.Value.CompareTo(num2a.Value);
            }
            else if (this is NumberPair num1b && other is ListPair list2b)
            {
                return num1b.ToListItem().CompareTo(list2b);
            }
            else if (this is ListPair list1c && other is NumberPair num2c)
            {
                return list1c.CompareTo(num2c.ToListItem());
            }
            else if (this is ListPair list1d && other is ListPair list2d)
            {
                return list1d.CompareTo(list2d);
            }
            else
            {
                throw new ArgumentException("Cannot idenitfy source/destination types");
            }
        }
    }

    record NumberPair(int Value) : LinkedPair
    {
        public ListPair ToListItem()
        {
            return new(ImmutableList.Create(this as LinkedPair));
        }
    }


    record ListPair(ImmutableList<LinkedPair> Pair) : LinkedPair, IComparable<ListPair>
    {
        public int CompareTo(ListPair? other)
        {
            other ??= new(ImmutableList<LinkedPair>.Empty);

            var i = 0;
            int l1Count = Pair.Count;
            int l2Count = other.Pair.Count;

            while (i < l1Count && i < l2Count)
            {
                var cmp = Pair[i].CompareTo(other.Pair[i]);
                if (cmp != 0)
                    return cmp;
                i++;
            }

            return Pair.Count.CompareTo(other.Pair.Count);
        }
    }

}