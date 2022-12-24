namespace FilmManagementSystem.Core;

public class Reservation
{
    public string ScreeningID {get; init;}
    public Customer Customer {get; init;}
    public string ID => 
        $"{ScreeningID}-{Customer.FirstName.ToUpper()}{Customer.LastName.ToUpper()}";

    public Reservation(string screeningID, Customer customer)
    {
        ScreeningID = screeningID;
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));

        // if(customer.Age < Screening.Film.AgeRating)
        // {
        //     throw new ArgumentException(
        //         $"Customer '{customer.FirstName} {customer.LastName}' is not old enough to view '{Screening.Film.Title}' Age Rating:{Screening.Film.AgeRating}");
        // }
    }
}
