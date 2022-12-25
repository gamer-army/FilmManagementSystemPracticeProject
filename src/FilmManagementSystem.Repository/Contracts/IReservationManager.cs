namespace FilmManagementSystem.Repository.Contracts;

public interface IReservationManager
{
    void Add(Reservation reservation);
    Reservation Get(string reservationID);
    bool Exists(string reservationID);
    IEnumerable<Reservation> SearchByName(string name);
}
