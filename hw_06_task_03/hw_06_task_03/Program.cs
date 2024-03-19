using System.Collections;

public class LinkedList<T> : IEnumerable<T>
{
    private class Node
    {
        public T Data { get; set; }
        public Node Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;
    private int count;

    public int Count => count;

    public LinkedList()
    {
        head = null;
        count = 0;
    }

    public void Add(T data)
    {
        if (head == null)
        {
            head = new Node(data);
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(data);
        }
        count++;
    }

    public bool Remove(T data)
    {
        if (head == null)
            return false;

        if (head.Data.Equals(data))
        {
            head = head.Next;
            count--;
            return true;
        }

        Node current = head;
        while (current.Next != null)
        {
            if (current.Next.Data.Equals(data))
            {
                current.Next = current.Next.Next;
                count--;
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        Console.WriteLine("Count: " + list.Count);

        Console.WriteLine("Elements:");
        foreach (int item in list)
        {
            Console.WriteLine(item);
        }

        bool removed = list.Remove(2);
        Console.WriteLine("Element 2 removed: " + removed);
        
        Console.WriteLine("Count after: " + list.Count);
        
        Console.WriteLine("Elements after removal:");
        foreach (int item in list)
        {
            Console.WriteLine(item);
        }
    }
}
