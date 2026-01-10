using Simulator;

namespace Simulator.Maps;

public interface IMappable
{
    Map? Map { get; set; }
    Point? Position { get; set; }
    void Go(Direction direction);
}
