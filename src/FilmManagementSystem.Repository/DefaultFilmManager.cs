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
        if(Exists(film.ID))
        {
            throw new InvalidOperationException($"Duplicate entry for Film with ID:{film.ID}");
        }
        
        _films.Add(film);
    }

    public Film Get(string filmID)
        => _films.First(_film => _film.ID == filmID);
    

    public bool Exists(string filmID)
        => _films.Any(_film => _film.ID == filmID);

    public IEnumerable<Film> SearchFilmByTitle(string title)
        => _films.Where(film => film.Title.ToUpper().Contains(title.ToUpper()));
    
    
    public IEnumerable<Film> SearchFilmByAgeRating(int age)
        => _films.Where(film => film.AgeRating <= age);
}
