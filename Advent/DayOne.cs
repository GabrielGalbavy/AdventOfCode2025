namespace AdventOfCode2025.Advent;

static partial class MySolutions
{
    internal static int SolveDayOne()
    {
        var number = 50;
        var pointingZero = 0;
        using (StreamReader sr = new StreamReader("Src/DayOne.txt"))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                int.TryParse(line.Remove(0, 1), out int shift);
                shift %= 100;
                switch (line[0])
                {
                    case 'R': // +
                        number = (number + shift) % 100;

                        break;
                    case 'L':
                        if (number - shift < 0)
                        {
                            number = 100 + ((number - shift) % 100);
                        }
                        else
                        {
                            number -= shift;
                        }

                        break;
                }

                if (number == 0)
                {
                    pointingZero++;
                }
            }
        }

        return pointingZero;
    }

    internal static int SolveDayOnePlus()
    {
        int number = 50;
        int passingZero = 0;
        using (StreamReader sr = new StreamReader("Src/DayOne.txt"))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                int.TryParse(line.Remove(0, 1), out int shift);

                if (line[0] == 'R')
                {
                    do
                    {
                        number++;
                        if (number == 100)
                        {
                            number = 0;
                            passingZero++;
                        }

                        shift--;
                    } while (shift != 0);
                }
                else
                {
                    do
                    {
                        number--;
                        if (number == -1)
                        {
                            passingZero++;
                            number = 99;
                        }

                        shift--;
                    } while (shift != 0);
                }
            }
        }

        return passingZero; // 6392 too much
    }
}