using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public IList<string> BuildArray(int[] target, int n) {
        int curindex = 0;
        List<string> result = new List<string>();
        for(int i=1; i <= n; i++)
        {
            result.Add("Push");
            if(target[curindex] != i)
            {
                result.Add("Pop");
            }
            else
            {
                curindex ++;
            }

            if(curindex>=target.Length) break;
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        testCase(sol.BuildArray([1,3],3),["Push","Push","Pop","Push"]);
        testCase(sol.BuildArray([1,2,3],3),["Push","Push","Push"]);
        testCase(sol.BuildArray([1,2],4),["Push","Push"]);
    }


    private static void testCase<T>(IEnumerable<T> result, IEnumerable<T> expected)
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
}