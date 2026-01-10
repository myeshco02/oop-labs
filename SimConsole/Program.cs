using System.Text;
using SimConsole;
using Simulator;
using Simulator.Creatures;
using Simulator.Maps;

Console.OutputEncoding = Encoding.UTF8;

var selection = PromptSelection();
switch (selection)
{
    case 1:
        Sim1();
        break;
    case 2:
        Sim2();
        break;
    case 3:
        Sim3();
        break;
}

int PromptSelection()
{
    while (true)
    {
        Console.WriteLine("Select simulation:");
        Console.WriteLine("1 - Sim1");
        Console.WriteLine("2 - Sim2");
        Console.WriteLine("3 - Sim3");
        Console.Write("Choice: ");
        var input = Console.ReadLine()?.Trim();
        if (input == "1" || input == "2" || input == "3")
        {
            Console.Clear();
            return input == "1" ? 1 : input == "2" ? 2 : 3;
        }

        Console.WriteLine("Invalid choice. Try again.");
        Console.WriteLine();
    }
}

void Sim1()
{
    SmallSquareMap map = new(5);
    List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
    List<Point> points = [new(2, 2), new(3, 1)];
    string moves = "dlrludl";

    RunSimulation(new Simulation(map, creatures, points, moves));
}

void Sim2()
{
    RunSimulation(BuildSim2());
}

void Sim3()
{
    var log = new SimulationLog(BuildSim2());
    LogVisualizer visualizer = new(log);
    int[] turns = { 5, 10, 15, 20 };

    foreach (var turnIndex in turns)
    {
        Console.Clear();
        visualizer.Draw(turnIndex);
        Console.WriteLine();
        var turn = log.TurnLogs[turnIndex];
        Console.WriteLine($"Turn {turnIndex}: {turn.Mappable} moves {turn.Move}");
        Console.WriteLine("Press any key for next view...");
        Console.ReadKey(true);
    }
}

Simulation BuildSim2()
{
    SmallTorusMap map = new(8, 6);
    IMappable elf = new Elf("Elandor");
    IMappable orc = new Orc("Gorbag");
    IMappable rabbits = new Animals { Description = "Rabbits", Size = 12 };
    IMappable eagles = new Birds { Description = "Eagles", Size = 4, CanFly = true };
    IMappable ostriches = new Birds { Description = "Ostriches", Size = 6, CanFly = false };

    List<IMappable> creatures = [elf, orc, rabbits, eagles, ostriches];
    List<Point> points = [new(1, 1), new(2, 4), new(4, 1), new(6, 5), new(7, 2)];
    string moves = "urdlurrdlludrdluuldr";

    return new Simulation(map, creatures, points, moves);
}

void RunSimulation(Simulation simulation)
{
    MapVisualizer mapVisualizer = new(simulation.Map);

    while (!simulation.Finished)
    {
        Console.Clear();
        mapVisualizer.Draw();
        Console.WriteLine();
        var current = simulation.CurrentCreature;
        Console.WriteLine($"Current: {current} moves {simulation.CurrentMoveName}");

        Console.WriteLine("Press any key for next move...");
        Console.ReadKey(true);

        simulation.Turn();
    }

    Console.Clear();
    mapVisualizer.Draw();
    Console.WriteLine();
    Console.WriteLine("Simulation finished.");
}
