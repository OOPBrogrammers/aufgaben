using System;

public class Punkt2D
{
    private int x;
    private int y;
    private static Random rand = new Random();

    public Punkt2D(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Punkt2D() : this(rand.Next(), rand.Next()) {}

    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public void Translate()
    {
        Console.WriteLine("Um wie viel soll in x-Richtung verschoben werden?");
        int dx = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Um wie viel soll in y-Richtung verschoben werden?");
        int dy = Convert.ToInt32(Console.ReadLine());

        x += dx;
        y += dy;
    }

    public double DistanceTo(Punkt2D p)
    {
        double distanz = Math.Sqrt(Math.Pow((p.x - x), 2) + Math.Pow((p.y - y), 2));

        Console.WriteLine($"Die Distanz zwischen dem Punkt p = ({p.x}, {p.y}) und dem ursprünglichen Punkt  = ({x}, {y}) beträgt {distanz}\n");
        return distanz;
    }

    public Punkt2D MirrorPoint()
    {
        int xGespiegelt = x * -1;
        int yGespiegelt = y * -1;

        return new Punkt2D(xGespiegelt, yGespiegelt);
    }

    public override string ToString()
    {
        return $"Punkt2D: ({x}, {y})";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Punkt2D punkt1 = new Punkt2D(3, 4);
        
        Punkt2D p = new Punkt2D();
        double distanz = punkt1.DistanceTo(p);

        punkt1.Translate();
        
        Punkt2D gespiegelterPunkt = punkt1.MirrorPoint();

        Console.WriteLine($"Die gespiegelten Koordinaten sind: {gespiegelterPunkt}");
    }
}