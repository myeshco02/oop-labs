using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrow(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        var map = new SmallSquareMap(10);

        Assert.Equal(10, map.Size);
    }

    [Theory]
    [InlineData(0, 0, 5, true)]
    [InlineData(4, 4, 5, true)]
    [InlineData(5, 0, 5, false)]
    [InlineData(-1, 2, 5, false)]
    public void Exist_ShouldReturnExpected(int x, int y, int size, bool expected)
    {
        var map = new SmallSquareMap(size);

        var result = map.Exist(new Point(x, y));

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(1, 1, Direction.Right, 2, 1)]
    [InlineData(4, 4, Direction.Up, 4, 4)]
    [InlineData(4, 4, Direction.Right, 4, 4)]
    public void Next_ShouldStopAtEdges(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(5);

        var next = map.Next(new Point(x, y), direction);

        Assert.Equal(new Point(expectedX, expectedY), next);
    }

    [Theory]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    [InlineData(1, 1, Direction.Right, 2, 0)]
    [InlineData(4, 4, Direction.Up, 4, 4)]
    [InlineData(4, 4, Direction.Right, 4, 4)]
    public void NextDiagonal_ShouldStopAtEdges(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(5);

        var next = map.NextDiagonal(new Point(x, y), direction);

        Assert.Equal(new Point(expectedX, expectedY), next);
    }
}
