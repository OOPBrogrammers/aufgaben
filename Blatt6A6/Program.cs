

// Interface IAddable mit einer Add-Methode
public interface IAddable<T>
{
    T Add(T value);
}

// Klasse Tuple mit zwei generischen Properties ValueA und ValueB
public class Tuple<T, U>
{
    public T ValueA { get; set; }
    public U ValueB { get; set; }
}

// Klasse Vector, die von Tuple abgeleitet ist und das IAddable-Interface implementiert
public class Vector<T> : Tuple<T, T>, IAddable<Vector<T>>
{
    // Konstruktor zum Initialisieren der Properties
    public Vector(T valueA, T valueB)
    {
        this.ValueA = valueA;
        this.ValueB = valueB;
    }

    // Implementierung der Add-Methode aus dem IAddable-Interface
    public Vector<T> Add(Vector<T> vector)
    {
        dynamic newValueA = (dynamic)this.ValueA + (dynamic)vector.ValueA;
        dynamic newValueB = (dynamic)this.ValueB + (dynamic)vector.ValueB;

        return new Vector<T>(newValueA, newValueB);
    }
}

class Program
{
    static void Main()
    {
        // Beispiel für die Verwendung des Vectors
        Vector<int> vector1 = new Vector<int>(1, 2);
        Vector<int> vector2 = new Vector<int>(3, 4);

        Vector<int> resultVector = vector1.Add(vector2);

        Console.WriteLine($"ValueA: {resultVector.ValueA}, ValueB: {resultVector.ValueB}");
    }
}