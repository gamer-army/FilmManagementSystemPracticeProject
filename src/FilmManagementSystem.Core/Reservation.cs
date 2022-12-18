namespace FilmManagementSystem.Core;

public class Reservation
{
    public Screening Screening {get; init;}
    public Customer Customer {get; init;}
    public string ID => 
        $"{Screening.ID}-{Customer.FirstName.ToUpper()}{Customer.LastName.ToUpper()}";

    public Reservation(Screening screening, Customer customer)
    {
        Screening = screening ?? throw new ArgumentNullException(nameof(screening));
        Customer = customer ?? throw new ArgumentNullException(nameof(customer));

        if(customer.Age < Screening.Film.AgeRating)
        {
            throw new ArgumentException(
                $"Customer '{customer.FirstName} {customer.LastName}' is not old enough to view '{Screening.Film.Title}' Age Rating:{Screening.Film.AgeRating}");
        }
    }
}
