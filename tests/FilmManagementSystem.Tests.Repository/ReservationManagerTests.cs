namespace FilmManagementSystem.Tests.Repository;

public class ReservationManagerTests
{
    private IReservationManager _reservationManager;

    public ReservationManagerTests()
    {
        var filmManager = new DefaultFilmManagerSUTFactory()
            .WithFilms(
                new Film("AAX1", "Morbius", new TimeSpan(01,45,0), 15),
                new Film("AAX2", "Morbius II", new TimeSpan(01,58,0), 12),
                new Film("AAX3", "Morbius: The Reawakening", new TimeSpan(03,12,0), 18),
                new Film("XXXX", "Minions Nazi Operations 1933-1945", new TimeSpan(1,45,0), 3)
            ).Build();
    
        var screeningManager = new DefaultScreeningManagerSUTFactory()
            .WithFilmManager(filmManager)
            .WithScreenings(
                new Screening("AAX1", CinemaCode.C1, new TimeOnly(11,30), 250),
                new Screening("AAX1", CinemaCode.C2, new TimeOnly(11,45), 250),
                new Screening("AAX2", CinemaCode.C1, new TimeOnly(13,50), 275),
                new Screening("AAX3", CinemaCode.C3, new TimeOnly(10,20), 325),
                new Screening("XXXX", CinemaCode.C4, new TimeOnly(10,20), 225),
                new Screening("XXXX", CinemaCode.C1, new TimeOnly(14,00), 225)
            ).Build();
        
        _reservationManager = new DefaultReservationManagerSUTFactory()
            .WithFilmManager(filmManager)
            .WithScreeningManager(screeningManager)
            .WithReservations(
                new Reservation("C1-AAX1-1130", new Customer("Walter", "Cat", new DateOnly(2000,1,1))),
                new Reservation("C1-AAX1-1130", new Customer("Watson", "Cat", new DateOnly(1999,7,3))),
                new Reservation("C1-AAX1-1130", new Customer("Wendy", "Cat", new DateOnly(2000,1,1))),
                new Reservation("C1-AAX1-1130", new Customer("White", "Cat", new DateOnly(1996,7,20))),
                new Reservation("C3-AAX3-1020", new Customer("Biggie", "Smalls", new DateOnly(1983,10,20))),
                new Reservation("C3-AAX3-1020", new Customer("Carl", "Johnson", new DateOnly(1992,2,25))),
                new Reservation("C2-AAX1-1145", new Customer("Ivan", "Kjarlson", new DateOnly(2001,4,29))),
                new Reservation("C2-AAX1-1145", new Customer("Vladimir", "Putin", new DateOnly(1978,8,8))),
                new Reservation("C2-AAX1-1145", new Customer("Joseph", "Stalin", new DateOnly(1961,9,9))),
                new Reservation("C2-AAX1-1145", new Customer("George", "Bush", new DateOnly(2001,9,11))),
                new Reservation("C2-AAX1-1145", new Customer("Jeffrey", "Eipstein", new DateOnly(1990,10,20))),
                new Reservation("C1-XXXX-1400", new Customer("Pyro", "Cynical", new DateOnly(1999,5,20))),
                new Reservation("C1-XXXX-1400", new Customer("Wendi", "Goon", new DateOnly(1999,5,21))),
                new Reservation("C1-XXXX-1400", new Customer("Leafy", "Calvin", new DateOnly(1999,5,25))),
                new Reservation("C1-XXXX-1400", new Customer("Joe", "Biden", new DateOnly(1999,5,26)))
            ).Build();
    }

    [Fact]
    public void ShouldThrowExceptionWhenAddingReservationWithUnderAgedCustomer()
    {
        var twoYrsAgo = DateOnly.FromDateTime(DateTime.Now.Subtract(new TimeSpan(365*2,0,0,0)));
        var reservation = new Reservation("C1-XXXX-1400", new Customer("Tu","Young", twoYrsAgo));

        Action act = () => _reservationManager.Add(reservation);

        act.Should().Throw<ArgumentException>()
            .WithMessage("Customer 'Tu Young' is not old enough to view 'Minions Nazi Operations 1933-1945' Age Rating:3");
    }

    [Theory]
    [InlineData("C1-AAX1-1130-WALTERCAT")]
    [InlineData("C1-AAX1-1130-WATSONCAT")]
    [InlineData("C1-AAX1-1130-WENDYCAT")]
    [InlineData("C1-AAX1-1130-WHITECAT")]
    public void ShouldSearchByReservationID(string reservationID)
    {
        _reservationManager.Exists(reservationID).Should().BeTrue();
        _reservationManager.SearchByID(reservationID).Should().NotBeNull();
    }

    [Theory]
    [InlineData("Cat", 4)]
    [InlineData("ARL", 2)]
    [InlineData("in", 4)]
    [InlineData("george bush", 1)]
    public void ShouldSearchByName(string name, ushort results)
    {
        _reservationManager.SearchByName(name).Should().HaveCount(results);
    }
}
