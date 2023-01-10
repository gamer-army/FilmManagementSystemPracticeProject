namespace FilmManagementSystem.Tests.Repository;

public class ScreeningManagerTests
{   
    private IScreeningManager screeningManager;
    public ScreeningManagerTests()
    {
        var filmManager = new DefaultFilmManagerSUTFactory()
            .WithFilms(
                new Film("AAX1", "Morbius", new TimeSpan(01,45,0), 15),
                new Film("AAX2", "Morbius II", new TimeSpan(01,58,0), 12),
                new Film("AAX3", "Morbius: The Reawakening", new TimeSpan(03,12,0), 18),
                new Film("XXXX", "Minions Nazi Operations 1933-1945", new TimeSpan(1,45,0), 3)
            ).Build();
    
        screeningManager = new DefaultScreeningManagerSUTFactory()
            .WithFilmManager(filmManager)
            .WithScreenings(
                new Screening("AAX1", CinemaCode.C1, new TimeOnly(11,30), 250),
                new Screening("AAX1", CinemaCode.C2, new TimeOnly(11,45), 250),
                new Screening("AAX2", CinemaCode.C1, new TimeOnly(13,50), 275),
                new Screening("AAX3", CinemaCode.C3, new TimeOnly(10,20), 325),
                new Screening("XXXX", CinemaCode.C4, new TimeOnly(10,20), 225),
                new Screening("XXXX", CinemaCode.C1, new TimeOnly(14,00), 225)
            ).Build();
    }

    [Fact]
    public void ShouldThrowExceptionWhenAddingNonExistingFilmID()
    {
        Action act = () => 
            screeningManager.Add(new Screening("ABCD", CinemaCode.C6, new TimeOnly(15,00), 20));
        
        act.Should().Throw<ArgumentException>()
            .WithMessage("Film:ABCD not found");
    }

    [Fact]
    public void ShouldThrowExceptionWhenDuplicateEntryIsAdded()
    {
        Action act = () =>
            screeningManager.Add(new Screening("XXXX", CinemaCode.C1, new TimeOnly(14,00), 225));
        
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void ShouldSearchFilmByTitle()
    {
        var screeningsWithMorbius = screeningManager.SearchByFilmTitle("Morbius");
        
        screeningsWithMorbius.Should().HaveCount(4);
        screeningsWithMorbius.Should().Contain(screening => screening.FilmID == "AAX1");
        screeningsWithMorbius.Should().Contain(screening => screening.FilmID == "AAX2");
        screeningsWithMorbius.Should().Contain(screening => screening.FilmID == "AAX3");
        screeningsWithMorbius.Should().NotContain(screening => screening.FilmID == "XXXX");
    }

    [Fact]
    public void ShouldSearchByFilmID()
    {
        var screeningsWithFilmXXXX = screeningManager.SearchByFilmID("XXXX");
        
        screeningsWithFilmXXXX.Should().HaveCount(2);
        screeningsWithFilmXXXX.Should().Contain(screening => screening.ID == "C4-XXXX-1020");
        screeningsWithFilmXXXX.Should().Contain(screening => screening.ID == "C1-XXXX-1400");
    }

    [Fact]
    public void ShouldSearchByShowingTime()
    {
        var screenings1130 = screeningManager.SearchByScreeningTime(new TimeOnly(11,30));

        screenings1130.Should().HaveCount(4);
        screenings1130.Should().Contain(screening => screening.ID == "C1-AAX1-1130");
        screenings1130.Should().Contain(screening => screening.ID == "C2-AAX1-1145");
        screenings1130.Should().Contain(screening => screening.ID == "C1-AAX2-1350");
        screenings1130.Should().Contain(screening => screening.ID == "C1-XXXX-1400");
    }

    [Fact]
    public void ShouldSearchNonExistentFilmTitle()
    {
        var screenings = screeningManager.SearchByFilmTitle("ASDHASFKDSAFNSAFISAFASFS");
        screenings.Should().HaveCount(0);
    }
}
