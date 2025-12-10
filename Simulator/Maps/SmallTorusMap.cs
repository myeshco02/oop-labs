using System;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    private const int MaxSize = 20;

    public SmallTorusMap(int sizeX, int sizeY)
        : base(sizeX, sizeY)
    {
        if (sizeX > MaxSize)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), $"SizeX must be at most {MaxSize}.");
        }

        if (sizeY > MaxSize)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), $"SizeY must be at most {MaxSize}.");
        }
    }

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
        int nx = Mod(p.X + dx, SizeX);
        int ny = Mod(p.Y + dy, SizeY);
        return new Point(nx, ny);
    }

    private static int Mod(int value, int modulus)
    {
        var result = value % modulus;
        return result < 0 ? result + modulus : result;
    }
}
