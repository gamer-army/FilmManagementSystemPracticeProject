namespace FilmManagementSystem.Tests.Core.Unit;

public class CustomerTests
{
    [Theory]
    [InlineData(2000,10,5)]
    [InlineData(1991,1,10)]
    public void ShouldAcceptPastDatedDateOfBirth(int year, int month, int day)
    {
        var DateOfBirth = new DateOnly(year, month, day);
        Action act = () => new Customer("Bobby", "McDimsdale", DateOfBirth);
        
        var error = Record.Exception(act);
        Assert.Null(error);
    }
}
