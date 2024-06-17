class Program
{
    public class FahrerBetrunkenException : FahrsimulatorException
    {
        public FahrerBetrunkenException() : base("Der Fahrer ist betrunken.") { }

        public FahrerBetrunkenException(string message) : base(message) { }

        public FahrerBetrunkenException(string message, Exception inner) : base(message, inner) { }
    }
    
    public class FahrzeugLiegengebliebenException : FahrsimulatorException
    {
        public FahrzeugLiegengebliebenException() : base("Das Fahrzeug ist liegengeblieben.") { }

        public FahrzeugLiegengebliebenException(string message) : base(message) { }

        public FahrzeugLiegengebliebenException(string message, Exception inner) : base(message, inner) { }
    }
    public class FahrsimulatorException : Exception
    {
        public FahrsimulatorException() : base("Ein Fahrsimulatorproblem ist aufgetreten.") { }

        public FahrsimulatorException(string message) : base(message) { }

        public FahrsimulatorException(string message, Exception inner) : base(message, inner) { }
    }

    public class Fahrer
    {
        public bool IstBetrunken { get; set; }
    }

    public class Fahrzeug
    {
        
        public bool HatSprit { get; set; }
        
        public void Einsteigen(Fahrer kunde)
        {
            if (kundeIstBetrunken(kunde))
            {
                throw new FahrerBetrunkenException();
            }
        }

        public void FahreNach(string ziel)
        {
            if (!HatSprit)
            {
                throw new FahrzeugLiegengebliebenException();
            }
            Console.WriteLine($"Fahre nach {ziel}.");
        }

        public void Aussteigen(Fahrer kunde)
        {
            Console.WriteLine("Der Fahrer steigt aus.");
        }

        private bool kundeIstBetrunken(Fahrer kunde)
        {
            return kunde.IstBetrunken;
        }
    }

    static void PolizeiRufen()
    {
        Console.WriteLine("Polizei wird gerufen.");
    }

    static void PannenDienstRufen()
    {
        Console.WriteLine("Pannendienst wird gerufen.");
    }

    static void Abschliessen()
    {
        Console.WriteLine("Das Fahrzeug wird abgeschlossen.");
    }

    static void Main()
    {
        Fahrer kunde = new Fahrer { IstBetrunken = true };
        Fahrzeug leihfahrzeug = new Fahrzeug { HatSprit = true };

        try
        {
            leihfahrzeug.Einsteigen(kunde);
            leihfahrzeug.FahreNach("Nürnberg");
            leihfahrzeug.Aussteigen(kunde);
        }
        catch (FahrerBetrunkenException e)
        {
            Console.WriteLine(e.Message);
            PolizeiRufen();
        }
        catch (FahrzeugLiegengebliebenException e)
        {
            Console.WriteLine(e.Message);
            PannenDienstRufen();
        }
        catch (FahrsimulatorException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            Abschliessen();
        }
    }
}