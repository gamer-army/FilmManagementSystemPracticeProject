namespace FilmManagementSystem.Client.Cli;

public class FilmAddActionPresenter : PromptScreen
{
    private FilmService _filmService;
    public FilmAddActionPresenter(FilmService filmService)
    {
        _filmService = filmService ?? throw new ArgumentNullException(nameof(filmService));
    }

    private FilmModel InputFilm()
    {
        var film = new FilmModel();

        film.ID = PromptInput("Input Film ID (4 letter-alphanumeric)");
        
        if(!film.ID.IsValidFilmID())
        {
            throw new Exception($"FilmID should be a 4 length alphanumeric");
        }

        if(_filmService.FilmExists(film.ID))
        {
            throw new Exception($"Duplicate entry Film:{film.ID}");
        }

        film.Title = PromptInput("Input Film Title (2-100 chars)");
        if(!film.Title.Length.IsBetween(2,101))
        {
            throw new Exception("Film Title should be 2-101 characters long");
        }

        film.Duration = TimeSpan.Parse(PromptInput("Input Film Duration [hh:mm](1:30-3:30)"));
        if(!film.Duration.IsValidFilmDuration())
        {
            throw new Exception("Film Duration should be 1h30m to 3h30m long");
        }

        film.MinimumAge = int.Parse(PromptInput("Input Film's Minimum Age"));
        if(!film.MinimumAge.IsBetween(1,99))
        {
            throw new Exception("Please input a proper age you fucking idiot");
        }

        return film;
    }

    public override void Prompt()
    {
        try
        {
            var film = InputFilm();
            _filmService.AddFilm(film);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
