namespace Blatt4A2;
public abstract class Tier
{
    protected string name;

    public Tier(string name)
    {
        this.name = name;
    }

    public abstract void MacheAufDichAufmerksam();
}

public class Hund : Tier
{
    public Hund(string name) : base(name) {}

    public override void MacheAufDichAufmerksam()
    {
        Console.WriteLine($"Ich bin ein {name} und mache Wau");
    }
}

public class Katze : Tier
{
    public Katze(string name) : base(name)
    {
    }

    public override void MacheAufDichAufmerksam()
    {
        Console.WriteLine($"Ich bin eine {name} und mache Miau");
    }
}

public class Maus : Tier
{
    public Maus(string name) : base(name)
    {
    }

    public override void MacheAufDichAufmerksam()
    {
        Console.WriteLine($"Ich bin eine {name} und mache Piep");
    }
}

class Program
{
    static void Main()
    {
        Tier[] meinKleinerZoo = new Tier[3];
        meinKleinerZoo[0] = new Hund("Hund");
        meinKleinerZoo[1] = new Katze("Katze");
        meinKleinerZoo[2] = new Maus("Maus");

        foreach (Tier tier in meinKleinerZoo)
        {
            tier.MacheAufDichAufmerksam();
        }
    }
}