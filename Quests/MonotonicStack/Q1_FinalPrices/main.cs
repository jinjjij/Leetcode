using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[] FinalPrices(int[] prices) 
    {
        int[] answers = new int[prices.Length];
        Stack<int> indexes = new Stack<int>();

        for(int i = 0; i < prices.Length; i++)
        {
            while(indexes.Count > 0 && prices[indexes.Peek()] >= prices[i])
            {
                int idx = indexes.Pop();
                answers[idx] = prices[idx] - prices[i];
            }

            indexes.Push(i);
        }

        while(indexes.Count > 0)
        {
            int idx = indexes.Pop();
            answers[idx] = prices[idx];
        }

        return answers;
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        TestCaseList(sol.FinalPrices([8,4,6,2,3]),[4,2,4,2,3]);
        TestCaseList(sol.FinalPrices([1,2,3,4,5]),[1,2,3,4,5]);
        TestCaseList(sol.FinalPrices([10,1,1,6]),[9,0,1,6]);
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