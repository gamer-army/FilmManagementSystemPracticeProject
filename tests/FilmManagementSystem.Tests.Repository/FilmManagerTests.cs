namespace FilmManagementSystem.Tests.Repository;

public class FilmManagerTests
{
    IFilmManager filmManager;
    
    public FilmManagerTests()
    {
        filmManager = new DefaultFilmManagerSUTFactory()
            .WithFilms(
                new Film("AAAA", "Neonazi Propaganda", new TimeSpan(3,25,0), 12),
                new Film("AAAL", "Morbin' Time", new TimeSpan(3,25,0), 18),
                new Film("XXXX", "Minions Nazi Operations 1933-1945", new TimeSpan(1,45,0), 3)
            )
            .Build();
    }

    [Fact]
    public void ShouldThrowExceptionWhenAddingDuplicateEntry()
    {
        Action act = () =>
            filmManager.Add(new Film("AAAA", "Kanye West Chronicles", new TimeSpan(2,0,0), 15));

        act.Should().Throw<InvalidOperationException>()
            .WithMessage("Duplicate entry for Film with ID:AAAA");
    }

    [Fact]
    public void ShouldSearchFilmByTitle()
    {
        var searchNazi = filmManager.SearchFilmByTitle("nazi");
        
        searchNazi.Count().Should().Be(2);
        searchNazi.Should().Contain(film => film.ID == "AAAA");
        searchNazi.Should().Contain(film => film.ID == "XXXX");
    }
}
