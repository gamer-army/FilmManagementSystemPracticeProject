namespace FilmManagementSystem.Repository.Contracts;

public interface IScreeningManager
{
    void Add(Screening screening);
    IEnumerable<Screening> SearchByFilmTitle(string filmTitle);
    IEnumerable<Screening> SearchByFilmID(string filmID);
    IEnumerable<Screening> SearchByScreeningTime(TimeOnly screeningTime);
}
