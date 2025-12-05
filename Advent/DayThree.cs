namespace AdventOfCode2025.Advent;

partial class MySolutions
{
    public static long? SolveDayThree()
    {
        long? outputPower = 0;

        using (StreamReader sr = new StreamReader("Src/DayThree.txt"))
        {
            string? bank;
            while ((bank = sr.ReadLine()) != null)
            {
                int? first = 0;
                int second = 0;
                int index = 0;

                for (int i = 0; i < bank.Length - 1; i++)
                {
                    int.TryParse(bank[i].ToString(), out int batteryValue);
                    if (!(batteryValue > first)) continue;
                    first = batteryValue;
                    index = i;
                }

                for (int i = bank.Length - 1; i > index; i--)
                {
                    int.TryParse(bank[i].ToString(), out int batteryValue);
                    if (batteryValue > second) second = batteryValue;
                }

                outputPower += first * 10 + second;
            }
        }

        return outputPower;
    }

    public static int SolveDayThreePlus()
    {
        return 1;
    }
}