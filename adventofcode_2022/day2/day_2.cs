namespace adventofcode_2022.day2;
public class day_2 : IDay
{
    private readonly string base_path;
    public day_2()
    {
        base_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    }

    public string FirstFilePath =>  base_path + "/day_2/input_2.txt";

    public string SecondFilePath => base_path + "/day_2/input_2.txt";

    public int GetFirstOutput(string[] data)
    {
        throw new NotImplementedException();
    }

    public int GetSecondOutput(string[] data)
    {
        throw new NotImplementedException();
    }
}