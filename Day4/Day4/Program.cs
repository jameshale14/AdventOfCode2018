using System;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("../../../input.txt");

            SnoozeCatcher snoozeCatcher = new SnoozeCatcher();

            var part1 = snoozeCatcher.GetSnooziestGuard(input);
            var part2 = snoozeCatcher.GetSnooziestMinuteForOneGuard(input);

            Console.WriteLine($"Part 1: Guard ID { part1.guardID } x minute { part1.minute } = { part1.guardID * part1.minute}");

            Console.WriteLine($"Part 2: Guard ID { part2.guardID } x minute { part2.minute } = { part2.guardID * part2.minute}");
        }
    }
}
