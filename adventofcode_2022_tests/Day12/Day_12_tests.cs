using adventofcode_2022.day;
using Adventofcode_2022.Day12;

namespace Adventofcode_2022_tests.Day12;

public class Day_12_tests
{
    string[] input = {
        "Sabqponm",
        "abcryxxl",
        "accszExk",
        "acctuvwj",
        "abdefghi"
    };

    public Day_12_tests()
    { }

    #region GetFirstOutput

    [Fact]
    public void GetFirstOutput_AsecndingStaircase_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "Sabcdefghijklm",
            "Ezyxwvutsrqpon"
        };
        var expected = "27";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_TestDataset1_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "Sabcdefghijklmn",
            "bdEzyxwvutsrqpo"
        };
        var expected = "27";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_TestDataset2_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "Sabcdefghijklmnopqrstuvwyz",
            "bdEzyxwvutsrqpozzzzzzzzzzz",
            "zzzzzzzzzzzzzzzzzzzzzzzzzz"
        };
        var expected = "27";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_TestDataset3_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "Sabcdefghijklmnoooopqrstuvwyz",
            "bdEzyxwvutsrqppooozzzzzzzzzzz",
            "zzzzzzzzzzzzzzzooozzzzzzzzzzz"
        };
        var expected = "29";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }
    [Fact]
    public void GetFirstOutput_LargeMultiRoute_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "Sabcdefghijklmnopqrstuvwxyz",
            "abcdefghijklmnopqrstuvwxyzz",
            "bcdefghijklmnopqrstuvwxyzzz",
            "cdefghijklmnopqrstuvwxyzzzz",
            "defghijklmnopqrstuvwxyzzzzz",
            "efghijklmnopqrstuvwxyzzzzzz",
            "fghijklmnopqrstuvwxyzzzzzzz",
            "ghijklmnopqrstuvwxyzzzzzzzz",
            "hijklmnopqrstuvwxyzzzzzzzzz",
            "ijklmnopqrstuvwxyzzzzzzzzzz",
            "jklmnopqrstuvwxyzzzzzzzzzzz",
            "klmnopqrstuvwxyzzzzzzzzzzzz",
            "lmnopqrstuvwxyzzzzzzzzzzzzz",
            "mnopqrstuvwxyzzzzzzzzzzzzzz",
            "nopqrstuvwxyzzzzzzzzzzzzzzz",
            "opqrstuvwxyzzzzzzzzzzzzzzzz",
            "pqrstuvwxyzzzzzzzzzzzzzzzzz",
            "qrstuvwxyzzzzzzzzzzzzzzzzzz",
            "rstuvwxyzzzzzzzzzzzzzzzzzzz",
            "stuvwxyzzzzzzzzzzzzzzzzzzzz",
            "tuvwxyzzzzzzzzzzzzzzzzzzzzz",
            "uvwxyzzzzzzzzzzzzzzzzzzzzzz",
            "vwxyzzzzzzzzzzzzzzzzzzzzzzz",
            "wxyzzzzzzzzzzzzzzzzzzzzzzzz",
            "xyzzzzzzzzzzzzzzzzzzzzzzzzz",
            "yzzzzzzzzzzzzzzzzzzzzzzzzzz",
            "zzzzzzzzzzzzzzzzzzzzzzzzzzE",
        };
        var expected = "52";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_TestDataset_CalculatesTotal()
    {
        // Arrange
        var expected = "31";
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
        var expected = "29";
        var sut = GetSut();

        // Act
        var actual = sut.GetSecondOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    #endregion

    #region Helper functions

    private IDay GetSut() => new Day_12_Breadth();
    
    #endregion
}