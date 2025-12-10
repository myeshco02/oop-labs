using System.Collections.Generic;
using Simulator;
using Simulator.Creatures;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    private const int MinSize = 5;

    private readonly Dictionary<Point, List<Creature>> _creatures = new();

    public int SizeX { get; }
    public int SizeY { get; }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < MinSize)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), $"SizeX must be at least {MinSize}.");
        }

        if (sizeY < MinSize)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), $"SizeY must be at least {MinSize}.");
        }

        SizeX = sizeX;
        SizeY = sizeY;
    }

    /// <summary>
    /// Check if given point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    public virtual bool Exist(Point p) => p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;

    /// <summary>
    /// Add creature to the map at given position.
    /// </summary>
    public virtual void Add(Creature creature, Point position)
    {
        if (creature is null)
        {
            throw new ArgumentNullException(nameof(creature));
        }

        if (!Exist(position))
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position must be inside the map.");
        }

        if (creature.Map is not null && creature.Map != this)
        {
            throw new InvalidOperationException("Creature already belongs to another map.");
        }

        if (!_creatures.TryGetValue(position, out var creaturesAtPosition))
        {
            creaturesAtPosition = new List<Creature>();
            _creatures[position] = creaturesAtPosition;
        }

        if (!creaturesAtPosition.Contains(creature))
        {
            creaturesAtPosition.Add(creature);
        }

        creature.Map = this;
        creature.Position = position;
    }

    public void Add(Creature creature, int x, int y) => Add(creature, new Point(x, y));

    /// <summary>
    /// Remove creature from the map (if present).
    /// </summary>
    public virtual void Remove(Creature creature)
    {
        if (creature is null)
        {
            throw new ArgumentNullException(nameof(creature));
        }

        if (creature.Map != this || creature.Position is null)
        {
            return;
        }

        var position = creature.Position.Value;

        if (_creatures.TryGetValue(position, out var creaturesAtPosition))
        {
            creaturesAtPosition.Remove(creature);
            if (creaturesAtPosition.Count == 0)
            {
                _creatures.Remove(position);
            }
        }

        creature.Map = null;
        creature.Position = null;
    }

    /// <summary>
    /// Move creature between two positions.
    /// </summary>
    public virtual void Move(Creature creature, Point from, Point to)
    {
        if (creature is null)
        {
            throw new ArgumentNullException(nameof(creature));
        }

        if (creature.Map != this)
        {
            throw new InvalidOperationException("Creature does not belong to this map.");
        }

        if (!Exist(from))
        {
            throw new ArgumentOutOfRangeException(nameof(from), "Source position must be inside the map.");
        }

        if (!Exist(to))
        {
            throw new ArgumentOutOfRangeException(nameof(to), "Target position must be inside the map.");
        }

        if (from.Equals(to))
        {
            return;
        }

        if (_creatures.TryGetValue(from, out var fromList))
        {
            fromList.Remove(creature);
            if (fromList.Count == 0)
            {
                _creatures.Remove(from);
            }
        }

        if (!_creatures.TryGetValue(to, out var toList))
        {
            toList = new List<Creature>();
            _creatures[to] = toList;
        }

        if (!toList.Contains(creature))
        {
            toList.Add(creature);
        }

        creature.Position = to;
    }

    /// <summary>
    /// Creatures at given point.
    /// </summary>
    public IReadOnlyList<Creature> At(Point p)
    {
        if (_creatures.TryGetValue(p, out var creaturesAtPosition))
        {
            return creaturesAtPosition;
        }

        return Array.Empty<Creature>();
    }

    public IReadOnlyList<Creature> At(int x, int y) => At(new Point(x, y));

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}
