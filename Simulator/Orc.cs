namespace Simulator;

// internal - widoczna tylko w tym samym projekcie
// public - widoczna wszędzie
// private - widoczna tylko w tej samej klasie

public class Orc : Creature
{
    public int Rage { get; set; } = 1;
    public void Hunt() => Console.WriteLine($"{Name} is hunting."); 

    public Orc (string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }
}

