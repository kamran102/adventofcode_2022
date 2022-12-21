
using adventofcode_2022.day;
using AdventOfCode_2022.Day20;

namespace Adventofcode_2022_tests.Day20;

public class Day_20_Tests
{
    string[] input = {
        "1",
        "2",
        "-3",
        "3",
        "-2",
        "0",
        "4"
    };

    public Day_20_Tests()
    {

    }

    #region GetFirstOutput

    [Fact]
    public void GetFirstOutput_SampleInput_Returns_ExpectedResult_Test()
    {
        // Arrange
        var expected = "";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
        
    #endregion

    #region SpliceArray


    #region Positive

    #region No Wrap

    [Fact]
    public void SpliceArray_GivenPositiveAtPosZero_NoWrap_Returns_ExpectedArray_Test()
    {
        // Arrange
        var input = new int[] { 1, 2, 3, 4 };
        var expected = new int[] { 2, 1, 3, 4 };


        // Act
        var actual = Day_20.SpliceArray(input, 1);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void SpliceArray_GivenPositiveMidArray_NoWrap_Returns_ExpectedArray_Test()
    {
        // Arrange
        var input = new int[] { 1, 2, 3, 4, 5, 6 };
        var expected = new int[] { 1, 3, 4, 2, 5, 6 };


        // Act
        var actual = Day_20.SpliceArray(input, 2);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void SpliceArray_GivenPositiveMidArray_ToLastItem_NoWrap_Returns_ExpectedArray_Test()
    {
        // Arrange
        var input = new int[] { 1, 2, 3, 4, 5, 6 };
        var expected = new int[] { 1, 2, 4, 5, 6, 3 };

        // Act
        var actual = Day_20.SpliceArray(input, 3);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    #endregion

    #region Wrap

    [Fact]
    public void SpliceArray_GivenPositiveFirstItemInArray_WrapPastItsOrginalPosition_Returns_ExpectedArray_Test()
    {
        // Arrange
        var input = new int[] { 7, 2, 3, 4, 5, 6 };
        var expected = new int[] { 2, 7, 3, 4, 5, 6 };

        // Act
        var actual = Day_20.SpliceArray(input, 7);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void SpliceArray_GivenPositiveMidArray_Wrap_Returns_ExpectedArray_Test()
    {
        // Arrange
        var input = new int[] { 1, 2, 3, 4, 5, 6 };
        var expected = new int[] { 1, 2, 4, 3, 5, 6 };

        // Act
        var actual = Day_20.SpliceArray(input, 4);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void SpliceArray_GivenPositiveLastItemInArray_WrapPastItsOrginalPosition_Returns_ExpectedArray_Test()
    {
        // Arrange
        var input = new int[] { 1, 2, 3, 4, 5, 6, 8 };
        var expected = new int[] { 1, 8, 2, 3, 4, 5, 6 };

        // Act
        var actual = Day_20.SpliceArray(input, 8);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    #endregion

    #endregion

    #region Negative

    #region No Wrap

    [Fact]
    public void SpliceArray_GivenNegativeMidArray_Returns_ExpectedArray_Test()
    {
        // Arrange
        var input = new int[] { 1, 2, 3, 4, -2, 6 };
        var expected = new int[] { 1, 2, -2, 3, 4, 6 };

        // Act
        var actual = Day_20.SpliceArray(input, -2);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void SpliceArray_GivenNegativeLastItemInArray_Returns_ExpectedArray_Test()
    {
        // Arrange
        var input = new int[] { 1, 2, 3, 4, 6, -2 };
        var expected = new int[] { 1, 2, 3, -2, 4, 6 };

        // Act
        var actual = Day_20.SpliceArray(input, -2);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    #endregion

    #region Wrap

    [Fact]
    public void SpliceArray_GivenNegativeMidArrayItem_WithWrap_Returns_ExpectedArray_Test()
    {
        // Arrange
        var input = new int[] { 1, 2, 3, 4, -5, 6, 7, 8 };
        var expected = new int[] { 1, 2, 3, 4, 6, 7, -5, 8 };

        // Act
        var actual = Day_20.SpliceArray(input, -5);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void SpliceArray_GivenNegativeMidArrayItem_WithWrapPastItsOrginalPosition_Returns_ExpectedArray_Test()
    {
        // Arrange
        var input = new int[] { 1, 2, 3, 4, -9, 6, 7, 8 };
        var expected = new int[] { 1, 2, 3, -9, 4, 6, 7, 8 };

        // Act
        var actual = Day_20.SpliceArray(input, -9);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
        
    #endregion

    #endregion

    #endregion

    #region GetSecondOutput

    [Fact]
    public void GetSecondOutput_TestDatasett_CalculatesTotal()
    {
        return;
        // Arrange
        var expected = "140";
        var sut = GetSut();

        // Act
        var actual = sut.GetSecondOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    #endregion

    #region Helper functions

    private IDay GetSut() => new Day_20();

    #endregion
}