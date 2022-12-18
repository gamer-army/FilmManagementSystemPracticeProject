namespace FilmManagementSystem.Tests.Core.Unit;

public class ReservationTest
{
    [Fact]
    public void ShouldThrowExceptionWhenCustomerIsTooYoungForTheFilm()
    {
        var SixYrsAgo = DateOnly.FromDateTime(
                            DateTime.Now.Subtract(
                                new TimeSpan(365*6, 0, 0, 0)));

        var film = new Film("45A6","Morbius: Have Sex",new TimeSpan(1,69,0),18);
        var screening = new Screening(film, CinemaCode.C6, new TimeOnly(10,45), 69);
        var customer = new Customer("Milo","Morbius", SixYrsAgo);

        Action act = () => new Reservation(screening, customer);

        var error = Assert.Throws<ArgumentException>(act);
        Assert.Equal(
            "Customer 'Milo Morbius' is not old enough to view 'Morbius: Have Sex' Age Rating:18", 
            error.Message);
    }

    [Fact]
    public void ShouldAcceptCustomerOldEnoughForFilm()
    {
        var film = new Film("45A6","Morbius: Have Sex",new TimeSpan(1,69,0),18);
        var screening = new Screening(film, CinemaCode.C6, new TimeOnly(10,45), 69);
        var customer = new Customer("Milo","Morbius", new DateOnly(1998,10,20));

        Action act = () => new Reservation(screening, customer);

        var error = Record.Exception(act);
        Assert.Null(error);
    }
}
