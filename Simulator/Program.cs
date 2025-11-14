using Simulator.Creatures;

namespace Simulator;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Starting Simulator!\n");

        var goblin = new Creature("Goblin");
        var troll = new Creature("Troll", 3);

        goblin.SayHi();
        Console.WriteLine(goblin.Info);

        troll.SayHi();
        Console.WriteLine(troll.Info);
    }
}
