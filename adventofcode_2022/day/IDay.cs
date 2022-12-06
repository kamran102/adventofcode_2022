namespace adventofcode_2022.day;

public interface IDay
{
    string Day { get; }
    string FirstFilePath { get; }
    string SecondFilePath { get; }
    string GetFirstOutput(string[] data);
    string GetSecondOutput(string[] data);
}