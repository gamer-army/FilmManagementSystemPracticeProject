namespace FilmManagementSystem.Repository;

public class DefaultScreeningManager : IScreeningManager
{
    private List<Screening> _screenings;
    private IFilmManager _filmManager;

    public DefaultScreeningManager(IFilmManager filmManager)
    {
        _filmManager = filmManager ?? 
            throw new ArgumentNullException(nameof(filmManager));
        
        _screenings = new List<Screening>();
    }

    public void Add(Screening screening)
    {
        if(!_filmManager.Exists(screening.FilmID))
        {
            throw new ArgumentException($"Film:{screening.FilmID} not found");
        }

        if(Exists(screening.ID))
        {
            throw new InvalidOperationException($"Duplicate entry for Screening with ID:{screening.ID}");
        }
        
        _screenings.Add(screening);
    }

    public bool Exists(string screeningID)
        => _screenings.Any(_screening => _screening.ID == screeningID);

    public Screening Get(string screeningID)
        => _screenings.First(_screening => _screening.ID == screeningID);

    public IEnumerable<Screening> SearchByFilmID(string filmID)
        => _screenings.Where(screening => screening.FilmID == filmID);

    public IEnumerable<Screening> SearchByFilmTitle(string filmTitle)
        =>_screenings.Where(
             screening => 
                _filmManager.Get(screening.FilmID).Title.ToUpper()
                .Contains(filmTitle.ToUpper()));

    public IEnumerable<Screening> SearchByScreeningTime(TimeOnly screeningTime)
        => _screenings.Where(screening => screeningTime <= screening.StartTime);
}
