using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList
{
    internal class MyLinkedList<T> : ICollection<T>
    {
        public MyLinkedListNode<T> Head { get; private set; }
        public MyLinkedListNode<T> Tail { get; private set; }

        #region ICollection
        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }

        public void Add(T item)
        {
            AddFirst(item);
        }

        private void AddFirst(T item)
        {
            var newNode = new MyLinkedListNode<T>(item);
            if (Head == null)
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
            Count++
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

    }
}
