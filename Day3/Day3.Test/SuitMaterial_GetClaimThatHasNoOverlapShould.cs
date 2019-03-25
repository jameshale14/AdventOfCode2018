using NUnit.Framework;

namespace Day3
{
    public class SuitMaterial_GetClaimThatHasNoOverlapShould
    {
        private readonly SuitMaterial _suitMaterial = new SuitMaterial();

        public SuitMaterial_GetClaimThatHasNoOverlapShould()
        {
            _suitMaterial = new SuitMaterial();
        }

        [TestCase("#1 @ 1,3: 4x4\n#2 @ 3,1: 4x4\n#3 @ 5,5: 2x2", 3)]
        public void ReturnOnlyClaimWithNoOverlap(string claims, int claimId)
        {
            int result = _suitMaterial.GetClaimThatHasNoOverlap(claims);
            Assert.AreEqual(claimId, result);
        }
    }
}