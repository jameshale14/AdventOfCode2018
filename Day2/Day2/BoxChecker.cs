using System;
using System.Collections.Generic;
using System.Text;

namespace Day2
{
    public class BoxChecker
    {
        public int GetCheckSum(string input)
        {

            string[] boxIDs = input.Split(new String[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            int countOfBoxIDsWithThreeLetters = 0;
            int countOfBoxIDsWithTwoLetters = 0;

            foreach ( string boxID in boxIDs)
            {
                bool containsExactlyTwoOfALetter = false;
                bool containsExactlyThreeOfALetter = false;

                for (int i = 0; i < boxID.Length; i++)
                {
                    int occurrences = CountStringOccurrences(boxID, boxID.Substring(i, 1));
                    
                    if ( !containsExactlyThreeOfALetter && occurrences == 3)
                    {
                        containsExactlyThreeOfALetter = true;
                        countOfBoxIDsWithThreeLetters++;

                    } else if ( !containsExactlyTwoOfALetter && occurrences == 2)
                    {
                        containsExactlyTwoOfALetter = true;
                        countOfBoxIDsWithTwoLetters++;
                    }
                }
            }

            return countOfBoxIDsWithTwoLetters * countOfBoxIDsWithThreeLetters;
        }

        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
    }
}
