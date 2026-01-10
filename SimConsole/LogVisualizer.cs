using Simulator;

namespace SimConsole;

internal class LogVisualizer
{
    public SimulationLog Log { get; }

    public LogVisualizer(SimulationLog log)
    {
        Log = log ?? throw new ArgumentNullException(nameof(log));
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= Log.TurnLogs.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(turnIndex));
        }

        int width = Log.SizeX;
        int height = Log.SizeY;
        var symbols = Log.TurnLogs[turnIndex].Symbols;

        Console.Write(Box.TopLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(Box.Horizontal);
        }

        Console.Write(Box.TopRight);
        Console.WriteLine();

        for (int y = height - 1; y >= 0; y--)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < width; x++)
            {
                var point = new Point(x, y);
                char symbol = symbols.TryGetValue(point, out var value) ? value : ' ';
                Console.Write(symbol);
            }

            Console.Write(Box.Vertical);
            Console.WriteLine();
        }

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(Box.Horizontal);
        }

        Console.Write(Box.BottomRight);
        Console.WriteLine();
    }
}
