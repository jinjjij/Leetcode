using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int GetCommon(int[] nums1, int[] nums2) {
        int idx1 = 0;
        int idx2 = 0;
        int cur = nums1[idx1];
        int result = -1;

        while (idx1 < nums1.Length && idx2 < nums2.Length)
        {
            if(nums1[idx1] > nums2[idx2])
            {
                idx2 ++;
            }
            else if(nums1[idx1] < nums2[idx2])
            {
                idx1 ++;
            }
            else
            {
                result = nums1[idx1];
                break;
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        TestCase(sol.GetCommon([1,2,3],[2,4]),2);
        TestCase(sol.GetCommon([1,2,3,6],[2,3,4,5]),2);
    }


    private static void TestCaseList<T>(IEnumerable<T> result, IEnumerable<T> expected)
    {
        if (result.SequenceEqual(expected))
        {
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine("Wrong!")   ;
            Console.WriteLine($"\tresult = [{string.Join(", ", result)}]");
            Console.WriteLine($"\texpected = [{string.Join(", ", expected)}]");
        }
    }


    private static void TestCase<T>(T result, T expected)
    {
        if (EqualityComparer<T>.Default.Equals(result, expected))
        {
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine("Wrong!");
            Console.WriteLine($"\tresult   = {result}");
            Console.WriteLine($"\texpected = {expected}");
        }
    }
}