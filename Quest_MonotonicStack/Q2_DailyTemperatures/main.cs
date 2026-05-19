using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[] DailyTemperatures(int[] temperatures) {
        int[] answers = new int[temperatures.Length];
        Stack<int> stk = new Stack<int>();

        for(int i = 0; i < temperatures.Length; i++)
        {
            while(stk.Count > 0 && temperatures[stk.Peek()] < temperatures[i])
            {
                int idx = stk.Pop();
                answers[idx] = i-idx;
            }

            stk.Push(i);
        }

        return answers;
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        TestCaseList(sol.DailyTemperatures([73,74,75,71,69,72,76,73]),[1,1,4,2,1,1,0,0]);
        TestCaseList(sol.DailyTemperatures([30,40,50,60]),[1,1,1,0]);
        TestCaseList(sol.DailyTemperatures([30,60,90]),[1,1,0]);
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