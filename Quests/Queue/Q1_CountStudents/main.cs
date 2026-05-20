using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int CountStudents(int[] students, int[] sandwiches) {
        Queue<int> queue = new Queue<int>();
        int stkIdx = 0;

        for(int i=0;i<students.Length;i++)  queue.Enqueue(i);


        int lastAccept = 0;
        while(queue.Count > 0 && lastAccept <= queue.Count())
        {
            int cur = queue.Dequeue();

            if(students[cur] == sandwiches[stkIdx])
            {
                stkIdx ++;
                lastAccept = 0;
            }
            else
            {
                queue.Enqueue(cur);
                lastAccept ++;
            }
        }

        return queue.Count();
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        TestCase(sol.CountStudents([1,1,0,0],[0,1,0,1]),0);
        TestCase(sol.CountStudents([1,1,1,0,0,1],[1,0,0,0,1,1]),3);
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