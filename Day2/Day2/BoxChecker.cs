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

        public string GetCommonLettersBetweenClosestBoxIDs(string input)
        {
            string[] boxIDs = input.Split(new String[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            // For each box ID, check the letters of the other box IDs
            // If we get a pair of letters that only have one different letter, then these are our match, 
            // so we should return the common letters from these two
            string matchingId1 = "";
            string matchingId2 = "";
            for (int i = 0; i < boxIDs.Length; i++)
            {
                if (matchingId1 == "" && matchingId2 == "")
                {
                    //don't check against the current index, or any before it,
                    // because they should have already been compared to all of the entries
                    for (int j = i + 1; j < boxIDs.Length; j++)
                    {
                        //compare the letters of boxIDs at positions i and j
                        int differentLettersCount = 0;

                        for (int k = 0; k < boxIDs[i].Length; k++)
                        {
                            if (boxIDs[i].Substring(k, 1) != boxIDs[j].Substring(k, 1))
                            {
                                differentLettersCount++;
                            }
                        }

                        if (differentLettersCount == 1)
                        {
                            matchingId1 = boxIDs[i];
                            matchingId2 = boxIDs[j];
                        }

                    }
                }
            }

            //Get the common letters between the two matching IDs
            string commonLetters = "";
            for (int i = 0; i < matchingId1.Length; i++)
            {
                if (matchingId1.Substring(i,1) == matchingId2.Substring(i,1))
                {
                    commonLetters = commonLetters + matchingId1.Substring(i, 1);
                }
            }

            return commonLetters;
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
