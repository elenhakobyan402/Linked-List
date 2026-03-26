using System.Collections;
using BinaryTreeProj;
using LinkedListProj;
using BinaryTreeProj;
using MyHashTableProj;
using LinkedListProj;
using MyQueueProj;
using MyStackProj;


namespace Testing;

public class Program
{
    private static void Main()
    {
        Console.WriteLine("---TESTING--");


        #region LinkedList
        var linkedList = new MyLinkedList<string>();

        linkedList.AddFirst("1");
        linkedList.AddFirst("3");
        linkedList.AddFirst("5");
        linkedList.AddFirst("7");
        linkedList.AddFirst("9");

        foreach (var item in linkedList)
        {
            Console.WriteLine($"Current Item: {item}");
        }

        Console.WriteLine();
        linkedList.RemoveFirst();



        foreach (var item in linkedList)
        {
            Console.WriteLine($"Current Item: {item}");
        }

        #endregion LinkedList

        #region Stack
        Console.WriteLine("---Stack---");
        var stack = new MyStack<string>();
        stack.Push("A");
        stack.Push("B");
        stack.Push("C");
        stack.Push("D");
        foreach (var item in stack)
        {
            Console.WriteLine($"Current Item: {item}");
        }
        Console.WriteLine();
        Console.WriteLine("Top:" + stack.Peek());
        stack.Pop();
        Console.WriteLine("After Pop Top:" + stack.Peek());

        #endregion Stack

        #region Queue
        Console.WriteLine("---Queue---");

        var queue = new MyQueue<string>();

        queue.Enqueue("X");
        queue.Enqueue("Y");
        queue.Enqueue("Z");
        queue.Enqueue("W");

        Console.WriteLine("Queue Items:");

        foreach (var item in queue)
        {
            Console.WriteLine($"Current Item: {item}");
        }

        Console.WriteLine();

        Console.WriteLine("Front of Queue: " + queue.Peek());

        queue.Dequeue();

        Console.WriteLine("After Dequeue Front: " + queue.Peek());

        queue.Dequeue();

        Console.WriteLine("After Dequeue Front: " + queue.Peek());

        #endregion Queue

        

        #region BinaryTree

        Console.WriteLine("---Binary Tree---");

        var tree = new BinaryTree<int>();

        // Add elements
        tree.Add(4);
        tree.Add(2);
        tree.Add(6);
        tree.Add(1);
        tree.Add(3);
        tree.Add(5);
        tree.Add(7);

        // InOrder (should be sorted)
        Console.WriteLine("InOrder:");
        foreach (var item in tree.InOrder())
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // PreOrder
        Console.WriteLine("PreOrder:");
        foreach (var item in tree.PreOrder())
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // PostOrder
        Console.WriteLine("PostOrder:");
        foreach (var item in tree.PostOrder())
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // Remove leaf
        Console.WriteLine("Remove (2):");
        tree.Remove(2);
        foreach (var item in tree)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // Remove node with one child
        Console.WriteLine("Remove node with one child (3):");
        tree.Remove(3);
        foreach (var item in tree)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // Remove node with two children
        Console.WriteLine("Remove node with two children (5):");
        tree.Remove(5);
        foreach (var item in tree)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        #endregion BinaryTree

        #region HashTable
        Console.WriteLine("---Hash Table---");
        string testString = "Lorem ipsum dolor";

        // Additive Hash
        int additive = MyHashTable.AdditiveHash(testString);
        Console.WriteLine($"Additive Hash of \"{testString}\"  {additive}");

        // Folding Hash
        int folding = MyHashTable.FoldingHash(testString);
        Console.WriteLine($"Folding Hash of \"{testString}\" {folding}");

        
        #endregion HashTable
    }
}