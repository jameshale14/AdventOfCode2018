using NUnit.Framework;

namespace Day1.Tests
{
    public class Calc_GetFrequencyShould
    {
        private readonly Calc _calc;

        public Calc_GetFrequencyShould()
        {
            _calc = new Calc();
        }

        [TestCase("+123", 123)]
        [TestCase("+123\n-2", 121)]
        public void ReturnSummedUpResultsOfInput(string input, int frequency)
        {
            var result = _calc.GetFrequency(input);
            Assert.AreEqual(frequency, result);

        }
    }
}