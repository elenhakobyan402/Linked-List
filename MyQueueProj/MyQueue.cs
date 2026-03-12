using LinkedListProj;
using System.Collections;
namespace MyQueueProj;

public class MyQueue<T> : IEnumerable<T>
{
    MyLinkedList<T> q_items = new MyLinkedList<T>();

    public void Enqueue(T item)
    {
        q_items.AddLast(item);
    }

    public int Dequeue()
    {
        return q_items.RemoveFirst();
    }

    public T Peek()
    {
        return q_items.First();
    }

    public int Count()
    {
        return q_items.Count();
    }


    public void Clear()
    {
         q_items.Clear(); 
    }

    public IEnumerator<T> GetEnumerator()
    {
        return q_items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return  q_items.GetEnumerator();
    }
}
