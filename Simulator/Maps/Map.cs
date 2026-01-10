using System.Collections.Generic;
using Simulator;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    private const int MinSize = 5;

    private readonly Dictionary<Point, List<IMappable>> _mappables = new();

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
    /// Add object to the map at given position.
    /// </summary>
    public virtual void Add(IMappable mappable, Point position)
    {
        if (mappable is null)
        {
            throw new ArgumentNullException(nameof(mappable));
        }

        if (!Exist(position))
        {
            throw new ArgumentOutOfRangeException(nameof(position), "Position must be inside the map.");
        }

        if (mappable.Map is not null && mappable.Map != this)
        {
            throw new InvalidOperationException("Object already belongs to another map.");
        }

        if (!_mappables.TryGetValue(position, out var mappablesAtPosition))
        {
            mappablesAtPosition = new List<IMappable>();
            _mappables[position] = mappablesAtPosition;
        }

        if (!mappablesAtPosition.Contains(mappable))
        {
            mappablesAtPosition.Add(mappable);
        }

        mappable.Map = this;
        mappable.Position = position;
    }

    public void Add(IMappable mappable, int x, int y) => Add(mappable, new Point(x, y));

    /// <summary>
    /// Remove object from the map (if present).
    /// </summary>
    public virtual void Remove(IMappable mappable)
    {
        if (mappable is null)
        {
            throw new ArgumentNullException(nameof(mappable));
        }

        if (mappable.Map != this || mappable.Position is null)
        {
            return;
        }

        var position = mappable.Position.Value;

        if (_mappables.TryGetValue(position, out var mappablesAtPosition))
        {
            mappablesAtPosition.Remove(mappable);
            if (mappablesAtPosition.Count == 0)
            {
                _mappables.Remove(position);
            }
        }

        mappable.Map = null;
        mappable.Position = null;
    }

    /// <summary>
    /// Move object between two positions.
    /// </summary>
    public virtual void Move(IMappable mappable, Point from, Point to)
    {
        if (mappable is null)
        {
            throw new ArgumentNullException(nameof(mappable));
        }

        if (mappable.Map != this)
        {
            throw new InvalidOperationException("Object does not belong to this map.");
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

        if (_mappables.TryGetValue(from, out var fromList))
        {
            fromList.Remove(mappable);
            if (fromList.Count == 0)
            {
                _mappables.Remove(from);
            }
        }

        if (!_mappables.TryGetValue(to, out var toList))
        {
            toList = new List<IMappable>();
            _mappables[to] = toList;
        }

        if (!toList.Contains(mappable))
        {
            toList.Add(mappable);
        }

        mappable.Position = to;
    }

    /// <summary>
    /// Objects at given point.
    /// </summary>
    public IReadOnlyList<IMappable> At(Point p)
    {
        if (_mappables.TryGetValue(p, out var mappablesAtPosition))
        {
            return mappablesAtPosition;
        }

        return Array.Empty<IMappable>();
    }

    public IReadOnlyList<IMappable> At(int x, int y) => At(new Point(x, y));

    public Dictionary<Point, char> GetSymbols()
    {
        var symbols = new Dictionary<Point, char>();
        foreach (var (point, mappables) in _mappables)
        {
            if (mappables.Count == 0)
            {
                continue;
            }

            symbols[point] = mappables.Count > 1 ? 'X' : mappables[0].Symbol;
        }

        return symbols;
    }

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
