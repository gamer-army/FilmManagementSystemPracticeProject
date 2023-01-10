namespace FilmManagementSystem.Repository.Contracts;

public interface IFilmManager
{
    void Add(Film film);
    bool Exists(string filmID);
    Film? Get(string filmID);
    IEnumerable<Film> SearchFilmByTitle(string title);
    IEnumerable<Film> SearchFilmByAgeRating(int age);
}
