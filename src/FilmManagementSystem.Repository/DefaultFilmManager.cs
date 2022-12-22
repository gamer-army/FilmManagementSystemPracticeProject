namespace FilmManagementSystem.Repository;

public class DefaultFilmManager : IFilmManager
{
    private List<Film> _films;
    
    public DefaultFilmManager()
    {
        _films = new List<Film>();    
    }

    public void Add(Film film)
    {
        if(_films.Any(_films => _films.ID == film.ID))
        {
            throw new InvalidOperationException($"Duplicate entry for Film with ID:{film.ID}");
        }
        
        _films.Add(film);
    }

    public IEnumerable<Film> SearchFilmByTitle(string title)
    {
        return _films.Where(film => film.Title.ToUpper().Contains(title.ToUpper()));
    }
    
    public IEnumerable<Film> SearchFilmByAgeRating(int age)
    {
        return _films.Where(film => film.AgeRating <= age);
    }
}
