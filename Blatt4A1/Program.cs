// Basis-Klasse Vehicle

namespace Blatt4A1;

public class Vehicle
{
    public int Id { get; private set; }

    // Konstruktor mit ID-Parameter
    public Vehicle(int id)
    {
        Id = id;
        Console.WriteLine("Der Konstruktor von Vehicle arbeitet.");
    }

    public void SayId()
    {
        Console.WriteLine($"My ID is {Id}");
    }

    public override string ToString()
    {
        return $"Id: {Id}";
    }
}

// Abgeleitete Klasse Car
public class Car : Vehicle
{
    public string LicenceNumber { get; private set; }

    // Konstruktor mit ID- und LicenceNumber-Parametern
    public Car(int id, string licenceNumber) : base(id)
    {
        LicenceNumber = licenceNumber;
        Console.WriteLine("Der Konstruktor von Car arbeitet.");
    }

    public override string ToString()
    {
        return $"{base.ToString()}, LicenceNumber: {LicenceNumber}";
    }
}

// Abgeleitete Klasse Ship
public class Ship : Vehicle
{
    public string Name { get; private set; }

    // Konstruktor mit ID- und Name-Parametern
    public Ship(int id, string name) : base(id)
    {
        Name = name;
        Console.WriteLine("Der Konstruktor von Ship arbeitet.");
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Name: {Name}";
    }
}

// Abgeleitete Klasse SailingShip
public class SailingShip : Ship
{
    public int Masten { get; private set; }

    // Konstruktor mit ID-, Name- und Masten-Parametern
    public SailingShip(int id, string name, int poles) : base(id, name)
    {
        Masten = poles;
        Console.WriteLine("Der Konstruktor von SailingShip arbeitet.");
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Masten: {Masten}";
    }
}

class Program
{
    static void Main()
    {
        // Erstellung eines Car-Objekts mit einer einzigartigen ID
        Car car = new Car(2, "W123XYZ");
        car.SayId();
        Console.WriteLine(car);

        // Erstellung eines SailingShip-Objekts mit einer einzigartigen ID
        SailingShip sailingShip = new SailingShip(1, "Black Pearl", 3);
        sailingShip.SayId();
        Console.WriteLine(sailingShip);
    }
}