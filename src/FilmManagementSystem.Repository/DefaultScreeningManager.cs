namespace FilmManagementSystem.Repository;

public class DefaultScreeningManager : IScreeningManager
{
    private List<Screening> _screenings;

    public DefaultScreeningManager()
    {
        _screenings = new List<Screening>();
    }

    public void Add(Screening screening)
    {
        if(_screenings.Any(_screening => _screening.ID == screening.ID))
        {
            throw new InvalidOperationException($"Duplicate entry for Screening with ID:{screening.ID}");
        }
        
        _screenings.Add(screening);
    }

    public IEnumerable<Screening> SearchByFilmID(string filmID)
    {
        return _screenings.Where(screening => screening.Film.ID == filmID);
    }

    public IEnumerable<Screening> SearchByFilmTitle(string filmTitle)
    {
        return _screenings.Where(
            screening => screening.Film.Title.ToUpper().Contains(filmTitle.ToUpper()));
    }

    public IEnumerable<Screening> SearchByScreeningTime(TimeOnly screeningTime)
    {
        return _screenings.Where(screening => screeningTime <= screening.StartTime);
    }
}
