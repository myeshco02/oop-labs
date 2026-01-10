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
                var mappables = Map.At(x, y);
                char symbol = GetSymbol(mappables);
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

    private static char GetSymbol(IReadOnlyList<IMappable> mappables)
    {
        if (mappables.Count == 0)
        {
            return ' ';
        }

        if (mappables.Count > 1)
        {
            return 'X';
        }

        var mappable = mappables[0];

        return mappable.Symbol;
    }
}
