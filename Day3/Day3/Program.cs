using System;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = File.ReadAllText("../../../input.txt");
            SuitMaterial suitMaterial = new SuitMaterial();

            Console.WriteLine($"Part 1 - Total overlapping area: {suitMaterial.GetOverLappingAreaFromClaims(input)}");

            Console.WriteLine($"Part 2 - Claim ID with no overlap: {suitMaterial.GetClaimThatHasNoOverlap(input)}");
        }
    }
}
