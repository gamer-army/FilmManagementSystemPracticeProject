namespace FilmManagementSystem.Core;

public class Customer
{
    public string FirstName {get; init;}
    public string LastName {get; init;}
    public DateOnly DateOfBirth{get; init;}
    public int Age {
        get {
            var dob = new DateTime(DateOfBirth.Year, DateOfBirth.Month, DateOfBirth.Day);
            return DateTime.Now.Subtract(dob).Days / 365;
        }
    }

    public Customer(string firstName, string lastName, DateOnly dateOfBirth)
    {
        FirstName = firstName.IsValidName() ? firstName : 
            throw new ArgumentException($"{nameof(firstName)} is not a valid name", nameof(firstName));
        
        LastName = lastName.IsValidName() ? lastName : 
            throw new ArgumentException($"{nameof(lastName)} is not a valid name", nameof(lastName));
        
        DateOfBirth = dateOfBirth.IsPast() ? dateOfBirth : 
            throw new ArgumentException($"{nameof(dateOfBirth)} must be past dated", nameof(dateOfBirth));
    }
}
