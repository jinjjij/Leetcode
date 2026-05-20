using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Solution
{
    public int MinJumps(int[] arr) {
        int n = arr.Length;

        bool[] vis = new bool[n];
        Dictionary<int, List<int>> groups = new Dictionary<int, List<int>>();

        for(int i = 0; i < n; i++)
        {
            int value = arr[i];

            if (!groups.ContainsKey(value))
            {
                groups[value] = new List<int>();
            }

            groups[value].Add(i);
        }

        Queue<(int id, int depth)> bfs = new Queue<(int id, int depth)>();

        bfs.Enqueue((0,0));
        vis[0] = true;

        while(bfs.Count > 0)
        {
            var cur = bfs.Dequeue();

            if(cur.id == n - 1)
            {
                return cur.depth;
            }

            if (cur.id + 1 < n && !vis[cur.id+1])
            {
                bfs.Enqueue((cur.id+1, cur.depth+1));
                vis[cur.id+1] = true;
            }

            if (groups.TryGetValue(arr[cur.id], out List<int> adj))
            {
                foreach (int idx in adj)
                {
                    if (!vis[idx])
                    {
                        bfs.Enqueue((idx, cur.depth + 1));
                        vis[idx] = true;
                    }
                }

                groups.Remove(arr[cur.id]);
            }

            if (cur.id - 1 >= 0 && !vis[cur.id-1])
            {
                bfs.Enqueue((cur.id-1, cur.depth+1));
                vis[cur.id-1] = true;
            }
        }
        return -1;
    }
}

class Program
{
    static void Main()
    {
        var sol = new Solution();

        TestCase(sol.MinJumps([100,-23,-23,404,100,23,23,23,3,404]),3);
        TestCase(sol.MinJumps([7]),0);
        TestCase(sol.MinJumps([7,6,9,6,9,6,9,7]),1);
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