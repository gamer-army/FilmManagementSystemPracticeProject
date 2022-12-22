namespace FilmManagementSystem.Tests.Core.Repository;

public class FilmManagerTests
{
    [Fact]
    public void ShouldSearchFilmByTitle()
    {
        var filmSUT = new DefaultFilmManagerSUTFactory()
            .WithFilms(
                new Film("AAAA", "Neonazi Propaganda", new TimeSpan(3,25,0), 12),
                new Film("AAAL", "Morbin' Time", new TimeSpan(3,25,0), 18),
                new Film("XXXX", "Minions Nazi Operations 1933-1945", new TimeSpan(1,45,0), 3)
            )
            .Build();
        
        var searchNazi = filmSUT.SearchFilmByTitle("nazi");
        searchNazi.Count().Should().Be(2);
        searchNazi.Should().Contain(film => film.ID == "AAAA");
        searchNazi.Should().Contain(film => film.ID == "XXXX");
    }   
}
