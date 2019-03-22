using NUnit.Framework;

namespace Day2.Tests
{
    public class BoxChecker_GetCommonLettersBetweenClosestIdsShould
    {
        private readonly BoxChecker _boxChecker;
        public BoxChecker_GetCommonLettersBetweenClosestIdsShould()
        {
            _boxChecker = new BoxChecker();
        }

        [TestCase("abcde\nfghij\nklmno\npqrst\naabcdd\nfguij\naxcye\nwvxyz", "fgij")]
        public void ReturnCommonLettersBetweenClosestBoxIds(string input, string commonLetters)
        {
            var result = _boxChecker.GetCommonLettersBetweenClosestBoxIDs(input);
            Assert.AreEqual(commonLetters, result);
        }

    }
}