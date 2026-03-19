using System.Runtime.InteropServices.Swift;
using System.Xml.Linq;
using Nodes;


Node first = new Node(5);
Node second = new Node(3);
Node third = new Node(4);
Node fourth = new Node(-5);

first.Next = second;
second.Next = third;
third.Next = fourth;

Print(first);
void Print(Node node)
{
    while (node != null)
    {
        Console.WriteLine(node.Value);
        node = node.Next;
    }
}

