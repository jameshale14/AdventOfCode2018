using NUnit.Framework;

namespace Day2.Tests
{
    public class BoxChecker_GetCheckSumShould
    {
        private readonly BoxChecker _boxChecker;
        public BoxChecker_GetCheckSumShould()
        {
            _boxChecker = new BoxChecker();
        }

        [TestCase("abcdef\nbababc\nabbcde\nabcccd\naabcdd\nabcdee\nababab", 12)]
        public void ReturnCalculatedCheckSumForInput(string input, int checksum)
        {
            var result = _boxChecker.GetCheckSum(input);
            Assert.AreEqual(checksum, result);
        }

    }
}