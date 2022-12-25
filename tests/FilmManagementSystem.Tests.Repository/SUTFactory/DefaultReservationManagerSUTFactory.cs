namespace FilmManagementSystem.Tests.Repository.SUTFactory;

public class DefaultReservationManagerSUTFactory
{
    private List<Reservation> _reservations;
    private IScreeningManager? _screeningManager;
    private IFilmManager? _filmManager;
    
    public DefaultReservationManagerSUTFactory()
    {    
        _reservations = new List<Reservation>();
    }

    public DefaultReservationManagerSUTFactory WithFilmManager(
        IFilmManager filmManager)
    {
        _filmManager = filmManager;

        return this;
    }
    
    public DefaultReservationManagerSUTFactory WithScreeningManager(
        IScreeningManager screeningManager)
    {
        _screeningManager = screeningManager;
        
        return this;
    }

    public DefaultReservationManagerSUTFactory WithReservations(
        params Reservation[] reservations)
    {
        _reservations.Clear();
        
        foreach(var reservation in reservations)
        {
            _reservations.Add(reservation);
        }

        return this;
    }

    public IReservationManager Build()
    {
        var rm = new DefaultReservationManager(_screeningManager!, _filmManager!);

        _reservations.ForEach(_reservation => rm.Add(_reservation));
        
        return rm;
    }
}
