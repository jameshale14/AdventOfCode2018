using System;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = File.ReadAllText("C:\\Shed\\csharp\\AdventOfCode2018\\Day1\\Day1\\input.txt");

            Calc calc = new Calc();

            Console.WriteLine($"Frequency: {calc.GetFrequency(text)}");

            //Console.WriteLine(text);
        }
    }
}
