using System;

class Personenliste
{
    Person head;
    Person tail;

    public class Person
    {
        public Person Successor { get; set; }
        public Person Predecessor { get; set; }
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            string predecessorName = Predecessor != null ? Predecessor.Name : "null";
            string successorName = Successor != null ? Successor.Name : "null";
            return $"Name: {Name}, Vorgänger: {predecessorName}, Nachfolger: {successorName}";
        }
    }

    public void AddEnd(string value)
    {
        Person newPerson = new Person(value);
        if (tail == null)
        {
            head = newPerson;
            tail = newPerson;
        }
        else
        {
            newPerson.Predecessor = tail;
            tail.Successor = newPerson;
            tail = newPerson;
        }
    }

    public void AddFront(string value)
    {
        Person newPerson = new Person(value);
        if (head == null)
        {
            head = newPerson;
            tail = newPerson;
        }
        else
        {
            newPerson.Successor = head;
            head.Predecessor = newPerson;
            head = newPerson;
        }
    }

    public void AddSorted(string value)
    {
        if (head == null || IsGreaterThan(value, tail.Name))
        {
            AddEnd(value);
        }
        else if (IsLessThan(value, head.Name))
        {
            AddFront(value);
        }
        else
        {
            Person current = head;
            while (current.Successor != null && IsLessThan(current.Successor.Name, value))
            {
                current = current.Successor;
            }

            Person newPerson = new Person(value);
            newPerson.Successor = current.Successor;
            newPerson.Predecessor = current;
            current.Successor = newPerson;
            if (newPerson.Successor != null)
            {
                newPerson.Successor.Predecessor = newPerson;
            }
            else
            {
                tail = newPerson;
            }
        }
    }

    public void DeleteFirst()
    {
        if (head == null)
        {
            Console.WriteLine("Liste ist leer");
        }
        else if (head == tail)
        {
            head = null;
            tail = null;
        }
        else
        {
            head = head.Successor;
            head.Predecessor = null;
        }
    }

    public void DeleteLast()
    {
        if (tail == null)
        {
            Console.WriteLine("Liste ist leer");
        }
        else if (head == tail)
        {
            head = null;
            tail = null;
        }
        else
        {
            tail = tail.Predecessor;
            tail.Successor = null;
        }
    }

    public void DeleteByName(string value)
    {
        if (head == null)
        {
            Console.WriteLine("Die Liste ist leer");
        }
        else if (head.Name == value)
        {
            DeleteFirst();
        }
        else if (tail.Name == value)
        {
            DeleteLast();
        }
        else
        {
            Person current = head;
            while (current != null && current.Name != value)
            {
                current = current.Successor;
            }

            if (current != null)
            {
                current.Predecessor.Successor = current.Successor;
                if (current.Successor != null)
                {
                    current.Successor.Predecessor = current.Predecessor;
                }
            }
            else
            {
                Console.WriteLine($"Person mit dem Namen {value} nicht gefunden.");
            }
        }
    }

    public void Print()
    {
        Person current = head;
        while (current != null)
        {
            Console.WriteLine(current.Name);
            current = current.Successor;
        }
    }

    public void PrintReverse()
    {
        Person current = tail;
        while (current != null)
        {
            Console.WriteLine(current.Name);
            current = current.Predecessor;
        }
    }

    public void PrintAll()
    {
        Person current = head;
        while (current != null)
        {
            Console.WriteLine(current);
            current = current.Successor;
        }
    }

    private bool IsLessThan(string a, string b)
    {
        int length = Math.Min(a.Length, b.Length);
        for (int i = 0; i < length; i++)
        {
            if (a[i] < b[i])
            {
                return true;
            }
            else if (a[i] > b[i])
            {
                return false;
            }
        }
        return a.Length < b.Length;
    }

    private bool IsGreaterThan(string a, string b)
    {
        int length = Math.Min(a.Length, b.Length);
        for (int i = 0; i < length; i++)
        {
            if (a[i] > b[i])
            {
                return true;
            }
            else if (a[i] < b[i])
            {
                return false;
            }
        }
        return a.Length > b.Length;
    }
}

class Program
{
    static void Main()
    {
        Personenliste freunde = new Personenliste();
        freunde.AddSorted("Berta");
        freunde.AddSorted("Claudia");
        freunde.AddSorted("Anton");
        freunde.AddSorted("Baerbel");
        freunde.PrintAll();
        
        Console.WriteLine();
        
        freunde.AddFront("Hans");
        freunde.AddEnd("Franz");
        freunde.Print();
        Console.WriteLine();
        
        freunde.DeleteFirst();
        freunde.DeleteLast();
        freunde.DeleteByName("Berta");
        freunde.Print();
        Console.WriteLine();
        
        freunde.PrintReverse();
    }
}