using Simulator;
using Simulator.Maps;

namespace Simulator.Creatures;

public class Animals : IMappable
{
    private string _description = "Unknown";
    private Map? _map;
    private Point? _position;

    public string Description
    {
        get => _description;
        init => _description = Validator.Shortener(value, 3, 15, '#');
    }

    public uint Size { get; set; } = 3;

    public Map? Map
    {
        get => _map;
        internal set => _map = value;
    }

    public Point? Position
    {
        get => _position;
        internal set => _position = value;
    }

    Map? IMappable.Map
    {
        get => Map;
        set => Map = value;
    }

    Point? IMappable.Position
    {
        get => Position;
        set => Position = value;
    }

    public virtual char Symbol => 'A';

    public virtual void Go(Direction direction)
    {
        if (Map is null || Position is null)
        {
            return;
        }

        var current = Position.Value;
        var next = Map.Next(current, direction);

        if (!next.Equals(current))
        {
            Map.Move(this, current, next);
        }
    }

    public virtual string Info => $"{Description} <{Size}>";

    public override string ToString()
    {
        var typeName = GetType().Name.ToUpperInvariant();
        return $"{typeName}: {Info}";
    }

}
