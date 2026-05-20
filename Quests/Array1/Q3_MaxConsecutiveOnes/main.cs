using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int FindMaxConsecutiveOnes(int[] nums) {
        int max = 0;
        int cur1s = 0;

        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i]==1)  cur1s++;
            else            cur1s = 0;
            if(cur1s>max)   max = cur1s;
        }
        return max;
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        int result = sol.FindMaxConsecutiveOnes([1,1,0,1,1,1]);
        Console.WriteLine($"[{result}]");
        result = sol.FindMaxConsecutiveOnes([1,0,1,1,0,1]);
        Console.WriteLine($"[{result}]");
    }
}