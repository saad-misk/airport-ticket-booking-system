namespace AirportTicketBookingSystem.Models
{
    public class Passenger
    {
        public string PassengerId {  get; set; }
        public string Name { get; set; }
        public List<Booking> Bookings { get; set; }

    }
}
