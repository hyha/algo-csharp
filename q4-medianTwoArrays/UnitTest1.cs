using System;
using Xunit;

namespace q4_medianTwoArrays
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new int[] { 1,2,3,4 },new int[] { 5,6,7,8 }, 4.5)]
        [InlineData(new int[] { 1,2 },new int[] { 3 }, 2.0)]
        [InlineData(new int[] { 1 },new int[0], 1.0)]
        [InlineData(new int[0],new int[] { 2 }, 2.0)]
        public void Test1(int[] nums1, int[] nums2, double expected)
        {
            var sol = new Solution();
            var result = sol.FindMedianSortedArrays(nums1, nums2);
            Assert.Equal(expected, result);
        }

        
    }
}
