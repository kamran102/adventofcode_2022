
using adventofcode_2022.day;
using Adventofcode_2022.Day13;

namespace Adventofcode_2022_tests.Day13;

// 2,3,5,6,9,11,12,13,14,15,16,18,19,20,21,22,24,25,27,28,30,31,33,34,35,38,43,44,45,53,56,59,60,61,62,66,67,70,71,73,74,75,76,77,78,79,82,83,84,86,87,88,89,91,92,93,96,99,101,103,105,107,111,112,114,115,117,118,122,123,124,126,127,130,131,132,133,134,135,138,140,143,144,145,146,149
// 2,3,5,6,7,9,11,12,14,15,16,18,19,20,21,22,24,25,27,28,31,33,34,35,43,44,45,52,53,55,56,60,61,62,66,71,73,74,75,76,77,78,79,82,83,84,86,88,91,92,93,95,96,99,101,103,105,111,112,115,121,122,123,124,125,126,127,130,131,132,133,135,136,138,143,144,145,146,149
public class Day_13_Tests
{
    string[] input = {
        "[1,1,3,1,1]",
        "[1,1,5,1,1]",
        "",
        "[[1],[2,3,4]]",
        "[[1],4]",
        "",
        "[9]",
        "[[8,7,6]]",
        "",
        "[[4,4],4,4]",
        "[[4,4],4,4,4]",
        "",
        "[7,7,7,7]",
        "[7,7,7]",
        "",
        "[]",
        "[3]",
        "",
        "[[[]]]",
        "[[]]",
        "",
        "[1,[2,[3,[4,[5,6,7]]]],8,9]",
        "[1,[2,[3,[4,[5,6,0]]]],8,9]"
    };

    public Day_13_Tests()
    {

    }

    #region GetFirstOutput

