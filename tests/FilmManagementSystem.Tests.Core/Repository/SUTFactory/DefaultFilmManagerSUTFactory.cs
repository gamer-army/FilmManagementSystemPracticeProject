using FilmManagementSystem.Core.Repository;
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

        foreach(var film in _films)
        {
            fm.Add(film);
        }

        return fm;
    }
}
