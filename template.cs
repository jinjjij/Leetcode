using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        int[] result = sol.TwoSum([1,2,3,4], 9);
        Console.WriteLine($"[{string.Join(", ", result)}]");
    }
}