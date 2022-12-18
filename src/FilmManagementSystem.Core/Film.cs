﻿namespace FilmManagementSystem.Core;
public class Film
{
    public string ID {get; init;}
    public string Title {get; init;}
    public TimeSpan Duration {get; init;}
    public byte MinimumAge {get; init;}

    public Film(string id, string title, TimeSpan duration, byte minimumAge)
    {
        ID = id.IsAlphanumeric() ? id : 
            throw new ArgumentException($"{nameof(id)} should be alphanumeric",nameof(id));

        Title = (title.Length > 2 && title.Length < 101) ? title :
            throw new ArgumentException($"{nameof(title)} should be 3-100 characters long", nameof(title));

        Duration = duration > new TimeSpan(1,30,0) ? duration :
            throw new ArgumentException($"{nameof(duration)} should be more than 1h30m", nameof(duration));
        
    }
}
