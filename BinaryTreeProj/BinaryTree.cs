using System.Collections;

namespace BinaryTreeProj;

public class BinaryTree<T>: IEnumerable<T>
    where T: IComparable<T>


{
    private BinaryTreeNode<T>? Root { get; set; }
    private int Count;

    #region Add

    public void Add(T value)
    {
        Root = Add(Root, value);
        Count++;
    }

    private BinaryTreeNode<T> Add(BinaryTreeNode<T> node, T value)
    {
        if (node == null)
            return new BinaryTreeNode<T>(value);

        if (value.CompareTo(node.Value) < 0)
            node.Left = Add(node.Left, value);
        else if (value.CompareTo(node.Value) > 0)
            node.Right = Add(node.Right, value);

        return node;
    }

    #endregion Add

    #region Remove
    public void Remove(T value)
    {
        Root = Remove(Root, value);
    }

    private BinaryTreeNode<T> Remove(BinaryTreeNode<T> node, T value)
    {
        if (node == null)
            return null;

        int compare = value.CompareTo(node.Value);

        if (compare < 0)
            node.Left = Remove(node.Left, value);
        else if (compare > 0)
            node.Right = Remove(node.Right, value);
        else
        {
            if (node.Left == null && node.Right == null)
            {
                Count--;
                return null;
            }

            if (node.Left == null)
            {
                Count--;
                return node.Right;
            }

            if (node.Right == null)
            {
                Count--;
                return node.Left;
            }

            BinaryTreeNode<T> min = FindMin(node.Right);
            node.Value = min.Value;
            node.Right = Remove(node.Right, min.Value);
        }

        return node;
    }

    private BinaryTreeNode<T> FindMin(BinaryTreeNode<T> node)
    {
        while (node.Left != null)
            node = node.Left;
        return node;
    }

    #endregion Remove


    #region Traversals
    public IEnumerable<T> InOrder()
    {
        return InOrder(Root);
    }

    private IEnumerable<T> InOrder(BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            foreach (var v in InOrder(node.Left))
                yield return v;

            yield return node.Value;

            foreach (var v in InOrder(node.Right))
                yield return v;
        }
    }

    public IEnumerable<T> PreOrder()
    {
        return PreOrder(Root);
    }

    private IEnumerable<T> PreOrder(BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            yield return node.Value;

            foreach (var v in PreOrder(node.Left))
                yield return v;

            foreach (var v in PreOrder(node.Right))
                yield return v;
        }
    }

    public IEnumerable<T> PostOrder()
    {
        return PostOrder(Root);
    }

    private IEnumerable<T> PostOrder(BinaryTreeNode<T> node)
    {
        if (node != null)
        {
            foreach (var v in PostOrder(node.Left))
                yield return v;

            foreach (var v in PostOrder(node.Right))
                yield return v;

            yield return node.Value;
        }
    }

    #endregion Traversals

    public IEnumerator<T> GetEnumerator()
    {
        return InOrder().GetEnumerator(); 
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}