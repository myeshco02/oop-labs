using Simulator;

namespace Simulator.Maps;

public interface IMappable
{
    Map? Map { get; set; }
    Point? Position { get; set; }
    char Symbol { get; }
    void Go(Direction direction);
    string ToString();
}
