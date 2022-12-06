namespace adventofcode_2022.day5;
public class day_5 : IDay
{
    private readonly string base_path;
    public day_5()
    {
        base_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    }

    public string Day => "Day 5";
    
    public string FirstFilePath =>  base_path + "/day5/input_1.txt";

    public string SecondFilePath => base_path + "/day5/input_1.txt";

    public int GetFirstOutput(string[] data)
    {
        return -1;
    }

    public int GetSecondOutput(string[] data)
    {
        return -1;
    }
}