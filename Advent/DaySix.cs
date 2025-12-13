using System.ComponentModel.DataAnnotations;
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
        long result = 0;
        var linesInTheSand = new List<char[]?>();
        // last item are the operations 

        using StreamReader sr = new StreamReader("Src/DaySix.txt");

        for (var i = 0; i < 5; i++)
        {
            linesInTheSand.Add(
                sr
                    .ReadLine()?
                    .ToCharArray() ?? throw new InvalidOperationException());
        }

        var sets = ("", "", "", "", "");

        for (int i = linesInTheSand[0].Length - 1; i >= 0; i--)
        {
            sets.Item1 = linesInTheSand[0][i] + sets.Item1;
            sets.Item2 = linesInTheSand[1][i] + sets.Item2;
            sets.Item3 = linesInTheSand[2][i] + sets.Item3;
            sets.Item4 = linesInTheSand[3][i] + sets.Item4;
            sets.Item5 = linesInTheSand[4][i] + sets.Item5;


            if (linesInTheSand[4][i] == '*' || linesInTheSand[4][i] == '+')
            {
                var numbers = new List<long>();

                var maxLength = Math.Max(Math.Max(sets.Item1.Trim().Length, sets.Item2.Trim().Length),
                    Math.Max(sets.Item3.Trim().Length, sets.Item4.Trim().Length));

                Console.WriteLine(
                    sets.Item1 + " " + sets.Item2 + " " + sets.Item3 + " " + sets.Item4 + " " + sets.Item5);
                Console.WriteLine(maxLength);
                for (int j = 0; j < maxLength; j++)
                {
                    numbers.Add(long.Parse((sets.Item1[j].ToString() + sets.Item2[j].ToString() +
                                            sets.Item3[j].ToString() + sets.Item4[j].ToString())
                        .Trim()
                    ));
                }

                Console.WriteLine("numbers>>");
                foreach (var VARIABLE in numbers)
                {
                    Console.WriteLine(VARIABLE);
                }

                long localResult = 0;
                foreach (var number in numbers)
                {
                    if (sets.Item5.Contains('*'))
                    {
                        localResult *= number;
                        Console.WriteLine('*');
                    }
                    else if ((sets.Item5.Contains('+')))
                    {
                        localResult += number;
                        Console.WriteLine('+');
                    }
                }

                Console.WriteLine(localResult);
                result += localResult;
                sets = ("", "", "", "", "");
            }
        }

        return result;
    }
}