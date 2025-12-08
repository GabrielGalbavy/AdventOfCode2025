namespace AdventOfCode2025.Advent;

static partial class MySolutions
{
    internal static long SolveDayTwo()
    {
        long sumOfBadIDs = 0;

        using (StreamReader sr = new StreamReader("Src/DayTwo.txt"))
        {
            var myIDs = new HashSet<string>(sr.ReadToEnd().Split(','));

            foreach (var myIdRange in myIDs)
            {
                var myRealId = myIdRange.Split('-');
                long.TryParse(myRealId[0], out long x);
                long.TryParse(myRealId[1], out long y);

                for (long i = x; i < y; i++)
                {
                    string myNumber = i.ToString();
                    string half = myNumber.Substring(0, myNumber.Length / 2);
                    string theOtherHalf = myNumber.Substring(
                        myNumber.Length / 2,
                        myNumber.Length - myNumber.Length / 2
                    );

                    if (half == theOtherHalf)
                    {
                        sumOfBadIDs += i;
                    }
                }
            }
        }

        return sumOfBadIDs; // 19391221415 too low
    }

    internal static long SolveDayTwoPlus()
    {
        long sumOfBadIDs = 0;

        using (StreamReader sr = new StreamReader("Src/DayTwo.txt"))
        {
            var myIDs = new HashSet<string>(sr.ReadToEnd().Split(','));

            foreach (var myIdRange in myIDs)
            {
                var myRealId = myIdRange.Split('-');
                long.TryParse(myRealId[0], out long x);
                long.TryParse(myRealId[1], out long y);

                for (long i = x; i < y; i++)
                {
                    string myNumber = i.ToString();
                    string tool = "";
                    foreach (var digit in myNumber)
                    {
                        string temp = myNumber;
                        tool += digit;
                        if (tool.Length > myNumber.Length / 2)
                        {
                            break;
                        }

                        if (temp.Replace(tool, String.Empty) == String.Empty)
                        {
                            sumOfBadIDs += i;
                            break;
                        }
                    }
                }
            }
        }

        return sumOfBadIDs; // 48631958998 too high
    }


    public static string ReverseString(string text)
        // used for Day 2 part 1 solution that I scraped, may come in handy later
    {
        char[] cArray = text.ToCharArray();
        string reverse = String.Empty;
        for (int i = cArray.Length - 1; i > -1; i--)
        {
            reverse += cArray[i];
        }

        return reverse;
    }
}