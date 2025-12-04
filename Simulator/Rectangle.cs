using System;

namespace Simulator;

public class Rectangle
{
    public int X1 { get; }
    public int Y1 { get; }
    public int X2 { get; }
    public int Y2 { get; }

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        var minX = Math.Min(x1, x2);
        var maxX = Math.Max(x1, x2);
        var minY = Math.Min(y1, y2);
        var maxY = Math.Max(y1, y2);

        if (minX == maxX || minY == maxY)
        {
            throw new ArgumentException("Rectangle cannot be degenerated to a line.");
        }

        X1 = minX;
        Y1 = minY;
        X2 = maxX;
        Y2 = maxY;
    }

    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y)
    {
    }

    public bool Contains(Point point) =>
        point.X >= X1 && point.X <= X2 && point.Y >= Y1 && point.Y <= Y2;

    public override string ToString() => $"({X1}, {Y1}):({X2}, {Y2})";
}
