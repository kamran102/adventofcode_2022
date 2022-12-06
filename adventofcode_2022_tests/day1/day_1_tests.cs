using adventofcode_2022.day;
using adventofcode_2022.day1;

namespace adventofcode_2022_tests.day1;

public class day_1_tests
{
    string[] input = {
        "1000",
        "2000",
        "3000",
        "",
        "4000",
        "",
        "5000",
        "6000",
        "",
        "7000",
        "8000",
        "9000",
        "",
        "10000"
    };

    public day_1_tests()
    {

    }

    #region GetFirstOutput

    [Fact]
    public void GetFirstOutput_TestDataset_CalculatesTotal()
    {
        // Arrange
        var expected = "24000";
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
        var expected = "45000";
        var sut = GetSut();

        // Act
        var actual = sut.GetSecondOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    #endregion

    #region Helper functions

    private IDay GetSut() => new day_1();
    
    #endregion
}