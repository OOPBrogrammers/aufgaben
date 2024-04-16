public class Playlist
{

  //TODO: Instanzvariablen bzw. Properties hinzufuegen
  //TODO: Weitere Methoden hinzufuegen und implementieren

  public Playlist(string name)
  {
    //TODO: Konstruktor implementieren
  }

  public int TotalDuration
  {
    // Berechnet die Gesamtspielzeit der Playlist aus den Einzelspielzeiten der enthaltenen Lieder
    // TODO: Implementieren
  }


  /**
   * BONUSAUFGABE
   * Sortieren Sie die Playlist alphabetisch nach Titeln.
   */
  public void SortPlaylistByTitle()
  {
    //TODO: Methode implementieren
  }

  /**
   * BONUSAUFGABE
   * Methode gibt eine NEUE Liste zurueck, die nur Lieder von dem uebergebenen Kuenstler enthaelt.
   * Die urspruengliche Liste soll dabei also nicht veraendert werden.
   */
  public List<Song> FilterPlaylistByArtist(string artist)
  {
    //TODO: Methode implementieren
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
