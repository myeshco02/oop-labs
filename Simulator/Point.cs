namespace Simulator;


public readonly struct Point
{
    public readonly int X;
    public readonly int Y;

    public Point(int x, int y) => (X, Y) = (x, y);

    public Point Next(Direction direction) =>
        direction switch
        {
            Direction.Up => new Point(X, Y + 1),
            Direction.Right => new Point(X + 1, Y),
            Direction.Down => new Point(X, Y - 1),
            Direction.Left => new Point(X - 1, Y),
            _ => this,
        };

    public Point NextDiagonal(Direction direction) =>
        direction switch
        {
            Direction.Up => new Point(X + 1, Y + 1),
            Direction.Right => new Point(X + 1, Y - 1),
            Direction.Down => new Point(X - 1, Y - 1),
            Direction.Left => new Point(X - 1, Y + 1),
            _ => this,
        };

    public override string ToString() => $"({X}, {Y})";
}
