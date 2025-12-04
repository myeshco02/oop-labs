using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void ToString_ShouldReturnFormattedCoordinates()
    {
        var p = new Point(3, -2);

        var text = p.ToString();

        Assert.Equal("(3, -2)", text);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(5, 5, Direction.Right, 6, 5)]
    [InlineData(2, 2, Direction.Down, 2, 1)]
    [InlineData(-1, -1, Direction.Left, -2, -1)]
    public void Next_ShouldMoveOneStep(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var p = new Point(x, y);

        var next = p.Next(direction);

        Assert.Equal(new Point(expectedX, expectedY), next);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    [InlineData(5, 5, Direction.Right, 6, 4)]
    [InlineData(2, 2, Direction.Down, 1, 1)]
    [InlineData(-1, -1, Direction.Left, -2, 0)]
    public void NextDiagonal_ShouldMoveOneStepDiagonally(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var p = new Point(x, y);

        var next = p.NextDiagonal(direction);

        Assert.Equal(new Point(expectedX, expectedY), next);
    }
}
