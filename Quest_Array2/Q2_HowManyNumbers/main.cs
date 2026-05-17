using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[] SmallerNumbersThanCurrent(int[] nums) {
        int[] result = new int[nums.Length];
        for(int i = 0; i < nums.Length; i++)
        {
            for(int j = 0; j < nums.Length; j++)
            {
                if(i==j)    continue;
                if (nums[j] < nums[i])
                {
                    result[i] ++;
                }
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

        int[] result = sol.SmallerNumbersThanCurrent([8,1,2,2,3]);
        Console.WriteLine($"[{string.Join(", ", result)}]");
        result = sol.SmallerNumbersThanCurrent([6,5,4,8]);
        Console.WriteLine($"[{string.Join(", ", result)}]");
        result = sol.SmallerNumbersThanCurrent([7,7,7,7]);
        Console.WriteLine($"[{string.Join(", ", result)}]");
    }
}