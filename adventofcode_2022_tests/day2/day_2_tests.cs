namespace adventofcode_2022_tests.day2;

public class day_2_tests
{
    string[] input = {
        "A Y",
        "B X",
        "C Z"
    };

    public day_2_tests()
    {

    }

    #region GetFirstOutput

    [Fact]
    public void GetFirstOutput_TestDataset_CalculatesTotal()
    {
        // Arrange
        int expected = 15;
        IDay sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Equals(expected);
    }

    #endregion

    #region GetSecondOutput

    [Fact]
    public void GetSecondOutput_TestDatasett_CalculatesTotal()
    {
        // Arrange
        int expected = 12;
        IDay sut = GetSut();

        // Act
        var actual = sut.GetSecondOutput(input);

        // Assert
        actual.Equals(expected);
    }

    #endregion

    #region Helper functions

    private IDay GetSut() => new day_2();

    #endregion
}