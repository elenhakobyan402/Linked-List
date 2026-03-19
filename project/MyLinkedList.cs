using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LinkedListProj;

public class MyLinkedList<T> : ICollection<T>
{
    private T item;

    public MyLinkedListNode<T> Head { get; private set; }
    public MyLinkedListNode<T> Tail { get; private set; }

    #region ICollection
    public int Count { get; private set; }
    public bool IsReadOnly { get; private set; }

    public void Add(T item)
    {
        AddFirst(item);
    }


    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        var current = Head;

        while (current != null)
        {
            if (current.Value.Equals(item))
                return true;

            current = current.Next;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        var current = Head;
        while (current != null)
        {
            array[arrayIndex++] = current.Value;
            current = current.Next;
        }
    }
    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = Head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }


    #endregion ICollection
    #region Add


    public void AddFirst(T value)
    {
        var newNode = new MyLinkedListNode<T>(item);
        if (Head == null)
        {

            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head = newNode;
        }
        Count++;
    }



    public void AddLast(T value)
    {
        var newNode = new MyLinkedListNode<T>(item);
        if (Tail == null)
        {

            Tail = newNode;
            Head = newNode;
        }
        else
        {
            Tail.Next = newNode;
            Tail = newNode;
        }
        Count++;
    }

    #endregion Add
    #region Remove
    public T RemoveFirst(T item)
    {
        return RemoveFirst(new MyLinkedListNode<T>(item));
    }

    private T RemoveFirst(MyLinkedListNode<T> node)
    {
        MyLinkedListNode<T> temp = Head;
        Head = Head.Next;
        Count--;
        return temp.Value;
    }

    public T RemoveLast(T item)
    {
        return RemoveLast(new MyLinkedListNode<T>(item));
    }
    private T RemoveLast(MyLinkedListNode<T> node)
    {
        if (Count == 0)
            throw new InvalidOperationException("List is empty");

        if (Count ==1)
            {
                var temp = Tail;
                Tail = null;
                Head = null;
                Count--;
                return temp.Value;
            }
            else
            {
                var current = Head;
                while (current.Next != Tail)
                {
                    current = current.Next;
                }
                var temp = Tail;
                Tail = current;
                Tail.Next = null;
                Count--;
                return temp.Value;
            }
        

    }

    public int RemoveFirst()
    {
        throw new NotImplementedException();
    }
}


    #endregion Remove
