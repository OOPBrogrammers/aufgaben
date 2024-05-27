namespace Blatt1A23;

public class Program
{
    public static double Potenz(double x, int n)
    {
        var value = 1.0;
        for (int i = 0; i < n; i++)
        {
            value *= x;
        }

        return value;
    }

    public static double PotenzRek(double x, int n)
    {
        if (n <= 0) return 1;
        return x * PotenzRek(x, n - 1);
    }

    public static void Main(string[] args)
    {
        Console.Write("Basis eingeben: ");
        int basis = Convert.ToInt32(Console.ReadLine() ?? "");
        Console.Write("Exponent eingeben: ");
        int exponent = Convert.ToInt32(Console.ReadLine() ?? "");
        for (int i = 0; i <= exponent; i++)
        {
            Console.WriteLine($"{basis}^{i}: {Potenz(basis, i)}");
        }
        Console.WriteLine($"{basis}^{exponent} Rekursiv: {PotenzRek(basis, exponent)}");
    }
}
