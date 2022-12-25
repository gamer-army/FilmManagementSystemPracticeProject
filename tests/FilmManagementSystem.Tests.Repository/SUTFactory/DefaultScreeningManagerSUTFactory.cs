namespace FilmManagementSystem.Tests.Repository.SUTFactory;

public class DefaultScreeningManagerSUTFactory
{
    private List<Screening> _screenings;
    private IFilmManager? _filmManager;

    public DefaultScreeningManagerSUTFactory()
    {
        _screenings = new List<Screening>();
    }

    public DefaultScreeningManagerSUTFactory WithScreenings(params Screening[] screenings)
    {
        _screenings.Clear();
        foreach(var screening in screenings)
        {
            _screenings.Add(screening);
        }

        return this;
    }

    public DefaultScreeningManagerSUTFactory WithFilmManager(IFilmManager fm)
    {
        _filmManager = fm;
        
        return this;
    }

    public IScreeningManager Build()
    {
        IScreeningManager ism = new DefaultScreeningManager(_filmManager!);

        _screenings.ForEach(_screening => ism.Add(_screening));

        return ism;
    }
}
