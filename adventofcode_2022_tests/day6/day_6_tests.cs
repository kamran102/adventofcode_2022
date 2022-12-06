using adventofcode_2022.day6;

namespace adventofcode_2022_tests.day6;

public class day_6_tests
{
    public day_6_tests()
    {

    }

    #region GetFirstOutput
    [Theory]
    [InlineData(5, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
    [InlineData(6, "nppdvjthqldpwncqszvftbrmjlhg")]
    [InlineData(10, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
    [InlineData(11, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
    public void GetFirstOutput_TestDataset_CalculatesTotal(int expected, string inString)
    {
        // Arrange
        var input = new string[] {inString };
        IDay sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    #endregion

    #region GetSecondOutput

    [Theory]
    [InlineData(19, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
    [InlineData(23, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
    [InlineData(23, "nppdvjthqldpwncqszvftbrmjlhg")]
    [InlineData(29, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
    [InlineData(26, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
    public void GetSecondOutput_TestDatasett_CalculatesTotal(int expected, string inString)
    {
        // Arrange
        var input = new string[] { inString };
        IDay sut = GetSut();

        // Act
        var actual = sut.GetSecondOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    #endregion

    #region Helper functions

    private IDay GetSut() => new day_6();
    
    #endregion
}