/**
 * An dieser Klasse müssen Sie keine Aenderungen vornehmen!
 */
public class UI
{
  private readonly Program program;

  public UI(Program program)
  {
    this.program = program;
  }

  public void Run()
  {
    Console.WriteLine("Willkommen zu deinem persönlichen Playlist-Manager!\n");
    User user = null;
    while (user == null)
    {
      Console.Write("Bitte gib deinen Benutzernamen ein: ");
      string userName = Console.ReadLine();
      Console.Write("Bitte gib dein Passwort ein: ");
      string password = Console.ReadLine();
      user = program.GetUser(userName, password);
      if (user == null) Console.WriteLine("Die Eingabe war leider nicht korrekt. " +
        "Bitte geben Sie eine richtige Kombination aus Benutzername und Passwort ein.");
    }
    Console.WriteLine("\nHallo " + user.Username + "!");
    while (true)
    {
      Console.WriteLine("\nWas kann ich für dich tun?");
      Console.WriteLine("(1) Passwort ändern");
      Console.WriteLine("(2) Alle Lieder anzeigen");
      Console.WriteLine("(3) Alle Playlisten anzeigen");
      Console.WriteLine("(4) Neue Playlist erstellen");
      Console.WriteLine("(5) Playlist speichern");
      Console.WriteLine("(6) Playlist alphabetisch sortieren");
      Console.WriteLine("(7) Alle Songs von einem Künstler in einer Playlist ausgeben");
      Console.WriteLine("(8) Anwendung beenden");
      int choice = -1;
      while (choice == -1)
      {
        try
        {
          choice = Int32.Parse(Console.ReadLine());
        }
        catch { Console.WriteLine("Bitte nur ganze Zahlen eingeben."); }
      }

      switch (choice)
      {
        case 1: changePassword(user); break;
        case 2: listAllSongs(program.AllSongs); break;
        case 3: showPlaylists(user); break;
        case 4: createNewPlaylist(user); break;
        case 5: SavePlaylist(user); break;
        case 6: SortPlaylist(user); break;
        case 7: FilterPlaylistByArtist(user); break;
        case 8: return;
      }
    }
  }

  private void SortPlaylist(User user)
  {
    Console.Write("Gib die zu sortierende Playlist ein:");
    string playlistName = Console.ReadLine() ?? "";
    var playlist = user.GetPlaylist(playlistName);
    if (playlist == null)
    {
      Console.WriteLine("Diese Playlist existiert nicht.");
      return;
    }
    
    playlist.SortPlaylistByTitle();
    Console.WriteLine("Die Playlist wurde sortiert.");
  }

  private void FilterPlaylistByArtist(User user)
  {
    Console.Write("Gib die Playlist ein, dessen Lieder angezeigt werden sollen:");
    string playlistName = Console.ReadLine() ?? "";
    var playlist = user.GetPlaylist(playlistName);
    if (playlist == null)
    {
      Console.WriteLine("Diese Playlist existiert nicht.");
      return;
    }
  
    Console.Write("Gib den Künstler ein, dessen Lieder angezeigt werden sollen:");
    var artist = Console.ReadLine() ?? "";
    var songs = playlist.FilterPlaylistByArtist(artist);
    listAllSongs(songs);
    
  }
  private void SavePlaylist(User user)
  {
    Console.Write("Gib die zu speichernde Playlist ein:");
    string playlistName = Console.ReadLine() ?? "";
    var playlist = user.GetPlaylist(playlistName);
    if (playlist == null)
    {
      Console.WriteLine("Diese Playlist existiert nicht.");
      return;
    }
    
    playlist.SavePlaylistToCSVFile($"../../../{playlist.Name}.csv");
    Console.WriteLine("Die Playlist wurde gespeichert.");
  }

  private void changePassword(User user)
  {
    Console.Write("Gib dein altes Passwort ein:");
    string oldPassword = Console.ReadLine();
    Console.Write("Gib dein neues Passwort ein:");
    string newPassword = Console.ReadLine();
    if (user.ChangePassword(oldPassword, newPassword))
    {
      Console.WriteLine("Passwort erfolgreich geändert");
    }
    else
    {
      Console.WriteLine("Passwort inkorrekt");
    }
  }

  private void createNewPlaylist(User user)
  {
    Console.WriteLine("Name der Playlist:");
    string name = Console.ReadLine();
    Playlist play = user.AddPlaylistToUser(name);
    while (true)
    {
      Console.WriteLine("Welches Lied möchtest du hinzufügen?");
      listAllSongs(program.AllSongs);
      Console.Write("Gib die ID des Lieds ein (Eingabe 0 schließt die Erstellung der Playlist ab): ");
      int id = -1;
      while (id == -1)
      {
        try
        {
          id = Int32.Parse(Console.ReadLine());
        }
        catch { Console.WriteLine("Bitte nur ganze Zahlen eingeben."); }
      }
      if (id < 1)
      {
        Console.WriteLine("Playlist vollständig!");
        listAllSongs(play.Songs);
        return;
      }
      else
      {
        Song song = program.GetSongById(id);
        if (song != null)
        {
          play.AddSong(song);
        }
        listAllSongs(play.Songs);
      }
    }
  }

  private void showPlaylists(User user)
  {
    foreach (Playlist list in user.Playlists)
    {
      Console.WriteLine("\nName der Playlist: " + list.Name);
      listAllSongs(list.Songs);
      Console.WriteLine($"Gesamte Laufzeit: {list.TotalDuration / 60} Minuten, {list.TotalDuration % 60} Sekunden\n");
    }
  }

  private void listAllSongs(List<Song> songs)
  {
    Console.WriteLine("__________________________________");
    for (int i = 0; i < songs.Count; i++)
    {
      Console.WriteLine($"{i + 1}) Titel: {songs[i].Title}, Künstler: {songs[i].Artist}\n");
    }
    Console.WriteLine("__________________________________");
  }
}
