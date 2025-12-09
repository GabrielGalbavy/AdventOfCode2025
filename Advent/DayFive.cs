using System.Collections;
using System.Collections.Immutable;

namespace AdventOfCode2025.Advent;

public partial class MySolutions
{
    internal static long SolveDayFive()
    {
        var lowerRange = new List<long>();
        var upperRange = new List<long>();
        long freshCounter = 0;

        var sr = new StreamReader("Src/DayFive.txt");
        string? line;

        while ((line = sr.ReadLine()) != string.Empty)
        {
            var range = line?.Split('-');
            if (range == null) continue;
            lowerRange.Add(long.Parse(range[0]));
            upperRange.Add(long.Parse(range[1]));
        }

        while (!sr.EndOfStream)
        {
            var ingredient = sr.ReadLine();
            long.TryParse(ingredient, out var number);

            if (lowerRange.Where((t, i) => number >= t && number <= upperRange[i]).Any()) freshCounter++;
        }

        return freshCounter;
    }

    internal static long SolveDayFivePlus()
    {
        var sr = new StreamReader("Src/DayFive.txt");
        string? line;
        var ranges = new List<(long, long)>();

        while ((line = sr.ReadLine()) != string.Empty)
        {
            var set = line?.Split('-');
            long.TryParse(set?[0], out var lowerRange);
            long.TryParse(set?[1], out var upperRange);
            ranges.Add((lowerRange, upperRange));
        }

        ranges.Sort((a, b) => a.Item1.CompareTo(b.Item1));

        long validIDs = 0;
        long start = 0;
        long stop = 0;

        var rangesOtp = new List<(long, long)>();


        foreach (var range in ranges)
        {
            if (start == 0 && stop == 0)
            {
                start = range.Item1;
                stop = range.Item2;
            }
            else
            {
                if (stop >= range.Item1)
                {
                    if(range.Item2 > stop)
                        stop = range.Item2;
                        
                }
                else
                {
                    rangesOtp.Add((start, stop));
                    start = range.Item1;
                    stop = range.Item2;
                }
            }
        }

        foreach (var range in rangesOtp)
        {
            validIDs += range.Item2 - range.Item1 + 1;
        }

        foreach (var range in ranges)
        {
            Console.WriteLine(range.Item1 + "-" + range.Item2);
        }
        Console.WriteLine("---------------");
        foreach (var range in rangesOtp)
        {
            Console.WriteLine(range.Item1 + "-" + range.Item2);
        }
        
        return validIDs; // 338259225765483 too low
    }
}