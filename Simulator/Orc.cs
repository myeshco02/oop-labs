using Simulator;

namespace Simulator.Creatures;

public class Orc : Creature
{
    private int _rage;
    private int _huntCount;

    public int Rage
    {
        get => _rage;
        init => _rage = ClampStat(value);
    }

    public Orc()
    {
        _rage = ClampStat(1);
    }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        _rage = ClampStat(rage);
    }

    public void Hunt()
    {
        _huntCount++;
        if (_huntCount % 2 == 0)
        {
            _rage = ClampStat(_rage + 1);
        }

        Console.WriteLine($"{Name} is hunting.");
    }

    public override void SayHi() =>
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");

    public override int Power => 7 * Level + 3 * Rage;

    private static int ClampStat(int value) => Validator.Limiter(value, 0, 10);
}
