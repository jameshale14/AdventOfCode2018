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

            Console.WriteLine($"Part 1: { part1.guardID } x { part1.minute } = { part1.guardID * part1.minute} ");
        }
    }
}
