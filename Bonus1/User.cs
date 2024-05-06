public class User
{
    
  public List<Playlist> Playlists { get; }
  public String Username { get; }
  private String Password { get; set; }

  private User(string username, string password)
  { 
      Playlists = []; 
      Username = username;
      Password = password;
  }


  /**
   * Die Methode ueberprueft, ob username nur Buchstaben (A-Z und a-z) enthaelt.
   * Wenn das der Fall, wird mit Hilfe des privaten Konstruktors ein User-Objekt erzeugt,
   * ansonsten wird null zurückgeliefert.
   */
  public static User CreateUser(string username, string password)
  {
      foreach (var symbol in username)
      {
          if ((symbol < 'a' || symbol > 'z') && (symbol < 'A' || symbol > 'Z')) return null;
      }

      return new User(username, password);
  }

  /**
   * Erzeugt eine neue Playlist mit dem uebergebenen Namen und fuegt diese dem User hinzu.
   */
  public Playlist AddPlaylistToUser(string name)
  {
      var playlist = new Playlist(name);
      Playlists.Add(playlist);
      return playlist;
  }

  public Playlist? GetPlaylist(string name)
  {
      return Playlists.Find(playlist => playlist.Name == name);
  }

  /**
   * Methode zum Aendern des Passworts
   * Ueberprueft zunächst, ob oldPassword dem bisherigen Passwort entspricht.
   * Ist das der Fall, wird das Passwort in newPassword geaendert und true zurückgeliefert.
   * Andernfalls bleibt das Passwort erhalten und es wird false zurueckgegeben.
   *
   */
  public bool ChangePassword(string oldPassword, string newPassword)
  {
      if (Password != oldPassword) return false;
      Password = newPassword;
      return true;
  }

  /**
   * Ueberprueft, ob das uebergebene Passwort dem Passwort des Users entspricht
   */
  public bool CheckPassword(string password)
  {
      return Password == password;
  }
}
