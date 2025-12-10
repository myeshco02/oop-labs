using Simulator.Creatures;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    public Map Map { get; }

    public MapVisualizer(Map map)
    {
        Map = map;
    }

    public void Draw()
    {
        int width = Map.SizeX;
        int height = Map.SizeY;

        // Top border
        Console.Write(Box.TopLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(Box.Horizontal);
        }

        Console.Write(Box.TopRight);
        Console.WriteLine();

        // Rows
        for (int y = height - 1; y >= 0; y--)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < width; x++)
            {
                var creatures = Map.At(x, y);
                char symbol = GetSymbol(creatures);
                Console.Write(symbol);
            }

            Console.Write(Box.Vertical);
            Console.WriteLine();
        }

        // Bottom border
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(Box.Horizontal);
        }

        Console.Write(Box.BottomRight);
        Console.WriteLine();
    }

    private static char GetSymbol(IReadOnlyList<Creature> creatures)
    {
        if (creatures.Count == 0)
        {
            return ' ';
        }

        if (creatures.Count > 1)
        {
            return 'X';
        }

        var creature = creatures[0];

        return creature switch
        {
            Orc => 'O',
            Elf => 'E',
            _ => '?',
        };
    }
}

