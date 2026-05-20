using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int TimeRequiredToBuy(int[] tickets, int k) {
        int count = 0;
        for(int i = 0; i < tickets.Length; i++)
        {
            if (i <= k)
            {
                count += Math.Min(tickets[i], tickets[k]);
            }
            else
            {
                count += Math.Min(tickets[i], tickets[k]-1);
            }
        }
        return count;
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        TestCase(sol.TimeRequiredToBuy([2,3,2],2),6);
        TestCase(sol.TimeRequiredToBuy([5,1,1,1],0),8);
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