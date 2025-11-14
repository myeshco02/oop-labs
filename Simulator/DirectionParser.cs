namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return Array.Empty<Direction>();
        }

        var directions = new List<Direction>(input.Length);

        foreach (var ch in input)
        {
            var upper = char.ToUpperInvariant(ch);
            switch (upper)
            {
                case 'U':
                    directions.Add(Direction.Up);
                    break;
                case 'R':
                    directions.Add(Direction.Right);
                    break;
                case 'D':
                    directions.Add(Direction.Down);
                    break;
                case 'L':
                    directions.Add(Direction.Left);
                    break;
            }
        }

        return directions.ToArray();
    }
}
