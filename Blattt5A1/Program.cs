namespace Blatt5A1
{
    public class MeinFehler : System.Exception 
    {
        public int Fehlercode { get; set; }
        public MeinFehler(string message, int fehlercode) : base(message) 
        {
            Fehlercode = fehlercode;
        }
    }
    public class Program
    {
        public static void Methode1() 
        {
            try 
            {
                Methode2();
            }
            catch (MeinFehler e)
            {
                Console.WriteLine($"Fehlermeldung: {e.Message}");
                Console.WriteLine($"Fehlercode: {e.Fehlercode}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fehlercode: {e.Message}");
            }
            finally 
            {
                Console.WriteLine("finally in Methode 1");
            }
        }
        public static void Methode2()
        {
            try 
            {
                Methode3();
            }
            catch(MeinFehler e)
            {
                Console.WriteLine($"Fehlermeldung: {e.Message}");
                Console.WriteLine($"Fehlercode: {e.Fehlercode}");
                e.Fehlercode = 24;
                throw;
            }
            catch(Exception e) 
            {
                Console.WriteLine($"Fehlercode: {e.Message}");
                throw;
            }
            finally 
            {
                Console.WriteLine("finally in Methode2");
            }
        }
        public  static void Methode3()
        {
            throw new MeinFehler("Ein benutzerdefinierter Fehler ist aufgetreten.", 12);
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("*******************************");
                Methode1();
                Console.WriteLine("*******************************");
            }
            catch (Exception)
            {
                Console.WriteLine("Hier ist noch etwas schief gegangen");
            }
        }
    }
}
