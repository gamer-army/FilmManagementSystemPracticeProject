namespace FilmManagementSystem.Core;

public class Reservation
{
    public string ScreeningID {get; init;}
    public Customer Customer {get; init;}
    public string ID => 
        $"{ScreeningID}-{Customer.FirstName.ToUpper()}{Customer.LastName.ToUpper()}";

    public Reservation(string screeningID, Customer customer)
    {
        ScreeningID = !string.IsNullOrWhiteSpace(screeningID) ? screeningID : throw new ArgumentNullException(nameof(screeningID));
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));

        // I would like to do a validation check here with the Customer.Age and Screening.Film.AgeRating 
        // but it appears I can't come up with a design unless the constructor's parameters are Object instance
        // which I don't like.
    }
}
