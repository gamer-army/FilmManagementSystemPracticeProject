namespace FilmManagementSystem.Core;

public class Screening
{
    
    public string FilmID {get; init;}
    public CinemaCode CinemaCode {get; init;}
    public TimeOnly StartTime {get; init;}
    public uint Price {get; init;}

    //public TimeOnly EndTime => StartTime.Add(Film.Duration);
    public string ID => $"{CinemaCode}-{FilmID}-{StartTime.Hour.WithPreceeding0s(2)}{StartTime.Minute.WithPreceeding0s(2)}";

    public Screening(string filmID, CinemaCode cinemaCode, TimeOnly startTime, uint price)
    {
        this.FilmID = filmID.IsValidFilmID() ? filmID.ToUpper() : 
            throw new ArgumentException($"{nameof(filmID)} should be alphanumeric of 4 chars",nameof(filmID));
        
        this.CinemaCode = cinemaCode;
        this.StartTime = startTime;
        this.Price = price;
    }
}
