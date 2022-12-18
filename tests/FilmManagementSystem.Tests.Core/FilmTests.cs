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

            var error = Assert.Throws<ArgumentException>(act);
            Assert.Equal(InvalidIDMessage, error.Message);
        }

        [Theory]
        [InlineData("45AL")]
        [InlineData("9000")]
        [InlineData("ZZZZ")]
        public void ShouldAcceptValidID(string ID)
        {
            Action act = () => new Film(ID, "Valid Title", new TimeSpan(1,30,0), 0);
            var error = Record.Exception(() => act.Invoke());
            Assert.Null(error);
        }
    }

    public class FilmTitle
    {
        const string InvalidTitleMessage = "title should be 3-100 characters long (Parameter 'title')";

        [Theory]
        [InlineData("AM")]
        [InlineData("AMongus Saurus Sexy Benis With Big Smelly Balls What the fuck am i doing with my life seriously God left me unfinished")]
        public void ShouldThrowExceptionForInvalidTitle(string title)
        {
            Action act = () => new Film("45AA", title, new TimeSpan(1,30,0), 0);
            var error = Assert.Throws<ArgumentException>(act);
            Assert.Equal(InvalidTitleMessage, error.Message);
        }
        
        [Theory]
        [InlineData("Amongus")]
        [InlineData("Kanye West is not the enemy")]
        public void ShouldAcceptValidTitle(string title)
        {
            Action act = () => new Film("45AA", title, new TimeSpan(1,30,0), 0);
            var error = Record.Exception(() => act.Invoke());
            Assert.Null(error);
        }
    }
}