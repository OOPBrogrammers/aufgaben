public class Playlist
{

  //TODO: Instanzvariablen bzw. Properties hinzufuegen
  //TODO: Weitere Methoden hinzufuegen und implementieren
  public String Name { get; }
  public List<Song> Songs { get; private set; }
  public Playlist(string name)
  {
    Name = name;
    Songs = [];
  }

  public int TotalDuration
  {
    // Berechnet die Gesamtspielzeit der Playlist aus den Einzelspielzeiten der enthaltenen Lieder
    // TODO: Implementieren
    get
    {
      var totalDuration = 0;
      foreach(var song in Songs)
      {
        totalDuration += song.Duration;
      }

      return totalDuration;
    }
  }

  public void AddSong(Song song)
  {
    Songs.Add(song);
  }


  /**
   * BONUSAUFGABE
   * Sortieren Sie die Playlist alphabetisch nach Titeln.
   */
  public void SortPlaylistByTitle()
  {
    Songs = Songs.OrderBy(song => song.Title).ToList();
  }

  /**
   * BONUSAUFGABE
   * Methode gibt eine NEUE Liste zurueck, die nur Lieder von dem uebergebenen Kuenstler enthaelt.
   * Die urspruengliche Liste soll dabei also nicht veraendert werden.
   */
  public List<Song> FilterPlaylistByArtist(string artist)
  {
    return Songs.Where(song => song.Artist == artist).ToList();
  }

  /**
   * BONUSAUFGABE
   * Methode speichert die Playlist in eine CSV-Datei.
   * Der Pfad zum Speicherort wird in dem Parameter path uebergeben.
   */
  public void SavePlaylistToCSVFile(string path)
  {
    //TODO: Methode implementieren
  }
}
