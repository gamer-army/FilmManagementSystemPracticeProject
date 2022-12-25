namespace FilmManagementSystem.Repository;

public class DefaultReservationManager : IReservationManager
{
    private List<Reservation> _reservations;
    private IScreeningManager _screeningManager;
    private IFilmManager _filmManager;

    public DefaultReservationManager(
        IScreeningManager screeningManager,
        IFilmManager filmManager)
    {
        _screeningManager = screeningManager ?? 
            throw new ArgumentNullException(nameof(screeningManager));
        
        _filmManager = filmManager ??
            throw new ArgumentNullException(nameof(filmManager));

        _reservations = new List<Reservation>();
    }

    public void Add(Reservation reservation)
    {
        if(!_screeningManager.Exists(reservation.ScreeningID))
        {
            throw new ArgumentException($"Screening:{reservation.ScreeningID} not found");
        }

        var screening = _screeningManager.Get(reservation.ScreeningID);
        var film = _filmManager.Get(screening.FilmID);

        if(reservation.Customer.Age < film.AgeRating)
        {
            throw new ArgumentException(
                $"Customer '{reservation.Customer.FullName}' is not old enough to view '{film.Title}' Age Rating:{film.AgeRating}");
        }

        if(_reservations.Any(_reservation => _reservation.ID == reservation.ID))
        {
            throw new InvalidOperationException($"Duplicate entry Reservation:{reservation.ID}");
        }
        
        _reservations.Add(reservation);
    }

    public bool Exists(string reservationID)
        => _reservations.Any(_reservation => _reservation.ID == reservationID);

    public Reservation Get(string reservationID)
        => _reservations.First(_reservation => _reservation.ID == reservationID);

    public IEnumerable<Reservation> SearchByName(string name)
        => _reservations.Where(
            _reservation => _reservation.Customer.FullName.ToUpper().Contains(name.ToUpper()));
}
