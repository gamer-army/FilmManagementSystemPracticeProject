using FilmManagementSystem.Core;

public class Program
{
    public static void Main(string[] args)
    {
        var s = new Screening(
            new Film("45AL", "Morbius II", new TimeSpan(1,45,0), 0), 
            CinemaCode.C1,
            new TimeOnly(11,30),
            250);

        Console.WriteLine(s.EndTime);    
        Console.WriteLine(s.ID);
    }
}