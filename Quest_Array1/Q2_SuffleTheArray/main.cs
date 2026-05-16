using System;

public class Solution {
    public int[] Shuffle(int[] nums, int n) {
        int[] result = new int[2*n];

        for(int i = 0; i < n; i++)
        {
            result[2*i] = nums[i];
            result[2*i+1] = nums[n+i];
        }


        return result;
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        int[] result = sol.Shuffle([2,5,1,3,4,7], 3);
        Console.WriteLine($"[{string.Join(", ", result)}]");
        result = sol.Shuffle([1,2,3,4,4,3,2,1], 4);
        Console.WriteLine($"[{string.Join(", ", result)}]");
        result = sol.Shuffle([1,1,2,2], 2);
        Console.WriteLine($"[{string.Join(", ", result)}]");
    }
}