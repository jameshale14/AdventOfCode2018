using NUnit.Framework;

namespace Day3
{
    public class SuitMaterial_GetOverLappingAreaFromClaimsShould
    {
        private readonly SuitMaterial _suitMaterial = new SuitMaterial();

        public SuitMaterial_GetOverLappingAreaFromClaimsShould()
        {
            _suitMaterial = new SuitMaterial();
        }

        [TestCase("#1 @ 1,3: 4x4\n#2 @ 3,1: 4x4\n#3 @ 5,5: 2x2", 4)]
        [TestCase("#1 @ 1,3: 4x4\n#2 @ 3,1: 4x4\n#3 @ 5,5: 2x2\n#4 @ 0,3: 2x2", 6)]
        public void ReturnAreaOfOverLappingClaims(string claims, int area)
        {
            int result = _suitMaterial.GetOverLappingAreaFromClaims(claims);
            Assert.AreEqual(area, result);
        }
    }
}