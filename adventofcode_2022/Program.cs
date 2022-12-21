IList<IDay> days = new List<IDay>()
{
    // new adventofcode_2022.day1.day_1(),
    // new adventofcode_2022.day2.day_2(),
    // new adventofcode_2022.day3.day_3(),
    // new adventofcode_2022.day4.day_4(),
    // new adventofcode_2022.day5.day_5(),
    // new adventofcode_2022.day6.day_6(),
    //new Adventofcode_2022.Day12.Day_12_Breadth(),
    //new Adventofcode_2022.Day13.Day_13()
    new AdventOfCode_2022.Day20.Day_20()
};

foreach (IDay day in days)
{
    string[] data1 = File.ReadAllLines(day.FirstFilePath);
    Console.WriteLine(day.Day + " : " + day.GetFirstOutput(data1));

    string[] data2 = File.ReadAllLines(day.SecondFilePath);
    Console.WriteLine(day.Day + " : " + day.GetSecondOutput(data2));
}