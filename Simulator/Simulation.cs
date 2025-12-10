using System;
using System.Collections.Generic;
using Simulator.Creatures;
using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves.
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves,
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature
    {
        get
        {
            if (Finished || _directions.Count == 0)
            {
                throw new InvalidOperationException("Simulation has finished or has no moves.");
            }

            var index = _currentMoveIndex % Creatures.Count;
            return Creatures[index];
        }
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            if (Finished || _directions.Count == 0)
            {
                throw new InvalidOperationException("Simulation has finished or has no moves.");
            }

            var direction = _directions[_currentMoveIndex];
            return direction.ToString().ToLowerInvariant();
        }
    }

    private readonly List<Direction> _directions;
    private int _currentMoveIndex;

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures ?? throw new ArgumentNullException(nameof(creatures));
        Positions = positions ?? throw new ArgumentNullException(nameof(positions));
        Moves = moves ?? throw new ArgumentNullException(nameof(moves));

        if (Creatures.Count == 0)
        {
            throw new ArgumentException("Creatures list cannot be empty.", nameof(creatures));
        }

        if (Creatures.Count != Positions.Count)
        {
            throw new ArgumentException("Number of creatures must match number of starting positions.", nameof(positions));
        }

        // Place creatures on the map at starting positions.
        for (var i = 0; i < Creatures.Count; i++)
        {
            var creature = Creatures[i];
            var position = Positions[i];
            Map.Add(creature, position);
        }

        _directions = DirectionParser.Parse(Moves);
        _currentMoveIndex = 0;

        if (_directions.Count == 0)
        {
            Finished = true;
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Simulation has already finished.");
        }

        var direction = _directions[_currentMoveIndex];
        var creatureIndex = _currentMoveIndex % Creatures.Count;
        var creature = Creatures[creatureIndex];

        creature.Go(direction);

        _currentMoveIndex++;
        if (_currentMoveIndex >= _directions.Count)
        {
            Finished = true;
        }
    }
}

