namespace Blatt2A1
{
    class Duration 
    {
        // Eigenschaften
        int Days;
        int Hours;
        int Minutes;

        // Konstruktor
    public Duration (int days, int hours, int minutes) 
        {
            Days = days;
            Hours = hours;
            Minutes = minutes;
        }

        // Für Ausgabe
        public override string ToString()
        {
            return $"Duration: {Days} Days, {Hours} Hours, {Minutes} Minutes";
        }

        // Umrechnung der Dauer in Minuten
        public int DurationInMinutes() 
        {
            return Days * 24 * 60 + Hours * 60 + Minutes; 
        }

        // überladene Operatoren
        public static Duration operator + (Duration a, Duration b) 
        {
            int totalMinutes = a.DurationInMinutes() + b.DurationInMinutes();
            int days = totalMinutes / (24 * 60);
            int remainingMinutes = totalMinutes % (24 * 60);
            int hours = remainingMinutes / 60;
            int minutes = remainingMinutes % 60;
            return new Duration(days, hours, minutes); 
        }

        public static Duration operator -(Duration a, Duration b)
        {
            int totalMinutes = a.DurationInMinutes() - b.DurationInMinutes();
            int days = totalMinutes / (24 * 60);
            int remainingMinutes = totalMinutes % (24 * 60);
            int hours = remainingMinutes / 60;
            int minutes = remainingMinutes % 60;
            return new Duration(days, hours, minutes);
        }

        public static bool operator <(Duration a, Duration b) 
        {
            return a.DurationInMinutes() < b.DurationInMinutes();
        }
        public static bool operator >(Duration a, Duration b)
        {
            return a.DurationInMinutes() > b.DurationInMinutes();
        }

        public static bool operator >=(Duration a, Duration b)
        {
            return a.DurationInMinutes() >= b.DurationInMinutes();
        }
        public static bool operator <=(Duration a, Duration b)
        {
            return a.DurationInMinutes() <= b.DurationInMinutes();
        }
    }
    internal class Program
    {
        // zum Testen
        static void Main(string[] args)
        {
            Duration duration1 = new Duration(1, 7, 3);
            Duration duration2 = new Duration(2, 23, 2);
            Console.WriteLine(duration1.ToString());
            Console.WriteLine(duration2.ToString());
            Console.WriteLine($"Duration in minutes: { duration1.DurationInMinutes()}");
            Console.WriteLine($"Duration in minutes: {duration2.DurationInMinutes()}");
            Console.WriteLine(duration1+duration2);
            Console.WriteLine(duration1-duration2);
            // Test der <-Operatorüberladung
            Console.WriteLine($"Is duration1 < duration2? {duration1 < duration2}.");

            // Test der >-Operatorüberladung
            Console.WriteLine($"Is duration1 > duration2? {duration1 > duration2}.");

            // Test der <=-Operatorüberladung
            Console.WriteLine($"Is duration1 <= duration2? {duration1 <= duration2}.");

            // Test der >=-Operatorüberladung
            Console.WriteLine($"Is duration1 >= duration2? {duration1 >= duration2}.");
        }
    }
}
