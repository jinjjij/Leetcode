using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int need = target - nums[i];

            if (map.ContainsKey(need))
                return new int[] { map[need], i };

            map[nums[i]] = i;
        }

        return Array.Empty<int>();
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        int[] result = sol.TwoSum(new int[] { 2, 7, 11, 15 }, 9);

        Console.WriteLine($"[{string.Join(", ", result)}]");
    }
}