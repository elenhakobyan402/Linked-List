using System;


namespace MyStackArrayProj
{

    public class MyStack<T>
    {
        private T[] items;
        private int top;
        private int max;

        public MyStack(int size)
        {
            items = new T[size];
            top = -1;
            max = size;
        }
        public void Push(T item)
        {
            if (top == max - 1)
            {
                Console.WriteLine("Stack is full");
                return;
            }
            items[++top] = item;
        }
        public T Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }
            return items[top--];
        }
        public T Peek()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty");
                return default(T);
            }

            return items[top];
        }

    }
}
