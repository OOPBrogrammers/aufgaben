public class User
{
  
  //TODO: Instanzvariablen bzw. Properties hinzufuegen
  //TODO: Zusaetzliche Methoden hinzufügen und implementieren

  private User(string username, string password)
  {
    //TODO: Konstruktur implementieren
  }


  /**
   * Die Methode ueberprueft, ob username nur Buchstaben (A-Z und a-z) enthaelt.
   * Wenn das der Fall, wird mit Hilfe des privaten Konstruktors ein User-Objekt erzeugt,
   * ansonsten wird null zurückgeliefert.
   */
  public static User CreateUser(string username, string password)
  {
    //TODO: Methode implementieren
  }

  /**
   * Erzeugt eine neue Playlist mit dem uebergebenen Namen und fuegt diese dem User hinzu.
   */
  public Playlist AddPlaylistToUser(string name)
  {
    //TODO: Methode implementieren
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
    //TODO: Methode implementieren
  }

  /**
   * Ueberprueft, ob das uebergebene Passwort dem Passwort des Users entspricht
   */
  public bool CheckPassword(string password)
  {
    //TODO: Methode implementieren
  }
}
