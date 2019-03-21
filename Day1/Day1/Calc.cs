using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    public class Calc
    {
        public int GetFrequency(string input)
        {
            //Split the input into an array of numbers (strings at this point, we still need the plus or minus)
            string[] splitInput = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Add each frequency change to the overall frequency
            int frequency = 0;
            foreach( string s in splitInput)
            {
                switch(s.Substring(0,1))
                {
                    case "+":
                        frequency += Int32.Parse(s.Substring(1));
                        break;
                    case "-":
                        frequency -= Int32.Parse(s.Substring(1));
                        break;
                }
            }

            return frequency;
        }

        public int GetFirstRepeatedFrequency(string input)
        {
            //Split the input into an array of numbers (strings at this point, we still need the plus or minus)
            string[] splitInput = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            int frequency = 0;


            // Add each frequency change to the overall frequency
            // Keep a record of each frequency in the list so far

            List<int> frequencyList = new List<int> { 0 };
            bool repeatedFrequencyFound = false;
            int firstRepeatedFrequency = 0;

            // We might not get a repeated frequency the first time around, 
            // so we'll repeat over the sequence, using the end frequency 
            // from the last go round
            while (repeatedFrequencyFound == false)
            {
                foreach (string s in splitInput)
                {
                    switch (s.Substring(0, 1))
                    {
                        case "+":
                            frequency += Int32.Parse(s.Substring(1));
                            break;
                        case "-":
                            frequency -= Int32.Parse(s.Substring(1));
                            break;
                    }
                    if (!repeatedFrequencyFound && frequencyList.Contains(frequency))
                    {
                        repeatedFrequencyFound = true; //break the while loop here
                        firstRepeatedFrequency = frequency;
                    }
                    else if (!repeatedFrequencyFound && !frequencyList.Contains(frequency))
                    {
                        frequencyList.Add(frequency);
                    }
                }
            }

            return firstRepeatedFrequency;
        }
    }
}