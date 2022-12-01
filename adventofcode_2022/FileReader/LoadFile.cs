namespace adventofcode_2022.FileReader;

public class LoadFile
{
    public static string[] ReadFile(string filepath)
    {
        return File.ReadAllLines(filepath);
    }
}