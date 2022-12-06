using adventofcode_2022.day;
using adventofcode_2022.day5;

namespace adventofcode_2022_tests.day5;

public class day_5_tests
{
    string[] input = {
        "    [D]    ",
        "[N] [C]    ",
        "[Z] [M] [P]",
        " 1   2   3 ",
        "",
        "move 1 from 2 to 1",
        "move 3 from 1 to 3",
        "move 2 from 2 to 1",
        "move 1 from 1 to 2"
    };

    public day_5_tests()
    {

    }

    #region GetFirstOutput

    [Fact]
    public void GetFirstOutput_TestDataset_CalculatesTotal()
    {
        // Arrange
        var expected = "CMZ";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    #endregion

    #region GetSecondOutput

    [Fact]
    public void GetSecondOutput_TestDatasett_CalculatesTotal()
    {
        // Arrange
        var expected = "MCD";
        var sut = GetSut();

        // Act
        var actual = sut.GetSecondOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    #endregion

    #region Helper functions

    private IDay GetSut() => new day_5();
    
    #endregion
}