using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Solution
{
    public int LongestCommonPrefix(int[] arr1, int[] arr2) {

        HashSet<int> prefixes = new HashSet<int>();
        int max = 0;

        foreach(int a in arr1)
        {
            int cur = a;
            while(cur > 0)
            {
                prefixes.Add(cur);
                cur /= 10;
            }
        }


        foreach(int a in arr2)
        {
            int cur = a;
            while(cur > 0)
            {
                if (prefixes.Contains(cur))
                {
                    max = Math.Max(max, findIntLength(cur));
                }
                cur /= 10;
            }
        }

        return max;
    }


    public int findIntLength(int a)
    {
        int div = 1;
        int count = 1;
        while(a / div >= 10)
        {
            div *= 10;
            count ++;
        }

        return count;
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        TestCase(sol.LongestCommonPrefix([1,10,100],[1000]),3);
        TestCase(sol.LongestCommonPrefix([1,2,3],[4,4,4]),0);
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