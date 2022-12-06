namespace adventofcode_2022.day1;
public class day_1 : IDay
{
    private readonly string base_path;
    public day_1()
    {
        base_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    }

    public string Day => "Day 1";
    
    public string FirstFilePath =>  base_path + "/day1/input_1.txt";

    public string SecondFilePath => base_path + "/day1/input_1.txt";

    public string GetFirstOutput(string[] data)
    {
        // Need to know the highest
        int best = 0;
        int current = 0;

        foreach (var item in data)
        {
            if (item.Length > 0) {
                current += Int32.Parse(item);
            } else {
                if (current > best)
                {
                    best = current;
                }

                current = 0;
            }
        }

        if (current > best)
        {
            best = current;
        }

        current = 0;

        return best.ToString();
    }

    public string GetSecondOutput(string[] data)
    {
        List<int> totals = new List<int>();
        
        int idx = 0;

        foreach (var item in data)
        {
            if (item.Trim().Length == 0)
            {
                idx++;
                continue;
            }

            // Add the new element index
            if (totals.Count == idx) totals.Add(0);
            
            totals[idx] += Int32.Parse(item);
        }

        return totals.OrderByDescending(p=>p).Take(3).Sum().ToString();
    }
}