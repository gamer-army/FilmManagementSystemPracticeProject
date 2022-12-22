namespace FilmManagementSystem.Tests.Repository;

public class ScreeningManagerTests
{
    [Fact]
    public void ShouldSearchFilmByTitle()
    {
        var morbius = new Film("ABCD", "Morbius", new TimeSpan(1,30,0), 12);
        var morbius2 = new Film("ABCE", "Morbius II", new TimeSpan(1,45,0), 12);
        var morbius3 = new Film("ABCF", "Morbius Milo Have Sex", new TimeSpan(2,10,0), 18);
        var magicMike = new Film("XXXX", "Magic Mike Sex Real", new TimeSpan(3,28,0), 18);
        
        var sm = new DefaultScreeningManagerSUTFactory()
            .WithScreenings(
                new Screening(morbius, CinemaCode.C1, new TimeOnly(11,0), 200),
                new Screening(morbius2, CinemaCode.C2, new TimeOnly(11,0), 200),
                new Screening(morbius3, CinemaCode.C1, new TimeOnly(13,30), 320),
                new Screening(magicMike, CinemaCode.C3, new TimeOnly(16,30), 400))
            .Build();

        var morbiusFilms = sm.SearchByFilmTitle("morbius");
        morbiusFilms.Count().Should().Be(3);
        morbiusFilms.Should().Contain(screening => screening.ID == "C1-ABCD-1100");
    }
}
