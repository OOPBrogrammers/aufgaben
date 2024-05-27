namespace Blatt3A5;
public class ListItem
{
    public string Data { get; }
    public ListItem? Next { get; set; }
    public ListItem? Prev { get; set; }

    public ListItem(string data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}

public class List
{
    private ListItem? _head;

    public void Add(string data)
    {
        ListItem newItem = new ListItem(data);
        if (_head == null)
        {
            _head = newItem;
        }
        else
        {
            ListItem current = _head;
            while (current != null)
            {
                if (current.Data == data)
                {
                    newItem.Next = current.Next;
                    newItem.Prev = current;

                    if (current.Next != null)
                    {
                        current.Next.Prev = newItem;
                    }

                    current.Next = newItem;
                    return;
                }

                if (current.Next == null)
                {
                    current.Next = newItem;
                    newItem.Prev = current;
                    return;
                }

                current = current.Next;
            }
        }
    }
    private ListItem? GetLastNode()
    {
        if (_head == null)
        {
            return null;
        }

        ListItem current = _head;
        while (current.Next != null)
        {
            current = current.Next;
        }

        return current;
    }

    public int CountItems()
    {
        int count = 0;
        ListItem? current = _head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }

        return count;
    }

    public void PrintAll()
    {
        ListItem? current = _head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }

    public double CalculateAverageLength()
    {
        if (_head == null)
        {
            return 0.0;
        }

        int totalLength = 0;
        int count = 0;
        ListItem? current = _head;
        while (current != null)
        {
            totalLength += current.Data.Length;
            count++;
            current = current.Next;
        }

        return (double)totalLength / count;
    }
    
    public static void Main(string[] args)
    {
        List list = new List();
        list.Add("Hello");
        list.Add("World");
        list.Add("Hello"); // Adding "Hello" again should place it after the first "Hello"
        list.Add("Test");

        Console.WriteLine("All items:");
        list.PrintAll();

        Console.WriteLine("\nTotal items: " + list.CountItems());

        Console.WriteLine("\nAverage length: " + list.CalculateAverageLength());
    }
}
