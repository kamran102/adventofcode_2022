namespace adventofcode_2022.day;

public interface IDay
{
    string Day { get; }
    string FirstFilePath { get; }
    string SecondFilePath { get; }
    int GetFirstOutput(string[] data);
    int GetSecondOutput(string[] data);
}