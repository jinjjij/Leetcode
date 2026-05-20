using System;
using System.Collections.Generic;
using System.Linq;


public class Solution
{
    public int EvalRPN(string[] tokens) {
        Stack<int> stk = new Stack<int>();

        foreach(string s in tokens)
        {
            int result = 0;
            if(s == "+")
            {
                int o2 = stk.Pop();
                int o1 = stk.Pop();
                result = o1+o2;
            }
            else if(s == "-")
            {
                int o2 = stk.Pop();
                int o1 = stk.Pop();
                result = o1-o2;
            }
            else if(s == "*")
            {
                int o2 = stk.Pop();
                int o1 = stk.Pop();
                result = o1*o2;
            }
            else if(s == "/")
            {
                int o2 = stk.Pop();
                int o1 = stk.Pop();
                result = o1/o2;
            }
            else
            {
                result = int.Parse(s);
            }
            stk.Push(result);
        }

        return stk.Pop();
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        TestCase(sol.EvalRPN(["2","1","+","3","*"]),9);
        TestCase(sol.EvalRPN(["4","13","5","/","+"]),6);
        TestCase(sol.EvalRPN(["10","6","9","3","+","-11","*","/","*","17","+","5","+"]),22);
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