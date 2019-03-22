using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Day3
{
    public class SuitMaterial
    {

        public int GetOverLappingAreaFromClaims(string claims)
        {   
            string[] claimsArray = claims.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);

            // each claim in the array has a format of '#1 @ 906,735: 28x17'
            // for each of these claims, make a list of the "squares" that make it up

            List<List<string>> coordinatesOfAllRectangles = new List<List<string>>();

            Dictionary<string, int> fabric = new Dictionary<string, int>();

            List<string> overlap = new List<string>();
            List<string> nonOverlap = new List<string>();
            String coords = "";

            for (int i = 0; i < claimsArray.Length; i++)
            {
                List<string> coordinatesForSingleClaim = new List<string>();

                //parse the claim
                var r = new Regex(@"#\d+ @ (\d+),(\d+): (\d+)x(\d+)$");
                var match = r.Match(claimsArray[i]);
                int startingX = Int32.Parse(match.Groups[1].Value);
                int startingY = Int32.Parse(match.Groups[2].Value);
                int rectangleWidth = Int32.Parse(match.Groups[3].Value);
                int rectangleHeight = Int32.Parse(match.Groups[4].Value);

                for (int j = startingX; j < startingX + rectangleWidth; j++)
                {
                    for (int k = startingY; k < startingY + rectangleHeight; k++)
                    {
                        coords = $"{j},{k}";

                        if (fabric.TryGetValue(coords, out int blue))
                        {
                            fabric[coords]++;
                        }
                        else
                        {
                            fabric.Add(coords, 1);
                        }
                    }
                }
            }

            // count up the number of fabric squares with overlap (value > 1)

            var count = 0;
            foreach( var kvp in fabric)
            {
                if (kvp.Value > 1)
                {
                    count++;
                }
            }

            return count;
        }

    }
}
