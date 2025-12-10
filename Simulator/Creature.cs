using Simulator;
using Simulator.Maps;

namespace Simulator.Creatures;

public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;
    private Map? _map;
    private Point? _position;

    public string Name
    {
        get => _name;
        init => _name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => _level;
        init => _level = Validator.Limiter(value, 1, 10);
    }

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

    public Creature()
    {
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public abstract string Greeting();

    public void Upgrade()
    {
        if (_level < 10)
        {
            _level++;
        }
    }

    public abstract int Power { get; }
    public abstract string Info { get; }

    /// <summary>
    /// Place creature on a map in a given position.
    /// </summary>
    public void PlaceOnMap(Map map, Point position)
    {
        if (map is null)
        {
            throw new ArgumentNullException(nameof(map));
        }

        map.Add(this, position);
    }

    /// <summary>
    /// Move creature according to direction on the current map.
    /// </summary>
    public void Go(Direction direction)
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

    public override string ToString()
    {
        var typeName = GetType().Name.ToUpperInvariant();
        return $"{typeName}: {Info}";
    }
}
