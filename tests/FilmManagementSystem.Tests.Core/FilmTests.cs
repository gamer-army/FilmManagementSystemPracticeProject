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
}