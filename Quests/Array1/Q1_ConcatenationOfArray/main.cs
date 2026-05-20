using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] GetConcatenation(int[] nums) {
        int n = nums.Length;

        int[] result = new int[n*2];

        for(int i = 0; i < n; i++)
        {
            result[i] = nums[i];
            result[i+n] = nums[i];
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        int[] result = sol.GetConcatenation(new int[] { 1, 2, 1 });
        Console.WriteLine($"[{string.Join(", ", result)}]");
        int[] result2 = sol.GetConcatenation(new int[] { 1, 3, 2, 1 });
        Console.WriteLine($"[{string.Join(", ", result2)}]");
    }
}