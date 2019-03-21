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
    }
}
