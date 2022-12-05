namespace adventofcode_2022.day2;
public partial class day_2 : IDay
{
    private const string RoundEndResult_Loss = "X";
    private const string RoundEndResult_Draw = "Y";
    private const string RoundEndResult_Win = "Z";

    private readonly string base_path;
    public day_2()
    {
        base_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!;
    }

    public string Day => "Day 2";

    public string FirstFilePath => base_path + "/day2/input_1.txt";

    public string SecondFilePath => base_path + "/day2/input_1.txt";

    public int GetFirstOutput(string[] data)
    {
        var total = 0;
        foreach (var item in data)
        {
            total += DetermineRoundPoints(item);
        }

        return total;
    }

    public int GetSecondOutput(string[] data)
    {
        var total = 0;
        foreach (var item in data)
        {
            total += DetermineRoundPointsBySelection(item);
        }

        return total;
    }

    private int DetermineRoundPoints(string round)
    {
        var values = round.Split(' ');
        var opponent = ParseAsRockPaperScissors(values[0]);
        var self = ParseAsRockPaperScissors(values[1]);
        return CalculateRoundPounds(opponent, self);
    }

    private static int CalculateRoundPounds(RockPaperScissors opponent, RockPaperScissors self)
    {
        int total = (int)self;

        // Draw
        if (opponent == self) total += 3;
        else if (
            ((opponent == RockPaperScissors.Rock) && (self == RockPaperScissors.Paper))
            || ((opponent == RockPaperScissors.Paper) && (self == RockPaperScissors.Scissors))
            || ((opponent == RockPaperScissors.Scissors) && (self == RockPaperScissors.Rock))
        )
        {
            // Win
            total += 6;
        }

        return total;
    }

    private int DetermineRoundPointsBySelection(string round)
    {
        var values = round.Split(' ');
        var opponent = ParseAsRockPaperScissors(values[0]);
        RockPaperScissors self = opponent;
        if (values[1] == RoundEndResult_Loss)
        {
            // Lose conditions
            if (opponent == RockPaperScissors.Paper) self = RockPaperScissors.Rock;
            else if (opponent == RockPaperScissors.Rock) self = RockPaperScissors.Scissors;
            else self = RockPaperScissors.Paper;
        }
        else if (values[1] == RoundEndResult_Win)
        {
            // Win conditions
            if (opponent == RockPaperScissors.Paper) self = RockPaperScissors.Scissors;
            else if (opponent == RockPaperScissors.Rock) self = RockPaperScissors.Paper;
            else self = RockPaperScissors.Rock;
        }

        return CalculateRoundPounds(opponent, self);
    }

    private RockPaperScissors ParseAsRockPaperScissors(string val)
    {
        switch (val)
        {
            case "A":
            case "X":
                return RockPaperScissors.Rock;

            case "B":
            case "Y":
                return RockPaperScissors.Paper;

            case "C":
            case "Z":
                return RockPaperScissors.Scissors;
        }

        throw new InvalidOperationException();
    }
}