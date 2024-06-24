public static class MinHelper
{
    // gibt den kleineren Wert von zwei Werten zurück
    public static T Min<T>(T value1, T value2) where T : IComparable<T>
    {
        // Wenn value1 kleiner als value2 ist, wird value1 zurückgegeben, sonst value2
        return value1.CompareTo(value2) < 0 ? value1 : value2;
    }
}

class Program
{
    static void Main()
    {
        int minInt = MinHelper.Min(5, 3); // gibt 3 zurück
        double minDouble = MinHelper.Min(3.14, 2.71); // gibt 2.71 zurück
        string minString = MinHelper.Min("apple", "banana"); // gibt "apple" zurück

        Console.WriteLine($"Min Integer: {minInt}");
        Console.WriteLine($"Min Double: {minDouble}");
        Console.WriteLine($"Min String: {minString}");
    }
}