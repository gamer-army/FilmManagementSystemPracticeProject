namespace FilmManagementSystem.Repository;

public interface IFilmManager
{
    void Add(Film film);
    IEnumerable<Film> SearchFilmByTitle(string title);
    IEnumerable<Film> SearchFilmByAgeRating(int age);
}
