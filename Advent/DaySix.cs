using static System.String;

namespace AdventOfCode2025.Advent;

static partial class MySolutions
{
    internal static Int128 SolveDaySix()
    {
        Int128 result = 0;
        var linesInTheSand = new List<List<string>>();
        // last item are the operations 

        using StreamReader sr = new StreamReader("Src/DaySix.txt");

        for (var i = 0; i < 5; i++)
        {
            linesInTheSand.Add(
                sr
                .ReadLine()?
                .Split(" ")
                .ToList() ?? throw new InvalidOperationException());

            linesInTheSand[i].RemoveAll(x => x == Empty);
        }

        for (var i = 0; i < linesInTheSand[0].Count; i++)
        {
            var numbers = (
                long.Parse(linesInTheSand[0][i]), // if you use Int here the 
                long.Parse(linesInTheSand[1][i]), // value will exceed the limit
                long.Parse(linesInTheSand[2][i]),
                long.Parse(linesInTheSand[3][i])
            );

            switch (linesInTheSand[4][i])
            {
                case "+":
                    result +=
                        numbers.Item1
                        + numbers.Item2
                        + numbers.Item3
                        + numbers.Item4;
                    break;

                case "*":
                    result +=
                        numbers.Item1
                        * numbers.Item2
                        * numbers.Item3
                        * numbers.Item4;
                    break;
            }
        }

        return result;
    }

    internal static long SolveDaySixPlus()
    {
        return 1;
    }
}