using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;

namespace AdventOfCode2025.Advent;

static partial class MySolutions
{
    internal static long SolveDayThree()
    {
        long outputPower = 0;

        using (StreamReader sr = new StreamReader("Src/DayThree.txt"))
        {
            string? bank;
            while ((bank = sr.ReadLine()) != null)
            {
                int first = 0;
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

    internal static double SolveDayThreePlus()
    {
        using StreamReader sr = new StreamReader("Src/DayThree.txt");
        double sum = 0;
        while (sr.ReadLine() is { } bank)
        {
            char[] bankArr = bank.ToCharArray();
            int selectedBatteryIndex = 0;
            double sequence = 0;

            for (int i = 12; i > 0; i--) // getting the 12 batteries
            {
                double largest = 0;
                for (int j = selectedBatteryIndex; j < bankArr.Length - i + 1; j++)
                {
                    int.TryParse(bankArr[j].ToString(), out int current);
                    if (current > largest)
                    {
                        largest = current;
                        selectedBatteryIndex = j;
                    }
                }

                sequence += largest * Math.Pow(10, i);
                bankArr[selectedBatteryIndex] = '_';
            }

            Console.WriteLine(string.Join("", bankArr) + " -> " + sequence / 10);
            sum += sequence / 10;
        }

        return sum;
    }
}