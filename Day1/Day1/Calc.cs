using System;
using System.Collections.Generic;
using System.Text;

namespace Day1
{
    public class Calc
    {
        public int GetFrequency(string input)
        {
            string[] splitInput = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

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
            string[] splitInput = input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            int frequency = 0;

            List<int> frequencyList = new List<int> { 0 };
            bool repeatedFrequencyFound = false;
            int firstRepeatedFrequency = 0;
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
                        repeatedFrequencyFound = true;
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