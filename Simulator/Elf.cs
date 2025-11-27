using Simulator;

namespace Simulator.Creatures;

public class Elf : Creature
{
    private int _agility;
    private int _singCount;

    public int Agility
    {
        get => _agility;
        init => _agility = ClampStat(value);
    }

    public Elf()
    {
        _agility = ClampStat(1);
    }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        _agility = ClampStat(agility);
    }

    public void Sing()
    {
        _singCount++;
        if (_singCount % 3 == 0)
        {
            _agility = ClampStat(_agility + 1);
        }

        Console.WriteLine($"{Name} is singing.");
    }

    public override void SayHi() =>
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");

    public override int Power => 8 * Level + 2 * Agility;

    private static int ClampStat(int value) => Math.Clamp(value, 0, 10);
}
