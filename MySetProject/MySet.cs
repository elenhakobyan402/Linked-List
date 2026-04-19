using System.Collections;

using LinkedListProj;

namespace MySetProject;

public class MySet<T> : IEnumerable<T> where T : IComparable<T>
{
    private readonly LinkedList<T> _list = new LinkedList<T>();

    public MySet() 
    { 

    }

    public MySet(IEnumerable<T> items)
    {
        AddRange(items);
    }

    public void Add(T item)
    {
        if (Contains(item))
        {
            throw new InvalidOperationException("Item already exists in the set.");
        }
        _list.AddLast(item);
    }
    public void AddRange(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }

    private void AddSkipDuplicates(T item)
    {
        if (!Contains(item))
        {
            _list.AddLast(item);
        }
    }
    public void AddSkipDuplicatesRange(IEnumerable<T> items)
    {
        foreach (T item in items)
        {
            AddSkipDuplicates(item);
        }
    }

    public bool Contains(T item)
    {
        return _list.Contains(item);
    }

    public bool Remove(T item)
    {
        return _list.Remove(item);
    }

    public int Count
    {
        get
        {
            return _list.Count;
        }
    }

    public MySet<T> Union(MySet<T> other)
    {
        MySet<T> result = new MySet<T>(_list);
        result.AddSkipDuplicatesRange(other);
        return result;
    }

    public MySet<T> Intersection(MySet<T> other)
    {
        MySet<T> result = new MySet<T>();
        foreach (var item in _list)
        {
            if (other.Contains(item))
            {
                result.Add(item);
            }
        }
        return result;
    }

    public MySet<T> Difference(MySet<T> other)
    {
        MySet<T> result = new MySet<T>(_list);
        foreach (T item in other)
        {
            result.Remove(item);
        }
        return result;
    }

    public MySet<T> SymmetricDifference(MySet<T> other)
    {
        MySet<T> union = Union(other);
        MySet<T> intersection = Intersection(other);
        return union.Difference(intersection);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    public MySet(params T[] items)
    {
        AddSkipDuplicatesRange(items);
    }
}