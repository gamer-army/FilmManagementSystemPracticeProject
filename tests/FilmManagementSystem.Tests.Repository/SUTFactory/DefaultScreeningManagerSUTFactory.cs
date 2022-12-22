namespace FilmManagementSystem.Tests.Repository;

public class DefaultScreeningManagerSUTFactory
{
    public List<Screening> _screenings;

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

    public IScreeningManager Build()
    {
        IScreeningManager ism = new DefaultScreeningManager();

        _screenings.ForEach(_screening => ism.Add(_screening));

        return ism;
    }
}
