using System;
using System.Linq;
using System.Collections;

public class Solution {
    //https://docs.microsoft.com/en-us/dotnet/api/system.array.sort?view=net-5.0#System_Array_Sort_System_Array_
    //Array.Sort using heapsort -> quicksort, O(nLogn)
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        if(nums1 == null || nums2 == null || (nums1.Length < 1 && nums2.Length < 1)) return 0.0;
        if(nums2.Length == 0 && nums1.Length == 1) return nums1[0];
        if(nums1.Length == 0 && nums2.Length == 1) return nums2[0];
        
        int[] allNums = nums1.Concat(nums2).ToArray();
        Array.Sort(allNums);
        var isOdd = allNums.Length % 2 > 0 ? true : false;
        var rightPos = allNums.Length / 2;
        if(isOdd) {
            return allNums[rightPos];
        }
        return (allNums[rightPos - 1] + allNums[rightPos])/2d;
    }
}