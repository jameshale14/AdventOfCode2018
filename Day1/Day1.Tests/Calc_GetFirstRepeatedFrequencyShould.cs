using NUnit.Framework;

namespace Day1.Tests
{
    class Calc_GetFirstRepeatedFrequencyShould
    {
        private readonly Calc _calc;

        public Calc_GetFirstRepeatedFrequencyShould()
        {
            _calc = new Calc();
        }

        [TestCase("+123\n-123", 0)]
        [TestCase("+123\n-12\n+12", 123)]
        [TestCase("+7\n-3\n+4\n-5", 7)]
        public void ReturnFirstRepeatedFrequency(string input, int frequency)
        {
            var result = _calc.GetFirstRepeatedFrequency(input);
            Assert.AreEqual(frequency, result);

        }
    }
}
