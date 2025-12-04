using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldNormalizeCoordinates()
    {
        var rect = new Rectangle(5, 6, 1, 2);

        Assert.Equal(1, rect.X1);
        Assert.Equal(2, rect.Y1);
        Assert.Equal(5, rect.X2);
        Assert.Equal(6, rect.Y2);
    }

    [Theory]
    [InlineData(1, 2, 1, 3)]
    [InlineData(5, 5, 7, 5)]
    public void Constructor_ShouldThrowForColinearPoints(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Fact]
    public void Contains_ShouldIncludeEdges()
    {
        var rect = new Rectangle(0, 0, 4, 4);

        Assert.True(rect.Contains(new Point(0, 0)));
        Assert.True(rect.Contains(new Point(4, 4)));
        Assert.True(rect.Contains(new Point(2, 3)));
        Assert.False(rect.Contains(new Point(-1, 0)));
        Assert.False(rect.Contains(new Point(0, 5)));
    }

    [Fact]
    public void ToString_ShouldReturnFormatted()
    {
        var rect = new Rectangle(1, 2, 3, 4);

        Assert.Equal("(1, 2):(3, 4)", rect.ToString());
    }
}
