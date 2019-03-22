using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("../../../input.txt");

            BoxChecker boxChecker = new BoxChecker();

            Console.WriteLine($"Part 1: {boxChecker.GetCheckSum(text)}");

            Console.WriteLine($"Part 2 - common letters: {boxChecker.GetCommonLettersBetweenClosestBoxIDs(text)}");
        }
    }
}
