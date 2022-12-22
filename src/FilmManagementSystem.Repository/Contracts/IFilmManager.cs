namespace FilmManagementSystem.Repository.Contracts;

public interface IFilmManager
{
    void Add(Film film);
    IEnumerable<Film> SearchFilmByTitle(string title);
    IEnumerable<Film> SearchFilmByAgeRating(int age);
}
