IList<IDay> days = new List<IDay>()
{
    new day_1(),
    new day_2()
};

foreach (IDay day in days)
{
    string[] data1 = File.ReadAllLines(day.FirstFilePath);
    Console.WriteLine(day.GetFirstOutput(data1));

    string[] data2 = File.ReadAllLines(day.SecondFilePath);
    Console.WriteLine(day.GetSecondOutput(data2));
}