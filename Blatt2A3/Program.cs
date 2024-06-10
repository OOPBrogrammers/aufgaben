using System;
class Vector
{
    public readonly float x;
    public readonly float y;

    public Vector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.x + v2.x, v1.y + v2.y);
    }

    public static Vector operator *(float scalar, Vector v)
    {
        return new Vector(v.x * scalar, v.y * scalar);
    }
    
    public static explicit operator float(Vector v)
    {
        //Was soll denn returned werden?
        return v.x * v.y;
    }
    
    public static Vector operator *(Vector v, float scalar)
    {
        return scalar * v;
    }

    public static Vector operator ++(Vector v)
    {
        return new Vector(v.x * 2, v.y * 2);
    }

    public static Vector operator -(Vector v)
    {
        return new Vector(v.x * (-1), v.y * (-1));
    }

    public static bool operator ==(Vector v1, Vector v2)
    {
        return v1.x == v2.x && v1.y == v2.y;
    }

    public static bool operator !=(Vector v1, Vector v2)
    {
        return !(v1 == v2);
    }

    public override string ToString()
    {
        return $"({x}/{y})";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vector v1 = new Vector(1, 1);
        Vector v2 = new Vector(1, 1);

        Console.WriteLine(1.0f * (float) v1);
        Console.WriteLine(-(v1 + v1 * 5.0f + ++v1));
        Console.WriteLine(new Vector(1, 1) + ++v2 * 10 + v2++);
        Console.WriteLine(v2);
        Console.WriteLine(v1);
        Console.WriteLine(v1 == v2 ? "ja" : "nein");

        Console.WriteLine(new Vector(1, 1) != new Vector(1, 1) ? "ja" : "nein");
    }
}