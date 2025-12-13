namespace AdventOfCode2025.Advent;

static partial class MySolutions
{
    internal static int SolveDaySeven()
    {
        var splits = 0;
        var indexes = new HashSet<int>();

        using StreamReader sr = new StreamReader("Src/DaySeven.txt");

        indexes.Add(sr.ReadLine().IndexOf('S'));

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine()?.ToCharArray();

            foreach (var index in indexes.ToList())
            {
                if (line != null && line[index] == '^')
                {
                    indexes.Remove(index);
                    indexes.Add(index - 1);
                    indexes.Add(1 + index);
                    splits++;
                }
            }
        }

        return splits;
    }
}


