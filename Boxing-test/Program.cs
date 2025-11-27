using System;
using System.Diagnostics;

int[] sizes = { 1_000_000, 10_000_000, 100_000_000 };

Console.WriteLine("Porównanie kopiowania tablic (typ prosty vs boxing)\n");

var random = new Random();

foreach (int size in sizes)
{
    Console.WriteLine($"Rozmiar danych: {size:N0} elementów");

    // Tworzymy i wypełniamy dane źródłowe tylko raz
    int[] source = CreateSourceData(size, random);

    TimeSpan intCopy = CopyToIntArray(source);
    TimeSpan objectCopy = CopyToObjectArray(source);

    Console.WriteLine($"  int[]   : {intCopy.TotalMilliseconds:F2} ms");
    Console.WriteLine($"  object[]: {objectCopy.TotalMilliseconds:F2} ms\n");

    GC.Collect();
    GC.WaitForPendingFinalizers();
}

static int[] CreateSourceData(int size, Random random)
{
    int[] data = new int[size];
    for (int i = 0; i < size; i++)
    {
        data[i] = random.Next();
    }

    return data;
}

static TimeSpan CopyToIntArray(int[] source)
{
    int[] destination = new int[source.Length];
    Stopwatch stopwatch = Stopwatch.StartNew();

    for (int i = 0; i < source.Length; i++)
    {
        destination[i] = source[i];
    }

    stopwatch.Stop();
    return stopwatch.Elapsed;
}

static TimeSpan CopyToObjectArray(int[] source)
{
    object[] destination = new object[source.Length];
    Stopwatch stopwatch = Stopwatch.StartNew();

    for (int i = 0; i < source.Length; i++)
    {
        destination[i] = source[i]; // boxing
    }

    stopwatch.Stop();
    return stopwatch.Elapsed;
}
