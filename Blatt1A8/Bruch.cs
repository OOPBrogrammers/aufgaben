using System.Numerics;

namespace Blatt1A8;


public class Bruch
{
    private int Zaehler { get; set; }
    private int _nenner;
    private int Nenner
    {
        get => _nenner;
        set
        {
            if (value == 0) throw new ArgumentException("Nenner darf nicht 0 sein.");
            _nenner = value;
        }
    }

    public Bruch(int zaehler, int nenner)
    {
        Zaehler = zaehler;
        Nenner = nenner;
    }

    public void Addiere(Bruch b)
    {
        Zaehler = (Zaehler * b.Nenner) + (b.Zaehler * Nenner);
        Nenner *= b.Nenner;
        Kuerze();
    }

    public void Kuerze()
    {
        int div = (int)BigInteger.GreatestCommonDivisor(Zaehler, Nenner);
        Zaehler /= div;
        Nenner /= div;
    }

    public int VergleicheMit(Bruch b)
    {
        //Zaehler auf selben Nenner bringen
        int zaehlerValue = Zaehler * b.Nenner;
        int otherZaehlerValue = b.Zaehler * Nenner;
        
        
        if (otherZaehlerValue > zaehlerValue) return -1;
        if (zaehlerValue > otherZaehlerValue) return 1;
        return 0;
    }

    override public String ToString()
    {
        return $"{Zaehler}/{Nenner}";
    }
}