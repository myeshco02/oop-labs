using Simulator;

namespace Simulator.Creatures;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public override char Symbol => CanFly ? 'B' : 'b';

    public override void Go(Direction direction)
    {
        if (Map is null || Position is null)
        {
            return;
        }

        var current = Position.Value;
        Point next;

        if (CanFly)
        {
            var first = Map.Next(current, direction);
            next = Map.Next(first, direction);
        }
        else
        {
            next = Map.NextDiagonal(current, direction);
        }

        if (!next.Equals(current))
        {
            Map.Move(this, current, next);
        }
    }

    public override string Info
    {
        get
        {
            var flyMark = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyMark}) <{Size}>";
        }
    }
}
