using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public IList<int> FindDisappearedNumbers(int[] nums) {
        List<int> result = new List<int>();
        for(int i = 0; i < nums.Length; i++)
        {
            int cur = Math.Abs(nums[i]);
            if(nums[cur-1]>0) nums[cur-1] = -nums[cur-1];
        }

        for(int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                result.Add(i+1);
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

        IList<int> result = sol.FindDisappearedNumbers([4,3,2,7,8,2,3,1]);
        Console.WriteLine($"[{string.Join(", ", result)}]");
        result = sol.FindDisappearedNumbers([1,1]);
        Console.WriteLine($"[{string.Join(", ", result)}]");
    }
}