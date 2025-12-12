using Microsoft.VisualBasic.CompilerServices;
using static System.String;

namespace AdventOfCode2025.Advent;

static partial class MySolutions
{
    internal static long SolveDaySix()
    {
        var numSet = new List<(int, int, int, int, char)>();

        using (StreamReader sr = new StreamReader("Src/DaySix.txt"))
        {
            var linesInTheSand = new List<char[]>();
            for (int i = 0; i < 4; i++)
            {
                linesInTheSand.Add(sr.ReadLine().ToCharArray());
            }
            var operations = sr.ReadLine().Split(' ');
            foreach (var operation in operations)
            {
                
            }
        }

        return 0;
    }

    internal static long SolveDaySixPlus()
    {
        return 1;
    }
}