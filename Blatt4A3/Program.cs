abstract class Card
{
    public string Name { get; set; }

    public Card(string name)
    {
        Name = name;
    }
}

class Event : Card
{
    public string InfoText { get; set; }

    public Event(string name, string infoText) : base(name)
    {
        InfoText = infoText;
    }
}

class Item : Card
{
    public int Value { get; set; }

    public Item(string name, int value) : base(name)
    {
        Value = value;
    }
}

class Action : Card
{
    public Action(string name) : base(name) { }

    public void Sell(Item item)
    {
        Console.WriteLine($"Ich verkaufe {item.Name} für {item.Value} Goldstücke");
    }

    public void PerformAction(Event eventCard)
    {
        Console.WriteLine($"Aktion: {eventCard.InfoText}");
    }
}

class KartenStapel
{
    private Stack<Card> stack = new Stack<Card>();

    public void AddCard(Card card)
    {
        stack.Push(card);
    }

    public Card TakeCard()
    {
        if (stack.Count == 0)
            throw new InvalidOperationException("Der Kartenstapel ist leer");
        
        return stack.Pop();
    }
}

class Program
{
    static void Main()
    {
        KartenStapel stack = new KartenStapel();
        
        // Eine neue Instanz von Event anlegen, mit Werten füllen und danach auf den Stapel legen
        Card newCard = new Event("Regen", "Es regnet sehr stark.");
        stack.AddCard(newCard);
        
        // Noch eine Karte anlegen und auf den Stapel usw.
        newCard = new Item("Regenschirm", 100);
        stack.AddCard(newCard);
        
        newCard = new Action("Aktionskarte");
        stack.AddCard(newCard);
        
        // Ok, lets play and take two cards!
        Card firstCard = stack.TakeCard();
        Card secondCard = stack.TakeCard();
        
        // Wir haben jetzt zwei Karten und entscheiden was zu tun ist, z. B.
        if (firstCard is Action actionCard)
        {
            // Noch eine Karte nehmen
            Card thirdCard = stack.TakeCard();
            
            // Wir schummeln ein wenig, da wir wissen, was kommen muss.
            // Wenn das Programm ausgeführt wird, kann jedoch auch ein anderer
            // Typ Karte kommen.
            // DANN BRICHT DAS PROGRAMM MIT EINEM LAUFZEITFEHLER AB!!!!!
            if (thirdCard is Event eventCard)
            {
                actionCard.PerformAction(eventCard);
            }
            else
            {
                Console.WriteLine("Die dritte Karte ist keine Ereigniskarte. Aktion kann nicht ausgeführt werden.");
            }
        }
        else
        {
            Console.WriteLine("Die erste Karte ist keine Aktionskarte.");
        }
    }
}