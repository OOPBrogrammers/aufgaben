namespace Blatt3A2;

class Buch
{
    public String Name { get; }
    public String Author { get; }
    public int Seitenzahl { get;  }

    public Buch(String name, String author, int seitenzahl)
    {
        Name = name;
        Author = author;
        Seitenzahl = seitenzahl;
    }
    
}

class Sammlung
{
    // Buffer (Schrittgröße für RAM-Allocation von neuen Elementen)
    private const int Buffer = 2;
    private Buch?[] _array = new Buch[Buffer];
    
    public void Add(Buch insert)
    {
        var freeIndex = FindFree();
        if (freeIndex != null)
        {
            _array[freeIndex.Value] = insert;
            return;
        }

        var copy = new Buch?[_array.Length + Buffer];
        for (var index = 0; index < _array.Length; index++)
        {
            copy[index] = _array[index];
        }

        copy[_array.Length] = insert;
        _array = copy;
    }

    private int? FindFree()
    {
        for (var index = 0; index < _array.Length; index++)
        {
            if (_array[index] == null) return index;
        }
        return null;
    }

    public void PrintAll()
    {
        for (var index = 0; index < _array.Length; index++)
        {
            var element = _array[index];
            if (element == null) continue;
            Console.WriteLine($"Titel: '{element.Name}', Author: '{element.Author}', Seitenzahl: '{element.Seitenzahl}'");
        }
    }

    public void PrintAllAuthor(String author)
    {
        for (var index = 0; index < _array.Length; index++)
        {
            var element = _array[index];
            if (element == null || element.Author != author) continue;
            Console.WriteLine($"Titel: '{element.Name}', Author: '{element.Author}', Seitenzahl: '{element.Seitenzahl}'");
        }
    }

    public void RemoveAllAuthor(String author)
    {
        for (var index = 0; index < _array.Length; index++)
        {
            var element = _array[index];
            if (element == null || element.Author != author) continue;
            _array[index] = null;
        }
    }
}

class Test
{
    public static void Main()
    {
        var sammlung = new Sammlung();
        var author = "Markus Rühl";
        sammlung.Add(new Buch("Muss ned schmegge", author, 21));
        sammlung.Add(new Buch("Muss wirke", author, 32));
        sammlung.Add(new Buch("Mein Buch", "Günther", 2000000));
        sammlung.Add(new Buch("Bodybuilding", author, 128));
        Console.WriteLine("\nPrinting all: \n");
        sammlung.PrintAll();
        Console.WriteLine($"\nPrinting all from '{author}': \n");
        sammlung.PrintAllAuthor(author);
        sammlung.RemoveAllAuthor(author);
        
        Console.WriteLine($"\nPrinting all after remove of '{author}': \n");
        sammlung.PrintAll();
    }
}

