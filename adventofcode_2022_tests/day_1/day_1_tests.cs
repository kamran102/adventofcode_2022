namespace adventofcode_2022_tests;

public class day_1_tests
{
    public day_1_tests()
    {

    }

    #region GetFirstOutput

    [Fact]
    public void GetFirstOutput_SingleDataSet_CalculatesTotal()
    {
        // Arrange
        int expected = 2000;

        string[] input = { "1000", "1000" };
        IDay sut = new day_1();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Equals(expected);
    }

    [Fact]
    public void GetFirstOutput_TwoDataSets_ReturnsHighest()
    {
        // Arrange
        int expected = 3000;

        string[] input = { "1000", "2000", "", "1000", "1000" };
        IDay sut = new day_1();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Equals(expected);
    }

    #endregion

    #region GetSecondOutput

    [Fact]
    public void GetSecondOutput_MultipleDataSet_CalculatesTotal()
    {
        // Arrange
        int expected = 6000;

        string[] input = { "1000", "1000", "", "1000", "1000", "", "1000", "1000" };
        IDay sut = new day_1();

        // Act
        var actual = sut.GetSecondOutput(input);

        // Assert
        actual.Equals(expected);
    }

    [Fact]
    public void GetSecondOutput_MultipleDataSets_ReturnsHighest()
    {
        // Arrange
        int expected = 14000 ;

        string[] input = { "1000", "2000", "", "1000", "3000", "", "1000", "5000", "", "1000", "1000", "", "1000", "1000", "", "1000", "3000" };
        IDay sut = new day_1();

        // Act
        var actual = sut.GetSecondOutput(input);

        // Assert
        actual.Equals(expected);
    }

    #endregion
}