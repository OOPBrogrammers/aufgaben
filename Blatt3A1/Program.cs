namespace Blatt3A1
{
    class Person 
    {
        string Name { get; }
        public Person(string name) 
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
    class Kette 
    {
        
        Element? _head;
        public class Element
        {
            public Person Daten { get; set; }
            public Element? Successor { get; set; }

            public Element(Person daten)
            {
                Daten = daten;
            }

            public override string ToString()
            {
                return Daten.ToString();
            }
        }
        public void Add(Person person) 
        {
            Element newElement = new Element(person);
            Element? current = _head;
            while (current != null && current.Successor != null) 
            {
                current = current.Successor;
            }

            if (current != null)
                current.Successor = newElement;
            else
                _head = newElement;
        }
        public void AusgabeListe()
        {
            Element? current = _head;
            while (current != null) 
            {
                Console.WriteLine(current);
                current = current.Successor;
            }
        }
    }
    internal class Program
    {
        static void Main()
        {
            Kette kette = new Kette();

            // Personen hinzufügen
            kette.Add(new Person("Alice"));
            kette.Add(new Person("Bob"));
            kette.Add(new Person("Charlie"));

            // Alle Elemente ausgeben
            kette.AusgabeListe();
        }
    }
}