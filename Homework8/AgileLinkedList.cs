using System.Collections;
using System.Text;

namespace Homework8;
public class AgileLinkedList<T>
{
    private Node<T> first;
    private Node<T> last;
    private int count;

    public int Count { get { return count; } }

    public Node<T> First { get { return first; } }

    public Node<T> Last { get { return last; } }
    

    public AgileLinkedList()
    {
        first = null;
        last = null;
        count = 0;
    }

    public AgileLinkedList(IEnumerable<T> enumerable)
    {
        foreach (T item in enumerable)
        {
            addLast(item);
        }
    }

    public void addFirst(T value)
    {
        Node<T> node = new Node<T>(value,null,First);
        if (First != null)
        {
            First.Prev = node;
        }

        first = node;

        if (Last == null)
            last = node;
    }

    public void addLast(T value)
    {
        
        if (first == null)
        {
            Node<T> node = new Node<T>(value,null,null);
            first = node;
            last = node;
        }
        else
        {
            Node<T> node = new Node<T>(value,last,null);
            last.Next = node;
            last = node;
        }
        count++;
    }

    public bool isSymmetric()
    {
        Node<T> left = first;
        Node<T> right = last;
    
        while (left != null && right != null)
        {
            if (!left.Data.Equals(right.Data))
            {
                return false;
            }
    
            left = left.Next;
            right = right.Prev;
        }
    
        return true;
    }

    public void removeAtPosition(int position)
    {
        if (position > count || position <= 0)
            throw new Exception();

        
        
        Node<T> currentNode = first;
        for (int i = 0; i < position-1; i++)
        {
            currentNode = currentNode.Next;
            
        }
        if (currentNode.Prev == null)
        {
            first = currentNode.Next;
            first.Prev = null;
        }
        else
        {
            currentNode.Prev.Next = currentNode.Next;
        }

        if (currentNode.Next == null)
        {
            last = currentNode.Prev;
            last.Next = null;
        }
        else
        {
            currentNode.Next.Prev = currentNode.Prev;
        }

        count--;

    }

    public void insertAfterPosition<T>(int position, T value)
    {
        if (position > Count || position <= 0)
            throw new Exception();
        
        
        Node<T> currNode = First as Node<T>;
        
        for (int i = 0; i < position-1; i++)
        {
            currNode = currNode.Next;
        }


        Node<T> newNode = new Node<T>(value,currNode.Prev, currNode.Next);
        currNode.Next = newNode;
        if (newNode.Next != null)
        {
            newNode.Next.Prev = newNode;
        }
        
        count++;
    }
    
    public void shiftLeft(int n)
    {
        if (n <= 0 || first == null || first.Next == null)
            throw new Exception();

        
        int count = 1;
        Node<T> current = first;
        while (current.Next != null)
        {
            current = current.Next;
            count++;
        }

        current.Next = first;
        for (int i = 0; i < count - n % count; i++)
        {
            current = current.Next;
        }

        first = current.Next; 
        current.Next = null; 
    }
    
    public void reverse()
    {
        if (first == null || first.Next == null) 
            return; 
        
        Stack<Node<T>> stack = new Stack<Node<T>>();
        Node<T> curr = first;

        
        while (curr != null)
        {
            stack.Push(curr);
            curr = curr.Next;
        }

        
        first = stack.Pop();
        curr = first;
        while (stack.Count > 0)
        {
            curr.Next = stack.Pop();
            curr = curr.Next;
        }
        curr.Next = null; 
        last = curr; 
        
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        Node<T> current = first;

        while (current != null)
        {
            sb.Append(current.Data);

            if (current.Next != null)
            {
                sb.Append(' ');
            }

            current = current.Next;
        }

        return sb.ToString();
    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }
        public Node(T Data, Node<T> Prev, Node<T> Next)
        {
            this.Data = Data;
            this.Prev = Prev;
            this.Next = Next;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}

