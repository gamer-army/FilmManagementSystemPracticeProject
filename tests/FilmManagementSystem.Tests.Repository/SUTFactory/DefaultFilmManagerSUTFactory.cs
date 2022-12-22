namespace FilmManagementSystem.Tests.Core.Repository;

public class DefaultFilmManagerSUTFactory
{
    private List<Film> _films;

    public DefaultFilmManagerSUTFactory()
    {
        _films = new List<Film>();
    }
    
    public DefaultFilmManagerSUTFactory WithFilms(params Film[] films)
    {
        _films.Clear();
        foreach(Film film in films)
        {
            _films.Add(film);
        }

        return this;
    }

    public IFilmManager Build()
    {
        IFilmManager fm = new DefaultFilmManager();

        _films.ForEach(_film => fm.Add(_film));

        return fm;
    }
}