    [Fact]
    public void GetFirstOutput_EqualPackets_RightOrder_CalculatesTotal()
    {
        // Guesstimating it should be 0 as there is no clear indiciation of what it shuold be in the outline
        // Arrange
        string[] input = {
            "[1,1,5,1,1]",
            "[1,1,5,1,1]",
        };
        var expected = "0";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_PackWithOneArray_RightOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[1,1,3,1,1]",
            "[1,1,5,1,1]",
        };
        var expected = "1";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_PacketWithOneArray_WrongOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[1,1,5,1,1]",
            "[1,1,3,1,1]",
        };
        var expected = "0";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_SingleArray_RightRunsOut_WrongOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[7,7,7,7]",
            "[7,7,7]"
        };
        var expected = "0";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_SingleArray_LeftRunsOut_RightOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[7,7,7]",
            "[7,7,7,7]",
        };
        var expected = "1";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_NestedArrysEqualValues_WrongOrder_CalculatesTotal()
    {
        // Guesstimating this is worng - no clear indicator in brief
        // Arrange
        string[] input = {
            "[[1],[2,3,4]]",
            "[[1],[2,3,4]]",
        };
        var expected = "0";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_NestedArrys_LeftIsSmaller_RightOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[[1],[2,3,4]]",
            "[[1],[4,3,2]]",
        };
        var expected = "1";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_NestedArrys_RightIsSmaller_WrongOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[[1],[4,3,2]]",
            "[[1],[2,3,4]]",
        };
        var expected = "0";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_NestedArrys_WithRightSingleNumber_RightOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[[1],[2,3,4]]",
            "[[1],4]",
        };
        var expected = "1";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_NestedArrys_WithLeftSingleNumber_WrongOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[[1],4]",
            "[[1],[2,3,4]]",
        };
        var expected = "0";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_SoloWithNestedArray_LeftTurnsToArray_WrongOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[9]",
            "[[8,7,6]]"
        };
        var expected = "0";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_SoloWithNestedArray_RightTurnsToArray_RightOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[[8,7,6]]",
            "[9]",
        };
        var expected = "1";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_MultipleNumbers_LeftRunsOut_RightOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[[1,2],3,4]",
            "[[4,4],4,4,4]"
        };
        var expected = "1";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_MultipleNumbers_RightIsLower_WrongOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[[4,4],3,4,4]",
            "[[1,2,3],3,4]",
        };
        var expected = "0";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_DoubleDigit_RightOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[7,10,4,6]",
            "[7,10,4,6,9]"
        };
        var expected = "1";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_DoubleDigit_WrongOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[7,10,4,6,9]",
            "[7,10,4,6]",
        };
        var expected = "0";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_LeftIsEmpty_RightOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[]",
            "[3]"
        };
        var expected = "1";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_RightIsEmpty_WrongOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[3]",
            "[]",
        };
        var expected = "0";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_NestedEmptyArrays_WrongOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[[[]]]",
            "[[]]"
        };
        var expected = "0";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_NestedEmptyArrays_RightOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[[]]",
            "[[[]]]",
        };
        var expected = "1";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_ComplexMultipleArrays_WrongOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[1,[2,[3,[4,[5,6,7]]]],8,9]",
            "[1,[2,[3,[4,[5,6,0]]]],8,9]"
        };
        var expected = "0";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_ComplexMultipleArrays_RightOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[1,[2,[3,[4,[5,6,0]]]],8,9]",
            "[1,[2,[3,[4,[5,6,7]]]],8,9]",
        };
        var expected = "1";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_Pair1FromActual_WrongOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[[[[8,6]],[8,[7],[6,7,6,2,4]],10,[[1,7,9],7,[7,9]]],[[4,[],[10,5],[5,4,7],5],8,9,[[5,3,3,6,9],[9,5,10],8],[[0,6,9],[8],4,6,8]]]",
            "[[[],3,[[10,6,9,6],[6,8,7],[1,2]],8]]"
        };
        var expected = "0";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_Sample1FromActual_WrongOrder_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[[7,[]]]",
            "[[[],9,[[0,9,1],[6],9,[8,4,10,4,7],[6]]],[3,[2,[0,5],7,9],2],[[[9],7,[1,7],9]]]"
        };
        var expected = "0";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Fact]
    public void GetFirstOutput_TestData_ReturnsExpected_CalculatesTotal()
    {
        // Arrange
        string[] input = {
            "[1,1,3,1,1]",
            "[1,1,5,1,1]",
            "",
            "[[1],[2,3,4]]",
            "[[1],4]",
            "",
            "[9]",
            "[[8,7,6]]",
            "",
            "[[4,4],4,4]",
            "[[4,4],4,4,4]",
            "",
            "[7,7,7,7]",
            "[7,7,7]",
            "",
            "[]",
            "[3]",
            "",
            "[[[]]]",
            "[[]]",
            "",
            "[1,[2,[3,[4,[5,6,7]]]],8,9]",
            "[1,[2,[3,[4,[5,6,0]]]],8,9]"
        };
        var expected = "13";
        var sut = GetSut();

        // Act
        var actual = sut.GetFirstOutput(input);

        // Assert
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(new string[] { "[[[[8,6]],[8,[7],[6,7,6,2,4]],10,[[1,7,9],7,[7,9]]],[[4,[],[10,5],[5,4,7],5],8,9,[[5,3,3,6,9],[9,5,10],8],[[0,6,9],[8],4,6,8]]]", "[[[],3,[[10,6,9,6],[6,8,7],[1,2]],8]]" }, "0")]
    [InlineData(new string[] { "[[4,[4],[[10,7,2],[1,6,5,7,4],[7,3,3,1,5],[]],1],[[],[[7,6,3]],5,5]]", "[[[10]]]" }, "1")]
    [InlineData(new string[] { "[[[],2,2,9,[[9],[1,10,5,1]]],[[[],9,5,[8]],10,9,[[1,4,0],[5]]]]", "[[5],[3],[],[9,[[7,2,0,9,3],[6,8,6],[]]],[[[6],3],6,[[2,8],8]]]" }, "1")]
    [InlineData(new string[] { "[[2],[[[8]],6],[2,[[7],10,0,[8,7]],9,[9]],[]]", "[[2,[[4,9],4,[],9]],[[1,[8,7,3],0,2],2],[[],5,2],[0,10]]" }, "1")]
    [InlineData(new string[] { "[[[7,[0,2],[],3,[5,0,6,9,0]],0],[[[8],[6,8,4,2],[8,6,4,8],4,3]],[[3,2,4],[6,2],10,[[6],3,[2,6,0]],[[7],4,6,[]]],[]]", "[[7,1,2,1,[[2,0,8,10,10],[5,6,1],[6],[5]]],[[6,[10,5,10,1,1],6],1],[[[8,1,2,5,8],0],[10,9,[2,4,4,8]],6,[2,[1],0],6]]" }, "0")]
    public void GetFirstOutput_ActualTests(string[] input, string expected)
    {
        // Arrange
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

    private IDay GetSut() => new Day_13();

    #endregion
}