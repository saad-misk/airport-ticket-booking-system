using AirportTicketBookingSystem.Helpers;
using AirportTicketBookingSystem.Models;
using AirportTicketBookingSystem.Services;

namespace AirportTicketBookingSystem.Views
{
    public class AddFlightCommand : ICommand
    {
        private readonly FlightService _flightService;

        public AddFlightCommand(FlightService flightService)
        {
            _flightService = flightService;
        }

        public void Execute()
        {
            var flight = GetFlightInformationFromUser();
            _flightService.AddFlight(flight);
        }

        private Flight GetFlightInformationFromUser()
        {
            var flight = new Flight();
            var promptUser = new PromptUser();
            Console.WriteLine("Enter Flight Information:");

            flight.FlightNumber = promptUser.PromptForString("Flight Number: ");
            flight.DepartureCountry = promptUser.PromptForString("Departure Country: ");
            flight.DestinationCountry = promptUser.PromptForString("Destination Country: ");
            flight.DepartureDate = promptUser.PromptForDate("Departure Date (yyyy-MM-dd): ");
            flight.DepartureAirport = promptUser.PromptForString("Departure Airport: ");
            flight.ArrivalAirport = promptUser.PromptForString("Arrival Airport: ");
            var flightClass = promptUser.PromptForString("Class (Economy, Business, First Class): ");
            var classPrice = promptUser.PromptForDecimal("Price: ");
            flight.ClassPrices = new Dictionary<string, decimal>();
            flight.ClassPrices[flightClass] = classPrice;

            return flight;
        }
    }
}
