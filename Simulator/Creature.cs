using Simulator;

namespace Simulator.Creatures;

public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;

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

    public Creature()
    {
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public abstract void SayHi();

    public void Upgrade()
    {
        if (_level < 10)
        {
            _level++;
        }
    }

    public virtual string Info => $"{Name} [{Level}]";

    public abstract int Power { get; }

    public void Go(Direction direction)
    {
        var directionName = direction.ToString().ToLowerInvariant();
        Console.WriteLine($"{Name} goes {directionName}.");
    }

    public void Go(Direction[]? directions)
    {
        if (directions is null)
        {
            return;
        }

        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string? directions)
    {
        Go(DirectionParser.Parse(directions));
    }
}
