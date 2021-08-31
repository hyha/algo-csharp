using System;
using Xunit;
using System.Collections.Generic;

namespace q3_LongestNonRepSubstring
{
    public class TestLongestNonRepeatingSubstring
    {
        [Theory]
        [InlineData("pwwkew", 3)]
        [InlineData("abcabcbb", 3)]
        [InlineData("bbbbbbbbbbbbbbbbbbbbbbbbbbb", 1)]
        [InlineData("", 0)]
        public void TestBruteForce(string testCase, int expResult)
        {
            var result = SlidingWindow.LengthOfLongestSubstring(testCase);
            Assert.Equal(expResult, result);
        }
    }

    public class BruteForceSolution
    {
        public static int LengthOfLongestSubstring(string s)
        {
            HashSet<char> probeSet = new HashSet<char>(s.Length);
            int maxSubstrLength = 0;
            for (int i = 0; i < s.Length && s.Length - i > maxSubstrLength; i++)
            { //Main cursor
                probeSet.Clear();
                for (int j = i; j < s.Length && !probeSet.Contains(s[j]); j++)
                { //probe cursor
                    probeSet.Add(s[j]);
                }
                int substrLength = probeSet.Count;
                if (substrLength > maxSubstrLength)
                {
                    maxSubstrLength = substrLength;
                }
            }
            return maxSubstrLength;
        }
    }

    public class SlidingWindow
    {
        public static int LengthOfLongestSubstring(string s)
        {
            if(string.IsNullOrEmpty(s)) return 0;

            HashSet<char> probeSet = new HashSet<char>(s.Length);
            int maxSubstrLength = 0;
            for (int cLeft = 0, cRight = 0; cRight < s.Length; cRight++)
            { 
                while(probeSet.Contains(s[cRight])) 
                {
                    probeSet.Remove(s[cLeft]); //!! Throw away from left of the window, til the newly discovered char
                    cLeft++; //Left of the window
                }
                probeSet.Add(s[cRight]);
                maxSubstrLength = Math.Max(maxSubstrLength, cRight - cLeft + 1);
            }
            return maxSubstrLength;
        }
    }
    //0 1 2 3 4 5 6 7
    //p w w k e w
    //      l   r
    //[]
    //3
}
