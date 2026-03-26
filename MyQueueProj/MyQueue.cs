using LinkedListProj;
using System.Collections;
namespace MyQueueProj;

public class MyQueue<T> : IEnumerable<T>
{
    MyLinkedList<T> items = new MyLinkedList<T>();

    public void Enqueue(T item)
    {
        items.AddLast(item);
    }

    public T Dequeue()
    {
        if (items.Count == 0)
        {             
            throw new InvalidOperationException("The Queue is empty");
        }
        T value = items.Head.Value;
        items.RemoveFirst();
        return value;
    }

    public T Peek()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("The Queue is empty ");
        }
            return items.Head.Value;
    }

    public int Count
    {
        get {return items.Count;}
    }


    public void Clear()
    {
         items.Clear(); 
    }

    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return  GetEnumerator();
    }
}
