namespace FilmManagementSystem.Core;

public class Screening
{
    public Film Film {get; init;}
    public CinemaCode CinemaCode {get; init;}
    public TimeOnly StartTime {get; init;}
    public uint Price {get; init;}

    public TimeOnly EndTime => StartTime.Add(Film.Duration);
    public string ID => $"{CinemaCode}-{Film.ID}-{StartTime.Hour.WithPreceeding0s(2)}{StartTime.Minute.WithPreceeding0s(2)}";

    public Screening(Film film, CinemaCode cinemaCode, TimeOnly startTime, uint price)
    {
        this.Film = film ?? throw new ArgumentNullException(nameof(film));
        this.CinemaCode = cinemaCode;
        this.StartTime = startTime;
        this.Price = price;
    }
}
