using System;
using MyStackArrayProj;

class Program
{
    static void Main()
    {
        MyStack<int> stack = new MyStack<int>(10);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
      
        Console.WriteLine("Top item: " + stack.Peek()); 
        Console.WriteLine("Removed item: " + stack.Pop()); 
        
    }
}
