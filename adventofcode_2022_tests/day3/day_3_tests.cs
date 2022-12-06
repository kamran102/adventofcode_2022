using adventofcode_2022.day;
using adventofcode_2022.day3;

namespace adventofcode_2022_tests.day3;

public class day_3_tests
{
    string[] input = {
        "vJrwpWtwJgWrhcsFMMfFFhFp",
        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
        "PmmdzqPrVvPwwTWBwg",
        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
        "ttgJtRGJQctTZtZT",
        "CrZsJsPPZsGzwwsLwLmpwMDw"
    };

    public day_3_tests()
    {

    }

    #region GetFirstOutput

    [Fact]
    public void GetFirstOutput_TestDataset1Row_CalculatesTotal()
    {
        // Arrange
        var expected = "16";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input.Take(1).ToArray());

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_TestDataset2Rows_CalculatesTotal()
    {
        // Arrange
        var expected = "54";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input.Take(2).ToArray());

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_TestDataset_CalculatesTotal()
    {
        // Arrange
        var expected = "157";
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
        var expected = "70";
        var sut = GetSut();

        // Act
        var actual = sut.GetSecondOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    #endregion

    #region Helper functions

    private IDay GetSut() => new day_3();

    #endregion
}