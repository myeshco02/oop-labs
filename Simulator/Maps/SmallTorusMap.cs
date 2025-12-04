using System;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20.");
        }

        Size = size;
    }

    public override bool Exist(Point p) => p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;

    public override Point Next(Point p, Direction d)
    {
        var (dx, dy) = d switch
        {
            Direction.Up => (0, 1),
            Direction.Right => (1, 0),
            Direction.Down => (0, -1),
            Direction.Left => (-1, 0),
            _ => (0, 0),
        };

        return Wrap(p, dx, dy);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var (dx, dy) = d switch
        {
            Direction.Up => (1, 1),
            Direction.Right => (1, -1),
            Direction.Down => (-1, -1),
            Direction.Left => (-1, 1),
            _ => (0, 0),
        };

        return Wrap(p, dx, dy);
    }

    private Point Wrap(Point p, int dx, int dy)
    {
        int nx = Mod(p.X + dx, Size);
        int ny = Mod(p.Y + dy, Size);
        return new Point(nx, ny);
    }

    private static int Mod(int value, int modulus)
    {
        var result = value % modulus;
        return result < 0 ? result + modulus : result;
    }
}
