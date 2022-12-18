namespace FilmManagementSystem.Tests.Core.Unit;

public class ScreeningTests
{
    [Theory]
    [InlineData("1:30", "13:00", "14:30")]
    [InlineData("1:45", "11:30", "13:15")]
    public void ScreeningTime_ShouldDeriveEndTime(
        string FilmDuration, string ScreeningStarTime,string expectedScreeningEndTime)
    {
        var film = new Film("45AL","Morbius IV", TimeSpan.Parse(FilmDuration), 0);
        var screening = new Screening(film, CinemaCode.C1, TimeOnly.Parse(ScreeningStarTime),20);
        var expectedEndTime = TimeOnly.Parse(expectedScreeningEndTime);

        Assert.Equal(expectedEndTime, screening.EndTime);
    }
    

}
