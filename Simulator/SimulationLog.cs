using System;
using System.Collections.Generic;

namespace Simulator;

public class SimulationLog
{
    private readonly Simulation _simulation;

    public int SizeX { get; }
    public int SizeY { get; }
    public List<TurnLog> TurnLogs { get; } = [];

    public SimulationLog(Simulation simulation)
    {
        _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        TurnLogs.Add(new TurnLog
        {
            Mappable = string.Empty,
            Move = string.Empty,
            Symbols = _simulation.Map.GetSymbols(),
        });

        while (!_simulation.Finished)
        {
            var mappable = _simulation.CurrentCreature.ToString();
            var move = _simulation.CurrentMoveName;
            _simulation.Turn();
            TurnLogs.Add(new TurnLog
            {
                Mappable = mappable,
                Move = move,
                Symbols = _simulation.Map.GetSymbols(),
            });
        }
    }
}

public class TurnLog
{
    public required string Mappable { get; init; }
    public required string Move { get; init; }
    public required Dictionary<Point, char> Symbols { get; init; }
}
