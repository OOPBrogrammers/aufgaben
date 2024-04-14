namespace Blatt1A4;

// Aufgabe 4

class Account
{
    // Instanzvariablen
    string kontoinhaber;
    double guthaben;
    int id;

    // Überziehungslimit
    static double überziehungslimit = -1000;

    // Konstruktor
    public Account(string kontoinhaber, double guthaben, int idkonto)
    {
        this.kontoinhaber = kontoinhaber;
        this.guthaben = guthaben;
        this.id = idkonto;
    }

    public void Withdraw(double betrag)
    {
        if (this.guthaben - betrag >= überziehungslimit)
        {
            this.guthaben -= betrag;
            Console.WriteLine($"{betrag}€ ausgezahlt. Neuer Kontostand: {this.guthaben}€");
        }

        else
            Console.WriteLine($"Auszahlung nicht erfolgt, da das Überziehungslimit von {überziehungslimit}€ erreicht wurde. \nEs befindet sich zu wenig Geld auf ihrem Konto. Aktueller Kontostand: {this.guthaben}€");
    }

    public void Deposit(double betrag)
    {
        this.guthaben += betrag;
        Console.WriteLine($"{betrag}€ eingezahlt. Neuer Kontostand: {this.guthaben}€");
    }

    public static void Überziehungslimitänderung(double neuesÜberziehungslimit)
    {
        überziehungslimit = neuesÜberziehungslimit;
    }
}

class Program
{
    // Test
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Account meinKonto = new Account("Bob der Baumeister", -500, 1);
        meinKonto.Withdraw(600);
        meinKonto.Deposit(500);
        Account.Überziehungslimitänderung(-2000);
        meinKonto.Withdraw(2000);
    }
}