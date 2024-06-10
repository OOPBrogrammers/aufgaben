using System;

// Klasse Backofen
class Backofen : IRecyclebar
{
    public void OeffneOfentuere()
    {
        Console.WriteLine("Quiiietsch...");
    }

    public void SchliesseOfentuere()
    {
        Console.WriteLine("Quiiietsch...Rumms");
    }

    public void WirfEsAufDenMuell()
    {
        Console.WriteLine("Backofen: erst ausschalten, dann Stecker ziehen, dann ausbauen und weg damit");
    }
}

// Klasse Kleiderschrank
class Kleiderschrank : IRecyclebar
{
    public void OeffneKleiderschrank()
    {
        Console.WriteLine("Knarr...");
    }

    public void SchliesseKleiderschrank()
    {
        Console.WriteLine("Knarr...Rumms");
    }

    public void WirfEsAufDenMuell()
    {
        Console.WriteLine("Kleiderschrank: erst ausräumen, dann auseinanderschrauben und weg damit");
    }
}

// Klasse Staubsauger
class Staubsauger : IRecyclebar
{
    public void SchalteEin()
    {
        Console.WriteLine("...oOsurrrrr");
    }

    public void SchalteAus()
    {
        Console.WriteLine("rrrOo...");
    }

    public void WirfEsAufDenMuell()
    {
        Console.WriteLine("Staubsauger: erst ausschalten, dann Stecker ziehen, dann Müllbeutel entsorgen");
    }
}

// Schnittstelle IRecyclebar
interface IRecyclebar
{
    void WirfEsAufDenMuell();
}

class Program
{
    public static void WirfGegenstandWeg(IRecyclebar i)
    {
        i.WirfEsAufDenMuell();
    }

    static void Main()
    {
        // Erstellen von Objekten
        var backofen = new Backofen();
        var kleiderschrank = new Kleiderschrank();
        var staubsauger = new Staubsauger();

        // Speichern der Objekte in einem Array vom Typ object
        object[] einrichtungsgegenstaende = { backofen, kleiderschrank, staubsauger };

        // Durchlaufen der Gegenstände und verwenden von WirfGegenstandWeg
        foreach (var gegenstand in einrichtungsgegenstaende)
        {
            if (gegenstand is IRecyclebar recyclebarerGegenstand)
            {
                WirfGegenstandWeg(recyclebarerGegenstand);
                
                // Zusätzliche Methode aufrufen
                if (recyclebarerGegenstand is Backofen)
                {
                    ((Backofen)recyclebarerGegenstand).OeffneOfentuere();
                }
                else if (recyclebarerGegenstand is Kleiderschrank)
                {
                    ((Kleiderschrank)recyclebarerGegenstand).OeffneKleiderschrank();
                }
                else if (recyclebarerGegenstand is Staubsauger)
                {
                    ((Staubsauger)recyclebarerGegenstand).SchalteEin();
                }
            }
        }
    }
}
