using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int max(int a, int b)    {return a>b?a:b;}

    public int LargestRectangleArea(int[] heights) {
        int result = 0;
        Stack<int> monoStk_r = new Stack<int>();
        Stack<int> monoStk_l = new Stack<int>();
        (int l, int r)[] span = new (int l, int r)[heights.Length];

        

        for(int i = 0; i < heights.Length; i++)
        {
            result = max(result, heights[i]);

            while(monoStk_r.Count > 0 && heights[monoStk_r.Peek()] > heights[i])
            {
                int idx = monoStk_r.Pop();

                span[idx].r = i-1;
            }

            monoStk_r.Push(i);
        }

        for(int i = heights.Length - 1; i >= 0; i--)
        {
            while(monoStk_l.Count > 0 && heights[monoStk_l.Peek()] > heights[i])
            {
                int idx = monoStk_l.Pop();
                span[idx].l = i+1;
            }
            monoStk_l.Push(i);
        }

        while(monoStk_r.Count > 0)
        {
            int idx = monoStk_r.Pop();
            span[idx].r = heights.Length-1;
        }

        while(monoStk_l.Count > 0)
        {
            int idx = monoStk_l.Pop();
            span[idx].l = 0;
        }

        for(int i = 0; i < heights.Length; i++)
        {
            result = max(result, heights[i] * (span[i].r - span[i].l + 1));
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        TestCase(sol.LargestRectangleArea([2,1,5,6,2,3]),10);
        TestCase(sol.LargestRectangleArea([2,4]),4);
        TestCase(sol.LargestRectangleArea([1,1]),2);
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