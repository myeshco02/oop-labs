namespace Simulator.Creatures;

public class Creature
{
    private string _name = "Unknown";
    private int _level = 1;

    public string Name
    {
        get => _name;
        init => _name = FormatLabel(value, 25);
    }

    public int Level
    {
        get => _level;
        init => _level = ClampLevel(value);
    }

    public Creature()
    {
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

    public void Upgrade()
    {
        if (_level < 10)
        {
            _level++;
        }
    }

    public string Info => $"{Name} [{Level}]";

    private static string FormatLabel(string? value, int maxLength)
    {
        var formatted = (value ?? string.Empty).Trim();

        if (formatted.Length > maxLength)
        {
            formatted = formatted[..maxLength].TrimEnd();
        }

        if (formatted.Length < 3)
        {
            formatted = formatted.PadRight(3, '#');
        }

        if (formatted.Length > 0 && char.IsLetter(formatted[0]) && char.IsLower(formatted[0]))
        {
            formatted = char.ToUpperInvariant(formatted[0]) + formatted[1..];
        }

        return formatted;
    }

    private static int ClampLevel(int value)
    {
        return Math.Clamp(value, 1, 10);
    }
}
