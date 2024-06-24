using System;

namespace Blatt1A1
{
    enum Lebensmittelgruppe
    {
        OBST,
        GEMUESE,
        FLEISCH,
        SUESSWAREN,
    }
    
    class Artikel
    {
        private string bezeichner;
        private uint nummer;
        private double preis;
        private Lebensmittelgruppe gruppe;

        public Artikel()
        {
            bezeichner = Parse("string", "Bezeichner", Convert.ToString);
            nummer = Parse("+int", "Nummer", Convert.ToUInt32);
            preis = Parse("double", "Preis", Convert.ToDouble);
            gruppe = (Lebensmittelgruppe) Parse($"0 = OBST, 1 = GEMUESE, 2 = FLEISCH, 3 = SUESSWAREN", "Lebensmittelgruppe", Convert.ToUInt32);
        }

        public Artikel(string bezeichner, uint nummer, double preis, Lebensmittelgruppe gruppe)
        {
            this.bezeichner = bezeichner;
            this.nummer = nummer;
            this.preis = preis;
            this.gruppe = gruppe;
        }

        public T Parse<T>(string subject, string descriptor, Func<string, T> parser)
        {
            Console.Write($"{descriptor} des Artikels ({subject}): ");
            var value = Console.ReadLine() ?? "";
            return parser(value);
        }

        public String GetBez()
        {
            return bezeichner;
        }

        public void setBez(string bezeichner)
        {
            this.bezeichner = bezeichner;
        }

        public double GetPreis()
        {
            return preis;
        }

        public void SetPreis(double preis)
        {
            this.preis = preis;
        }

        public void SetNummer(uint nummer)
        {
            this.nummer = nummer;
        }

        public override string ToString()
        {
            return $"{bezeichner}: {nummer}, {preis:F}€ ({gruppe})";
        }
    }
    
    internal class Program
    {
        private static Artikel[] artikel = new Artikel[4];
        private static bool beendet = false;

        private static void ArtikelEinlesen()
        {
            Console.WriteLine("Bitte pflegen sie 3 Artikel ein.");
            for (var i = 0; i < 3; i++)
            {
                artikel[i] = new Artikel();
            }
        }

        private static void ArtikelAendern()
        {
            Console.WriteLine("Bezeichnung des Artikels eingeben?");
            var bezeichner = Console.ReadLine();
            foreach (var a in artikel)
            {
                if(a.GetBez() != bezeichner) continue;
                
                a.setBez(a.Parse("string", "Neuer Bezeichner", Convert.ToString));
                a.SetPreis(a.Parse("double", "Neuer Preis", Convert.ToDouble));
                return;
            }
            Console.WriteLine("Es wurde kein Artikel mit diesem Bezeichner gefunden.");
        }

        private static void ArtikelAusgeben()
        {
            foreach (var a in artikel)
            {
                Console.WriteLine(a.ToString());
            }
        }

        private static void TeurstenArtikelAusgeben()
        {
            var preis = 0.0;
            Artikel teuerste = null;
            foreach (var a in artikel)
            {
                if (preis < a.GetPreis())
                {
                    preis = a.GetPreis();
                    teuerste = a;
                }
            }

            if (teuerste == null)
            {
                Console.WriteLine("Kein Artikel gefunden.");
                return;
            }
            Console.WriteLine(teuerste.GetBez());
        }

        private static void Beenden()
        {
            beendet = true;
        }

        private static void OptionAusführen()
        {
            Console.Write("Was wünschen Sie zu tun?  \n1 = Ändern  \n2 = Ausgabe  \n3 = teuerster Artikel  \n4 = Ende  \nIhre Auswahl:");
            var auswahl = Convert.ToUInt32(Console.ReadLine() ?? "");
            switch (auswahl)
            {
                case 1:
                    ArtikelAendern();
                    break;
                case 2:
                    ArtikelAusgeben();
                    break;
                case 3:
                    TeurstenArtikelAusgeben();
                    break;
                case 4:
                    Beenden();
                    break;
            }
        }
        
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ArtikelEinlesen();
            artikel[3] = new Artikel("Bounty", 4714, 2.19, Lebensmittelgruppe.SUESSWAREN);
            while (!beendet)
            {
                OptionAusführen();
            }
        }
    }
}