﻿IDay day = new day_1();

string[] data1 = File.ReadAllLines(day.FirstFilePath);
Console.WriteLine(day.GetFirstOutput(data1));

string[] data2 = File.ReadAllLines(day.SecondFilePath);
Console.WriteLine(day.GetSecondOutput(data2));