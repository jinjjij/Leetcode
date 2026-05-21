using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int LastStoneWeight(int[] stones) {

        PriorityQueue<int, int> heap = new PriorityQueue<int, int>();

        foreach(int s in stones)
        {
            heap.Enqueue(s,-s);
        }

        while(heap.Count > 1)
        {
            int a = heap.Dequeue();
            int b = heap.Dequeue();

            if(a == b)  continue;
            else        heap.Enqueue(a-b, b-a);
        }

        if(heap.Count == 0)     return 0;
        else                    return heap.Dequeue();
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        TestCase(sol.LastStoneWeight([2,7,4,1,8,1]),1);
        TestCase(sol.LastStoneWeight([1]),1);
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