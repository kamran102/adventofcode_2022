namespace adventofcode_2022.day4;
public class day_4 : IDay
{
    private IList<int> numbers;

    private readonly string base_path;
    public day_4()
    {
        base_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;

        numbers = new List<int>();

        for (var i = 0; i < 1000; i++)
        {
            numbers.Add(i);
        }
    }

    public string Day => "Day 4";
    
    public string FirstFilePath =>  base_path + "/day4/input_1.txt";

    public string SecondFilePath => base_path + "/day4/input_1.txt";

    public string GetFirstOutput(string[] data)
    {
        int count = 0;

        foreach (var item in data)
        {
            IEnumerable<int> i1, i2;
            GetDataValue(item, out i1, out i2);

            if (i1.All(p => i2.Contains(p)) ||
            i2.All(p => i1.Contains(p)))
            {
                count++;
            }
        }

        return count.ToString();
    }

    public string GetSecondOutput(string[] data)
    {
        int count = 0;

        foreach (var item in data)
        {
            IEnumerable<int> i1, i2;
            GetDataValue(item, out i1, out i2);

            if (i1.Any(p => i2.Contains(p)) ||
            i2.Any(p => i1.Contains(p)))
            {
                count++;
            }
        }

        return count.ToString();
    }

    private void GetDataValue(string item, out IEnumerable<int> i1, out IEnumerable<int> i2)
    {
        var str = item.Split(',');
        var f1 = Int32.Parse(str[0].Split('-')[0]);
        var l1 = Int32.Parse(str[0].Split('-')[1]);

        var f2 = Int32.Parse(str[1].Split('-')[0]);
        var l2 = Int32.Parse(str[1].Split('-')[1]);

        i1 = numbers.Skip(f1).Take(l1 - f1 + 1);
        i2 = numbers.Skip(f2).Take(l2 - f2 + 1);
    }
}