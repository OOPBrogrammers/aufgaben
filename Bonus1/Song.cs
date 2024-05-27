public class Song
{
  //TODO: Instanzvariablen bzw. Properties hinzufuegen
  public int Duration { get; }
  public String Title { get; }
  public String Artist { get; }
  public String Album { get;  }
  public int Id { get; }

  //TODO: Konstruktor implementieren
  public Song(int id, string title, string artist, string album, int duration)
  {
    Id = id;
    Title = title;
    Artist = artist;
    Album = album;
    Duration = duration;
  }
}

