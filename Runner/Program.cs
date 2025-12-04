using Simulator;
using Simulator.Creatures;

Console.WriteLine("Starting Simulator!\n");

TestCreatures();
Console.WriteLine();
TestDirections();
Console.WriteLine();
TestElfsAndOrcs();
Console.WriteLine();
TestValidators();
Console.WriteLine();
TestObjectsToString();

void TestCreatures()
{
    Creature c = new Orc() { Name = "   Shrek    ", Level = 20 };
    Console.WriteLine(c.Greeting());
    c.Upgrade();
    Console.WriteLine(c.Info);

    c = new Orc("  ", -5);
    Console.WriteLine(c.Greeting());
    c.Upgrade();
    Console.WriteLine(c.Info);

    c = new Orc("  donkey ") { Level = 7 };
    Console.WriteLine(c.Greeting());
    c.Upgrade();
    Console.WriteLine(c.Info);

    c = new Orc("Puss in Boots – a clever and brave cat.");
    Console.WriteLine(c.Greeting());
    c.Upgrade();
    Console.WriteLine(c.Info);

    c = new Orc("a                            troll name", 5);
    Console.WriteLine(c.Greeting());
    c.Upgrade();
    Console.WriteLine(c.Info);

    var a = new Animals() { Description = "   Cats " };
    Console.WriteLine(a.Info);

    a = new() { Description = "Mice           are great", Size = 40 };
    Console.WriteLine(a.Info);
}

void TestDirections()
{
    Creature c = new Orc("Shrek", 7);
    Console.WriteLine(c.Greeting());

    Console.WriteLine("\n* Up");
    var step = c.Go(Direction.Up);
    Console.WriteLine($"{c.Name} goes {step}.");

    Console.WriteLine("\n* Right, Left, Left, Down");
    Direction[] directions =
    {
        Direction.Right, Direction.Left, Direction.Left, Direction.Down,
    };
    var steps = c.Go(directions);
    foreach (var s in steps)
    {
        Console.WriteLine($"{c.Name} goes {s}.");
    }

    Console.WriteLine("\n* LRL");
    steps = c.Go("LRL");
    foreach (var s in steps)
    {
        Console.WriteLine($"{c.Name} goes {s}.");
    }

    Console.WriteLine("\n* xxxdR lyyLTyu");
    steps = c.Go("xxxdR lyyLTyu");
    foreach (var s in steps)
    {
        Console.WriteLine($"{c.Name} goes {s}.");
    }
}

void TestElfsAndOrcs()
{
    Console.WriteLine("HUNT TEST\n");
    var o = new Orc() { Name = "Gorbag", Rage = 7 };
    Console.WriteLine(o.Greeting());
    for (int i = 0; i < 10; i++)
    {
        o.Hunt();
        Console.WriteLine(o.Greeting());
    }

    Console.WriteLine("\nSING TEST\n");
    var e = new Elf("Legolas", agility: 2);
    Console.WriteLine(e.Greeting());
    for (int i = 0; i < 10; i++)
    {
        e.Sing();
        Console.WriteLine(e.Greeting());
    }

    Console.WriteLine("\nPOWER TEST\n");
    Creature[] creatures =
    {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3),
    };
    foreach (Creature creature in creatures)
    {
        Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
    }
}

void TestValidators()
{
    Creature c = new Orc() { Name = "   Shrek    ", Level = 20 };
    Console.WriteLine(c.Greeting());
    c.Upgrade();
    Console.WriteLine(c.Info);

    c = new Orc("  ", -5);
    Console.WriteLine(c.Greeting());
    c.Upgrade();
    Console.WriteLine(c.Info);

    c = new Orc("  donkey ") { Level = 7 };
    Console.WriteLine(c.Greeting());
    c.Upgrade();
    Console.WriteLine(c.Info);

    c = new Orc("Puss in Boots – a clever and brave cat.");
    Console.WriteLine(c.Greeting());
    c.Upgrade();
    Console.WriteLine(c.Info);

    c = new Orc("a                            troll name", 5);
    Console.WriteLine(c.Greeting());
    c.Upgrade();
    Console.WriteLine(c.Info);

    var a = new Animals() { Description = "   Cats " };
    Console.WriteLine(a.Info);

    a = new() { Description = "Mice           are great", Size = 40 };
    Console.WriteLine(a.Info);
}

void TestObjectsToString()
{
    object[] myObjects =
    {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4),
    };
    Console.WriteLine("\nMy objects:");
    foreach (var o in myObjects) Console.WriteLine(o);
}
