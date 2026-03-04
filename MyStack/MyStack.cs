
using LinkedListProj;
using System.Collections;

namespace MyStackProj
{
    public class MyStack<T> : IEnumerable<T>
    {
        public MyLinkedList<T> MyStackItems = new MyLinkedList<T>();
        public MyStack()
        {

        }

        public MyStack(ICollection<T> collection)
        {
            foreach (var item in collection)
            {
                Push(item);
            }
        }

        public void Push(T item)
        {
            MyStackItems.AddFirst(item);
        }
        
        public T Pop()
        {
            if (MyStackItems.Head == null)
                throw new InvalidOperationException("Stack is empty");

            var itemToRemove = MyStackItems.Head.Value;

            MyStackItems.RemoveFirst();

            return itemToRemove;
        }

        public T Peek()
        {
            if (MyStackItems.Head == null)
                throw new InvalidOperationException("Stack is empty");

            return MyStackItems.Head.Value;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return MyStackItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
