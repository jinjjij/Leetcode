using System;
using System.Collections.Generic;
using System.Linq;

public class MyQueue {

    Stack<int> inputStk;
    Stack<int> outputStk;
    int count;


    public MyQueue() {
        inputStk = new Stack<int>();
        outputStk = new Stack<int>();
        count = 0;
    }
    
    public void Push(int x) {
        while(outputStk.Count > 0)
        {
            inputStk.Push(outputStk.Pop());
        }

        inputStk.Push(x);
        count++;
    }
    
    public int Pop() {
        while(inputStk.Count > 0)
            outputStk.Push(inputStk.Pop());
        count--;
        return outputStk.Pop();
    }
    
    public int Peek() {
        while(inputStk.Count > 0)
            outputStk.Push(inputStk.Pop());
        return outputStk.Peek();
    }
    
    public bool Empty() {
        if(count==0)    return true;
        else            return false;
    }
}

class Program
{
    static void Main()
    {
        MyQueue myQueue = new MyQueue();
        myQueue.Push(1); // queue is: [1]
        myQueue.Push(2); // queue is: [1, 2] (leftmost is front of the queue)
        Console.WriteLine(myQueue.Peek()); // return 1
        Console.WriteLine(myQueue.Pop()); // return 1, queue is [2]
        Console.WriteLine(myQueue.Empty()); // return false
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