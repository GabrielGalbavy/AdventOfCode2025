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
            if (range != null)
            {
                lowerRange.Add(long.Parse(range[0]));
                upperRange.Add(long.Parse(range[1]));
            }
        }

        while (!sr.EndOfStream)
        {
            var ingredient = sr.ReadLine();
            long.TryParse(ingredient, out var number);
            for (int i = 0; i < lowerRange.Count; i++)
            {
                if (number >= lowerRange[i])
                {
                    if (number <= upperRange[i])
                    {
                        freshCounter++;
                        break; // due to overlapping ranges one ID can be in multiple ranges
                    }
                }
            }
        }

        return freshCounter;
    }

    internal static int SolveDayFivePlus()
    {
        return 1;
    }
}