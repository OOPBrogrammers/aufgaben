public class Program
{

  private readonly List<User> users;

  public Program()
  {
    AllSongs = new List<Song>();
    users = new List<User>();

    //TODO: Fuellen Sie die Liste AllSongs mit Liedern aus der Datei songs.csv
  }

  public List<Song> AllSongs { get; }

  private void addUser(User user)
  {
    users.Add(user);
  }

  public User GetUser(string username, string password)
  {
    foreach (User user in users)
    {
      if (username.Equals(user.Username))
      {
        if (user.CheckPassword(password))
        {
          return user;
        }
      }
    }
    return null;
  }

  public Song GetSongById(int id)
  {
    foreach (Song song in AllSongs)
    {
      if (song.Id == id) return song;
    }
    return null;
  }

  public static void Main(string[] args)
  {
    Program program = new Program();
    User user = User.CreateUser("test", "test");
    Playlist play = user.AddPlaylistToUser("Party");
    play.AddSong(new Song(0, "The Red", "Chevelle", 239));
    program.addUser(user);
    UI ui = new UI(program);
    ui.Run();
  }
}










