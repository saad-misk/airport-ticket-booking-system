using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Services;

namespace AirportTicketBookingSystem.Commands
{
    public class FilterBookingsCommand : ICommand
    {
        private readonly ManagerService _managerService;

        public FilterBookingsCommand(ManagerService managerService)
        {
            _managerService = managerService;
        }

        public void Execute()
        {
            var criteria = GetFilterCriteriaFromUser();
            var filteredBookings = _managerService.FilterBookings(criteria);

            Console.WriteLine("Filtered Bookings:");
            Console.WriteLine(filteredBookings.Count());

            foreach (var booking in filteredBookings)
            {
                Console.WriteLine($"Booking ID: {booking.BookingId}, Flight Number: {booking.FlightNumber}, " +
                                  $"Passenger: {booking.PassengerId}, Price: {_managerService.GetFlightPrice(booking.FlightNumber, booking.Class)}");
            }
        }

        private FilterCriteria GetFilterCriteriaFromUser()
        {
            var criteria = new FilterCriteria();
            var promptUser = new PromptUser();
            Console.WriteLine("Enter filter criteria:");

            criteria.FlightNumber = promptUser.PromptForNullableString("Flight Number (leave blank for any): ");
            criteria.Price = promptUser.PromptForNullableDecimal("Price (leave blank for any): ");
            criteria.DepartureCountry = promptUser.PromptForNullableString("Departure Country (leave blank for any): ");
            criteria.DestinationCountry = promptUser.PromptForNullableString("Destination Country (leave blank for any): ");
            criteria.DepartureDate = promptUser.PromptForNullableDate("Departure Date (yyyy-MM-dd, leave blank for any): ");
            criteria.DepartureAirport = promptUser.PromptForNullableString("Departure Airport (leave blank for any): ");
            criteria.ArrivalAirport = promptUser.PromptForNullableString("Arrival Airport (leave blank for any): ");
            criteria.Passenger = promptUser.PromptForNullableString("Passenger ID (leave blank for any): ");
            criteria.Class = promptUser.PromptForNullableString("Class (Economy, Business, First Class, leave blank for any): ");

            return criteria;
        }
    }
}
