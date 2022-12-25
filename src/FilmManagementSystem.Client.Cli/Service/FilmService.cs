namespace FilmManagementSystem.Client.Cli;

public class FilmService
{
    private IFilmManager _filmManager;

    public FilmService(IFilmManager filmManager)
    {
        _filmManager = filmManager ?? throw new ArgumentNullException(nameof(filmManager));    
    }

    public void AddFilm(FilmModel filmModel)
    {
        var film = new Film(filmModel.ID!, filmModel.Title!, filmModel.Duration, (byte)filmModel.MinimumAge);

        _filmManager.Add(film);
    }

    public bool FilmExists(string filmID)
        => _filmManager.Exists(filmID);
}
