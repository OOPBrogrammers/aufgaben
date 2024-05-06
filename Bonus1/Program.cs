public class Program
{
    private readonly List<User> users;

    public Program()
    {
        AllSongs = new List<Song>();
        users = new List<User>();
        
        foreach (var song in LoadSongs("../../../songs.csv"))
        {
            AllSongs.Add(song);
        }
    }

    public List<Song> LoadSongs(string path)
    {
        var reader = new StreamReader(path);
        var songs = new List<Song>();
        var currentLine = 0;
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine() ?? "";
            if (currentLine > 0)
            {
                var arguments = line.Split(",");
                songs.Add(new Song(
                    Int32.Parse(arguments[0]),
                    arguments[1],
                    arguments[2],
                    arguments[3],
                    Int32.Parse(arguments[4])
                ));
            }

            currentLine++;
        }
        reader.Close();

        return songs;
    }

    public List<Song> AllSongs { get; }

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
        play.AddSong(new Song(0, "The Red", "Chevelle", "Wonder What's Next", 239));
        program.users.Add(user);
        UI ui = new UI(program);
        ui.Run();
    }
}