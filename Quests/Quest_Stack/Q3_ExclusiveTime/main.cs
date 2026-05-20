using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Solution
{
    public int[] ExclusiveTime(int n, IList<string> logs) {
        int[] ExTime = new int[n];
        Stack<int> callStk = new Stack<int>();
        int prevTime = 0;

        foreach(string s in logs)
        {
            string[] parts = s.Split(':');
            int id = int.Parse(parts[0]);
            int time = int.Parse(parts[2]);
            if(parts[1] == "end")   time++;

            if(callStk.Count > 0)
            {
                ExTime[callStk.Peek()] += time - prevTime;
            }
            prevTime = time;
            

            if(parts[1] == "start")
            {
                callStk.Push(id);
            }
            else
            {
                callStk.Pop();
            }
        }

        return ExTime;
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        TestCaseList(sol.ExclusiveTime(2,["0:start:0","1:start:2","1:end:5","0:end:6"]),[3,4]);
        TestCaseList(sol.ExclusiveTime(1,["0:start:0","0:start:2","0:end:5","0:start:6","0:end:6","0:end:7"]),[8]);
        TestCaseList(sol.ExclusiveTime(2,["0:start:0","0:start:2","0:end:5","1:start:6","1:end:6","0:end:7"]),[7,1]);
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