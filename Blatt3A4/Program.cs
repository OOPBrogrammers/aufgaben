namespace Blatt3A4;
class Personenliste
{
    Person? _head;
    Person? _tail;

    public class Person
    {
        public Person? Successor { get; set; }
        public Person? Predecessor { get; set; }
        public string Name { get; }

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
        if (_tail == null)
        {
            _head = newPerson;
            _tail = newPerson;
        }
        else
        {
            newPerson.Predecessor = _tail;
            _tail.Successor = newPerson;
            _tail = newPerson;
        }
    }

    public void AddFront(string value)
    {
        Person newPerson = new Person(value);
        if (_head == null)
        {
            _head = newPerson;
            _tail = newPerson;
        }
        else
        {
            newPerson.Successor = _head;
            _head.Predecessor = newPerson;
            _head = newPerson;
        }
    }

    public void AddSorted(string value)
    {
        if (_head == null || IsGreaterThan(value, _tail!.Name))
        {
            AddEnd(value);
        }
        else if (IsLessThan(value, _head.Name))
        {
            AddFront(value);
        }
        else
        {
            Person current = _head;
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
                _tail = newPerson;
            }
        }
    }

    public void DeleteFirst()
    {
        if (_head == null)
        {
            Console.WriteLine("Liste ist leer");
        }
        else if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head = _head.Successor;
            _head!.Predecessor = null;
        }
    }

    public void DeleteLast()
    {
        if (_tail == null)
        {
            Console.WriteLine("Liste ist leer");
        }
        else if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail.Predecessor;
            _tail!.Successor = null;
        }
    }

    public void DeleteByName(string value)
    {
        if (_head == null)
        {
            Console.WriteLine("Die Liste ist leer");
        }
        else if (_head.Name == value)
        {
            DeleteFirst();
        }
        else if (_tail != null && _tail.Name == value)
        {
            DeleteLast();
        }
        else
        {
            Person? current = _head;
            while (current != null && current.Name != value)
            {
                current = current.Successor;
            }

            if (current != null)
            {
                if (current.Predecessor != null)
                {
                    current.Predecessor.Successor = current.Successor;
                }
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
        Person? current = _head;
        while (current != null)
        {
            Console.WriteLine(current.Name);
            current = current.Successor;
        }
    }

    public void PrintReverse()
    {
        Person? current = _tail;
        while (current != null)
        {
            Console.WriteLine(current.Name);
            current = current.Predecessor;
        }
    }

    public void PrintAll()
    {
        Person? current = _head;
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
            if (a[i] > b[i])
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