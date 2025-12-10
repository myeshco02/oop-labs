using System.Text;
using SimConsole;
using Simulator;
using Simulator.Creatures;
using Simulator.Maps;

Console.OutputEncoding = Encoding.UTF8;

SmallSquareMap map = new(5);
List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
List<Point> points = [new(2, 2), new(3, 1)];
string moves = "dlrludl";

Simulation simulation = new(map, creatures, points, moves);
MapVisualizer mapVisualizer = new(simulation.Map);

while (!simulation.Finished)
{
    Console.Clear();
    mapVisualizer.Draw();
    Console.WriteLine();
    Console.WriteLine($"Current: {simulation.CurrentCreature.Name} moves {simulation.CurrentMoveName}");

    Console.WriteLine("Press any key for next move...");
    Console.ReadKey(true);

    simulation.Turn();
}

Console.Clear();
mapVisualizer.Draw();
Console.WriteLine();
Console.WriteLine("Simulation finished.");
