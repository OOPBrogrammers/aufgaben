using System;

// Definition der benutzerdefinierten Ausnahme
public class BinaryFormatException : Exception
{
    public BinaryFormatException(string message) : base(message) { }
}

// Definition der Klasse mit der bin2Dec-Methode
public class BinaryConverter
{
    public static int bin2Dec(string binaryString)
    {
        // Überprüfen, ob die Zeichenkette nur aus '0' und '1' besteht
        foreach (char c in binaryString)
        {
            if (c != '0' && c != '1')
            {
                throw new BinaryFormatException("The input string is not a valid binary number.");
            }
        }

        // Konvertieren der binären Zeichenkette in eine Dezimalzahl
        int decimalValue = 0;
        for (int i = 0; i < binaryString.Length; i++)
        {
            if (binaryString[binaryString.Length - 1 - i] == '1')
            {
                decimalValue += (int)Math.Pow(2, i);
            }
        }

        return decimalValue;
    }
}

// Hauptprogramm zum Testen der bin2Dec-Methode
public class Program
{
    public static void Main()
    {
        Console.Write("Geben Sie eine Binärzahl ein: ");
        string binaryInput = Console.ReadLine();

        try
        {
            int decimalValue = BinaryConverter.bin2Dec(binaryInput);
            Console.WriteLine($"Die Dezimalzahl ist: {decimalValue}");
        }
        catch (BinaryFormatException e)
        {
            Console.WriteLine(e);
        }
    }
}