namespace AdventOfCode2025.Advent;

static partial class MySolutions
{
    internal static int SolveDayFour()
    {
        // for this solution to work you must first surround the input text block in dots,
        // so you don't read characters outside the input
        //
        //   x........      the x is a marking of the first line > solution plus
        //   .@@.@.@@.      
        //   .@@@@@@@.
        //   ...@.@...      example
        //   .@@.@.@..      hold scroll wheel for selecting 
        //   .........      multiple lines to write the dots

        int freeRows = 0;
        using StreamReader sr = new StreamReader("Src/DayFour.txt");
        char[]?[] jaggedRowArray =
        {
            String.Empty.ToCharArray(),
            sr.ReadLine()?.ToCharArray(),
            sr.ReadLine()?.ToCharArray(),
        };
        while (!sr.EndOfStream)
        {
            jaggedRowArray[0] = jaggedRowArray[1];
            jaggedRowArray[1] = jaggedRowArray[2]; // epic queue 
            jaggedRowArray[2] = sr.ReadLine()?.ToCharArray();

            for (int i = 0; i < jaggedRowArray[1]!.Length; i++)
            {
                var surrounding = new List<char>();
                if (jaggedRowArray[1]![i] == '@')
                {
                    surrounding.Add(jaggedRowArray[0]![i - 1]);
                    surrounding.Add(jaggedRowArray[0]![i]); // lamest solution this season
                    surrounding.Add(jaggedRowArray[0]![i + 1]);

                    surrounding.Add(jaggedRowArray[1]![i - 1]);
                    surrounding.Add(jaggedRowArray[1]![i + 1]);

                    surrounding.Add(jaggedRowArray[2]![i - 1]);
                    surrounding.Add(jaggedRowArray[2]![i]);
                    surrounding.Add(jaggedRowArray[2]![i + 1]);
                    int counter = 0;
                    foreach (var character in surrounding)
                    {
                        if (character == '@')
                        {
                            counter++;
                        }
                    }

                    if (counter < 4)
                    {
                        freeRows++;
                    }
                }
            }
        }


        return freeRows;
    }

    internal static long SolveDayFourPlus()
    {
        using StreamReader sr = new StreamReader("Src/DayFour.txt");
        var firstToTheKey = new List<char[]>(); //
        var firstToTheEgg = new List<char[]>(); // elite ball knowledge reference here 
        long freeRows = 0;
        long freeRowsLast = -1;

        // IDE is screaming here to check for null,
        // but we don't give a damn cuz we know it can't be null
        // we are smarter

        while (!sr.EndOfStream)
        {
            firstToTheKey.Add(sr.ReadLine()?.ToCharArray());
        }

        firstToTheEgg = firstToTheKey;


        while (freeRows != freeRowsLast)
        {
            firstToTheKey = firstToTheEgg;
            freeRowsLast = freeRows;
            int currentLine = 0;
            foreach (var line in firstToTheKey)
            {
                if (line.First() == 'x')
                {
                    currentLine++;
                    continue;
                }

                for (int i = 0; i < firstToTheKey[currentLine].Length; i++)
                {
                    var surrounding = new List<char>();
                    if (firstToTheKey[currentLine][i] == '@')
                    {
                        surrounding.Add(firstToTheKey[currentLine - 1][i - 1]);
                        surrounding.Add(firstToTheKey[currentLine - 1][i]); // lamest solution this season again
                        surrounding.Add(firstToTheKey[currentLine - 1][i + 1]);

                        surrounding.Add(firstToTheKey[currentLine][i - 1]);
                        surrounding.Add(firstToTheKey[currentLine][i + 1]);

                        surrounding.Add(firstToTheKey[currentLine + 1][i - 1]);
                        surrounding.Add(firstToTheKey[currentLine + 1][i]);
                        surrounding.Add(firstToTheKey[currentLine + 1][i + 1]);
                        int counter = 0;
                        foreach (var character in surrounding)
                        {
                            if (character == '@')
                            {
                                counter++;
                            }
                        }

                        if (counter < 4)
                        {
                            firstToTheEgg[currentLine][i] = '.';
                            freeRows += 1;
                        }
                    }
                }

                currentLine++;
            }
        }


        return freeRows;
    }
}