namespace FilmManagementSystem.Tests.Core;

public class FilmTests
{
    public class FilmID
    {
        const string InvalidIDMessage = "id should be alphanumeric of 4 chars (Parameter 'id')";

        [Theory]
        [InlineData("10")]
        [InlineData("4AAA2")]
        [InlineData("!@#()")]
        public void ShouldThrowExceptionWithInvalidID(string ID)
        {
            Action act = () => new Film(ID, "Valid Title", new TimeSpan(1,30,0), 0);

            act.Should().Throw<ArgumentException>()
                        .WithMessage(InvalidIDMessage);
        }

        [Theory]
        [InlineData("45AL")]
        [InlineData("9000")]
        [InlineData("ZZZZ")]
        public void ShouldAcceptValidID(string ID)
        {
            Action act = () => new Film(ID, "Valid Title", new TimeSpan(1,30,0), 0);
            act.Should().NotThrow();
        }
    }

    public class FilmTitle
    {
        const string InvalidTitleMessage = "title should be 3-100 characters long (Parameter 'title')";

        [Theory]
        [InlineData("A")]
        [InlineData("AMongus Saurus Sexy Benis With Big Smelly Balls What the fuck am i doing with my life seriously God left me unfinished")]
        public void ShouldThrowExceptionForInvalidTitle(string title)
        {
            Action act = () => new Film("45AA", title, new TimeSpan(1,30,0), 0);
            act.Should().Throw<ArgumentException>()
                        .WithMessage(InvalidTitleMessage);
        }
        
        [Theory]
        [InlineData("Amongus")]
        [InlineData("Kanye West is not the enemy")]
        public void ShouldAcceptValidTitle(string title)
        {
            Action act = () => new Film("45AA", title, new TimeSpan(1,30,0), 0);
            act.Should().NotThrow();
        }
    }

    public class FilmDuration
    {
        const string InvalidDurationMessage = "duration should be between 1h30m-3h30m (Parameter 'duration')";

        [Theory]
        [InlineData(0,1,20,0)]
        [InlineData(0,1,29,1)]
        [InlineData(0,3,31,1)]
        public void ShouldThrowExceptionWithInvalidDuration(int days, int hours, int minutes, int seconds)
        {
            var duration = new TimeSpan(days, hours, minutes, seconds);
            Action act = () => new Film("45AA", "Normal Title", duration, 0);
            act.Should().Throw<ArgumentException>()
                        .WithMessage(InvalidDurationMessage);
        }

        [Theory]
        [InlineData(0,1,30,0)]
        [InlineData(0,1,45,0)]
        [InlineData(0,3,20,0)]
        public void ShouldAcceptValidDuration(int days, int hours, int minutes, int seconds)
        {
            var duration = new TimeSpan(days, hours, minutes, seconds);
            Action act = () => new Film("45AA", "Normal Title", duration, 0);
            act.Should().NotThrow();
        }
    }
}