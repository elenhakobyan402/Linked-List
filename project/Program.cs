using LinkedListProj;

namespace Testing_DataStructures;
public class Program
{
    private static void Main()
    {
        #region LinkedList
        var LinkedList = new MyLinkedList<string>();

        LinkedList.AddFirst("A");
        LinkedList.AddFirst("B");
        LinkedList.AddFirst("C");
        LinkedList.AddFirst("D");
        LinkedList.AddFirst("E");

        foreach (var item in LinkedList)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
        LinkedList.RemoveFirst();
        LinkedList.RemoveFirst();

        foreach (var item in LinkedList)
        {
            Console.WriteLine(item); 
        }

        #endregion LinkedList


    }
}
