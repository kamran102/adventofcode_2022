namespace adventofcode_2022.day6;
public class day_6 : IDay
{
    private readonly string base_path;

    public string Day => "Day 6";

    public string FirstFilePath => base_path + "/day6/input_1.txt";

    public string SecondFilePath => base_path + "/day6/input_1.txt";

    public day_6()
    {
        base_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    }

    public string GetFirstOutput(string[] data)
    {
        return PacketMachine(data[0], 4).ToString();
    }

    public string GetSecondOutput(string[] data)
    {
        return PacketMachine(data[0], 14).ToString();
    }

    private int PacketMachine(string data, int indicatorLength)
    {
        return FindDistinct(0, data, indicatorLength);
    }

    private int FindDistinct(int start, string data, int uniqueLength)
    {
        var last4 = data.Substring(start, uniqueLength);
        if (last4.Distinct().Count() != uniqueLength)
            return FindDistinct(start + 1, data, uniqueLength);

        return start + uniqueLength;
    }
}