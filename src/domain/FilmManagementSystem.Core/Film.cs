namespace FilmManagementSystem.Core;

/// <summary>
/// abcasdasfasfsafas
/// </summary> 
public class Film
{

    /// <summary>
    /// ID Summary lasdasdfasfsafasfasfas
    /// </summary> 
    public string ID {get; init;}
    public string Title {get; init;}
    public TimeSpan Duration {get; init;}
    public byte AgeRating {get; init;}

    public Film(string id, string title, TimeSpan duration, byte minimumAge)
    {
        ID = id.IsValidFilmID() ? id.ToUpper() : 
            throw new ArgumentException($"{nameof(id)} should be alphanumeric of 4 chars",nameof(id));

        Title = title.Length.IsBetween(2,101) ? title :
            throw new ArgumentException($"{nameof(title)} should be 3-100 characters long", nameof(title));

        Duration = duration.IsValidFilmDuration() ? duration :
            throw new ArgumentException($"{nameof(duration)} should be between 1h30m-3h30m", nameof(duration));
        
        AgeRating = minimumAge;
    }

    /// <summary>
    /// test gago aaaa
    /// </summary> 
    public void Testing(){

    }
}
