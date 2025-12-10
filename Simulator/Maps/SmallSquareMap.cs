using System;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public SmallSquareMap(int size)
        : base(size, size)
    {
        if (size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be at most 20.");
        }
    }

    public override Point Next(Point p, Direction d)
    {
        var candidate = p.Next(d);
        return Exist(candidate) ? candidate : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var candidate = p.NextDiagonal(d);
        return Exist(candidate) ? candidate : p;
    }
}
