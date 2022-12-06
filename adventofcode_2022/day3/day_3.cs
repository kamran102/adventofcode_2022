namespace adventofcode_2022.day3;
public class day_3 : IDay
{
    private char[] Counter = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
    private readonly string base_path;
    public day_3()
    {
        base_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    }

    public string Day => "Day 3";

    public string FirstFilePath => base_path + "/day3/input_1.txt";

    public string SecondFilePath => base_path + "/day3/input_1.txt";

    public string GetFirstOutput(string[] data)
    {
        int total = 0;
        List<char> chars = new List<char>();

        int max = data.Max(p => p.Length);

        foreach (string d in data)
        {
            var ch = new List<char>();

            string f = new String(d.Substring(0, (d.Length / 2)).Distinct().ToArray());
            string l = d.Substring(d.Length / 2);

            foreach (char c in f)
            {
                if (l.Contains(c) && !ch.Contains(c))
                {
                    ch.Add(c);
                }
            }

            chars.AddRange(ch);
        }

        var cList = Counter.ToList();

        foreach (char c in chars)
        {
            total += cList.IndexOf(c) + 1;
        }
        return total.ToString();
    }

    public string GetSecondOutput(string[] data)
    {
        int total = 0;
        List<char> chars = new List<char>();

        int max = data.Max(p => p.Length);

        for (int i = 0; i < data.Length; i += 3)
        {
            var sub = data.Skip(i).Take(3).ToArray();

            var cx = new List<char>();

            foreach(char c in sub[0])
            {
                if (sub[1].Contains(c) && sub[2].Contains(c) && !cx.Contains(c))
                {
                    cx.Add(c);
                }
            }
            chars.AddRange(cx);

        }

        var cList = Counter.ToList();
        foreach (char c in chars)
        {
            total += cList.IndexOf(c) + 1;
        }
        return total.ToString();
    }
}