namespace Blatt2A4;
class Printer(char printCharacter)
{
    private char _printCharacter = printCharacter;
    private string _output = "";

    private void PrintOneCharacter()
    {
        _output += _printCharacter;
    }

    public static Printer operator ++(Printer printer)
    {
        printer.PrintOneCharacter();
        return printer;
    }

    public static Printer operator +(Printer printer, int count)
    {
        for (var i = 0; i < count; i++)
        {
            printer.PrintOneCharacter();
        }
        return printer;
    }

    public static Printer operator <<(Printer printer, char newPrintCharacter)
    {
        printer._printCharacter = newPrintCharacter;
        return printer;
    }

    public static Printer operator +(Printer printer, char newPrintCharacter)
    {
        printer._printCharacter = newPrintCharacter;
        printer.PrintOneCharacter();
        return printer;
    }

    public static implicit operator string(Printer printer)
    {
        return printer._output;
    }

    public static bool operator >(Printer printer1, Printer printer2)
    {
        return printer1._output.Length > printer2._output.Length;
    }

    public static bool operator <(Printer printer1, Printer printer2)
    {
        return printer1._output.Length < printer2._output.Length;
    }
}

public class Program
{
    public static void Main()
    {
        Printer printer1 = new Printer('#');

        printer1++;
        Console.WriteLine("1. " + (string)printer1);

        printer1 += 3;
        Console.WriteLine("2. " + (string)printer1);

        printer1 = printer1 << 'X';
        printer1 += 2;
        Console.WriteLine("3. " + (string)printer1);

        Printer printer2 = new Printer('O') + 5;
        Console.WriteLine("4. " + (string)printer2);

        if (printer1 > printer2)
            Console.WriteLine("5. Der 1. Drucker hat mehr Zeichen gedruckt.");
        else
            Console.WriteLine("5. Der 2. Drucker hat mehr Zeichen gedruckt.");
    }
}
