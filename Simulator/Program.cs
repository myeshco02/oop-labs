using Simulator.Creatures;

namespace Simulator;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Starting Simulator!\n");

        // Elf e = new() { Name = "Legolas", Level = 10 };
        Creature e = new("Elandor", 5, 10);
        Console.WriteLine(elf.getType());
        e.SayHi();
        e.Upgrade();
        Console.WriteLine(e.Info);
        
        ((Elf)e).Sing();
        // elf.Sing();


    }

}

