using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int[] FindThePrefixCommonArray(int[] A, int[] B) 
    {
        int l = A.Length;
        int[] check = new int[l+1];
        int[] C = new int[l];

        for(int i = 0; i < l; i++)
        {
            check[A[i]] += 1;
            check[B[i]] += 1;
            for(int j = 1; j < l + 1; j++)
            {
                if(check[j] == 2)
                    C[i] += 1;
            }
        }

        return C;
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        TestCaseList(sol.FindThePrefixCommonArray([1,3,2,4],[3,1,2,4]),[0,2,3,4]);
        TestCaseList(sol.FindThePrefixCommonArray([2,3,1],[3,1,2]),[0,1,3]);
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